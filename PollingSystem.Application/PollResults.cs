using System.Linq;
using System.Text;
using PollingSystem.Entities;
public class PollResults
{
    private readonly Poll _poll;

    //через конструктор можно сюда прокинуть разные штуки: репозитории, сервисы
    //и в GetView применить
    public PollResults(Poll poll)
    {
        _poll = poll;
    }
    public string GetView()
    {
        //вместо StringBuilder можно применить депенденс инжекшен
        //все что угодно для построения результатаов
        var stringBuilder = new StringBuilder(_poll.QuestionText);
        stringBuilder.AppendLine("-".PadLeft(50));
        if (_poll.Answers != null && _poll.Answers.Any())
        {
            _poll.Answers.ForEach(x => stringBuilder.AppendLine(x.ToString()));
        }
        return stringBuilder.ToString();
    }
}