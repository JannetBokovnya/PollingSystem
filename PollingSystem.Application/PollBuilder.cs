using PollingSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

public class PollBuilder
{
    private readonly string _questionText;
    private readonly List<PollAnswer> _items = new();
    private readonly List<string> _errors = new();
    

    public PollBuilder(string questionText)
    {
        _questionText = questionText;
    }

    public PollBuilder AddAnswer(Guid id, string title)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if (item is { })
        {
            return this;
        }

        _items.Add(new PollAnswer(id, title));
        return this;
    }

    //построитель, контролировать создание этого poll проверять наличие answer- ответов на этот
    //poll проверять их на любые исключения
    public Poll Build()
    {
        return new Poll(_questionText, _items);
        
    }


    //public PollResults GetResults(Poll poll)
    //{
    //    new PollResults(poll);
    //}
    //или
    public PollResults GetResults(Poll poll) => new(poll);

}
