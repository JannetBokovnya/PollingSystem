//ответы на вопросы
using PollingSystem.Entities;
using PollingSystem.Entities.Base;
using System;

namespace PollingSystem.Entities
{
    public class PollAnswer : Identity
    {
        public PollAnswer(Guid id, string title)
        {
            Title = title;
            Id = id;
        }
        //создали Guid и наследовались jn
        //public int Id { get; }
        //init для базы
        public string Title { get; init; }

        //количество голосов
        public int Votes { get; set; }

        //проценты
        public double Percents { get; set; }

        //рассчитываем процент голосов
        public void SetPercents(int totalVoites)
        {
            if (totalVoites > 0)
            {
                Percents = Votes * 100d / totalVoites;
            }


        }
        public override string ToString()
        {
            return $"* {Title} - {Votes} ({Percents:F}%)";

        }
    }
}
