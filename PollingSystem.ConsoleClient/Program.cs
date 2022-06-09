using PollingSystem.Application;
using System;

using System.Collections.Generic;
//вместо используем FluentInterface

var builder = new PollBuilder("Как вам фильм Матрица?")
    .AddAnswer(Guid.Parse("51611623-e72f-0488-4011-be4f13c8e936"), "Нормально")
    .AddAnswer(Guid.Parse("b253b82c-90a1-2183-4053-48f910a49247"), "Не плохо")
    .AddAnswer(Guid.Parse("50f0b6ee-ba6e-f988-4f3b-79c85308ed25"), "Отстой")
    .AddAnswer(Guid.Parse("9ebb2234-75cb-eeb2-4fed-1774318d9ce8"), "Супер")
    .AddAnswer(Guid.Parse("51611623-e72f-0488-4011-be4f13c8e936"), "Очень круто");

var poll = builder.Build();

poll.VoteTo(Guid.Parse("50f0b6ee-ba6e-f988-4f3b-79c85308ed25"));
poll.VoteTo(Guid.Parse("50f0b6ee-ba6e-f988-4f3b-79c85308ed25"));
poll.VoteTo(Guid.Parse("b253b82c-90a1-2183-4053-48f910a49247"));
poll.VoteTo(Guid.Parse("b253b82c-90a1-2183-4053-48f910a49247"));
poll.VoteTo(Guid.Parse("51611623-e72f-0488-4011-be4f13c8e936"));
poll.VoteTo(Guid.Parse("51611623-e72f-0488-4011-be4f13c8e936"));
poll.VoteTo(Guid.Parse("b253b82c-90a1-2183-4053-48f910a49247"));
poll.VoteTo(Guid.Parse("9ebb2234-75cb-eeb2-4fed-1774318d9ce8"));
poll.VoteTo(Guid.Parse("9ebb2234-75cb-eeb2-4fed-1774318d9ce8"));
poll.VoteTo(Guid.Parse("9ebb2234-75cb-eeb2-4fed-1774318d9ce8"));
poll.VoteTo(Guid.Parse("9ebb2234-75cb-eeb2-4fed-1774318d9ce8"), 10);

//var builder = new PollBuilder("Как вам фильм Матрица?")
//    .AddAnswer(Guid.Parse("51611623-e72f-0488-4011-be4f13c8e936"), "Нормально")
//    .AddAnswer(2, "Не плохо")
//    .AddAnswer(3, "Отстой")
//    .AddAnswer(4, "Супер");


//var poll = builder.Build();

//poll.VoteTo(1);
//poll.VoteTo(1);
//poll.VoteTo(2);
//poll.VoteTo(3);
//poll.VoteTo(4);
//poll.VoteTo(4);
//poll.VoteTo(4);
//poll.VoteTo(4, 10);

////хотим поместить в базу данных
//using (var context=new ApplicationDbContext())
//{
//    //сделать конфигурацию в dbcontexte(в режиме памяти, т.к. пока там работаем)
//    context.Polls.Add(poll);
//    context.SaveChanges();

//}
////проверка что записалось в базу
//using (var context = new ApplicationDbContext())
//{
//    foreach(var answer in context.Answers)
//    {
//        Console.WriteLine(answer.Title);
//    }

//}
var result = builder.GetResults(poll);

Console.WriteLine(result.GetView());




//вместо используем FluentInterface
//var poll = new Poll("Как вам фильм Матрица?")
//{

//    Answers=new List<PollAnswer>
//    {
//        new(1,"Нормально"),
//        new(2,"Не плохо"),
//        new(3,"Отстой"),
//        new(4, "Супер")
//    }

//};
////просто выбырием вариант ответа
//poll.VoteTo(1);
//poll.VoteTo(2);
//poll.VoteTo(3);
//poll.VoteTo(4);
//poll.VoteTo(4);
//poll.VoteTo(4);
//poll.VoteTo(4, 10);

//Console.WriteLine(poll);
