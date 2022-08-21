using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingSystem.BlazorLib
{
    public class PollCreateModel:ComponentBase
    {
        //лист ошибок
        public List<string> Errors { get; } = new();
        public string? QuestionText { get; set; } = "Какая сегодня погода, на ваш взгляд?";

        public List<AnswerInput> Answers { get; set; } = new() 
        { 
            new AnswerInput{Text = "Нормальная" },
            new AnswerInput{Text = "Хорошая" },
            new AnswerInput{Text = "Отличная" },
            new AnswerInput{Text = "Плохая" },
            new AnswerInput { Text = "Хрень" }
        };

        public bool IsValid =>
            !string.IsNullOrEmpty(QuestionText)
            && QuestionText.Length > 0
            && Answers.Count is > 1 and <= 10;

        protected void AddAnswer()
        {
            Answers.Add(new AnswerInput());
        }

        protected void DeleteAnswer(AnswerInput item)
        {
            Answers.Remove(item);
        }
        protected void Validate()
        {
            var errors = ValidatePoll();
            var validationResults = errors.ToList();
            if (validationResults.Any())
            {
                Errors.AddRange(validationResults.Select(x => x.ErrorMessage).ToList()!);
            }
            else
            {
                Errors.Clear();
            }
        }

        //используем Task т. к там будет сервис
        protected Task SaveAnswer()
        {
            var errors = ValidatePoll();

            var validationResult = errors.ToList();
            if (validationResult.Any())
            {
                Errors.AddRange(errors.Select(x => x.ErrorMessage).ToList()!);
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        private IEnumerable<ValidationResult> ValidatePoll()
        {
            if (string.IsNullOrWhiteSpace(QuestionText))
            {
                yield return new ValidationResult("Не задан вопрос голосования");
            }

            if(QuestionText != null && (QuestionText.Length >512 || QuestionText.Length < 3))
            {
                yield return new ValidationResult("Длина вопроса для голосования должна быть более 3 и меньше 512 символов");
            }

            if (!Answers.Any())
            {
                yield return new ValidationResult("Не задан ответ для голосования");
                yield break;
            }

            if (Answers.Count < 2)
            {
                yield return new ValidationResult("Требуется более 2 вариантов ответа");
            }

            if (Answers.Count > 10)
            {
                yield return new ValidationResult("Можно задать не более 10 вариантов ответа");
            }

            foreach(var answer in Answers)
            {
                if (string.IsNullOrWhiteSpace(answer.Text))
                {
                    yield return new ValidationResult("Не задан текст ответа");
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(answer.Text) && answer.Text.Length > 512)
                {
                    yield return new ValidationResult($"\"{answer.Text}\" слишком длинный. Можно не более 512 символов.");
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(answer.Text) && answer.Text.Length < 3)
                {
                    yield return new ValidationResult($"\"{answer.Text}\" слишком короткий. Можно не менее 3 символов.");
                }
            }
        }
    }

    public class AnswerInput
    {
        public string? Text { get; set; }
    }
}
