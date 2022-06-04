
using PollingSystem.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;

//это главная зборка на нее ссылается application(данные)
//client ссылаетсы на application
namespace PollingSystem.Entities
{
    //голосование
    public class Poll : Identity
    {
        //голосование без вопроса не может быть поэтому создаем конструктор
        public Poll(string questionText, List<PollAnswer> answers):this(questionText)
        {
            QuestionText = questionText;
            Answers = answers;
        }

        private Poll(string questionText)
        {
            QuestionText = questionText;
        }
        //в модель помещаем поведение объекта
        //VoteTo сколько прибавляется готосов за тот или иной выбор
        public void VoteTo(Guid id, int vote = 1)
        {
            var item = Answers?.SingleOrDefault(x => x.Id == id);
            if (item == null)
            {
                return;
            }
            item.Votes += vote;

            var totalVotes = Answers?.Sum(x => x.Votes) ?? 0;
            //item.SetPercents(totalVotes);
            Answers?.ForEach(x => x.SetPercents(totalVotes));
        }

        public string QuestionText { get; init; }
        public List<PollAnswer>? Answers { get; init; }

        //переопределяем строку (нужно для вывода в консоль для теста)
        //перенесено в PollResults
        //public override string ToString()
        //{

        //    var stringBuilder = new StringBuilder(QuestionText);
        //    stringBuilder.AppendLine("-".PadLeft(50));
        //    if (Answers != null && Answers.Any())
        //    {
        //        Answers.ForEach(x => stringBuilder.AppendLine(x.ToString()));
        //    }
        //    return stringBuilder.ToString();
        //}
    }
}





