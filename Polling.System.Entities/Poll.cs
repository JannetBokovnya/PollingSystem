using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//голосование
public class Poll
{
    //голосование без вопроса не может быть поэтому создаем конструктор
    public Poll(string questionText, List<PollAnswer> answers)
    {
        QuestionText = questionText;
        Answers = answers;
    }
    //в модель помещаем поведение объекта
    //VoteTo сколько прибавляется готосов за тот или иной выбор
    public void VoteTo(int id, int vote = 1)
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

    public string QuestionText { get; }
    public List<PollAnswer>? Answers { get; }

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

//ответы на вопросы
public class PollAnswer
{
    public PollAnswer(int id, string title)
    {
        Title = title;
        Id = id;
    }
    public int Id { get; }
    public string Title { get; }

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
        return $"* {Title} ({Votes} {Percents:F})";

    }
}


