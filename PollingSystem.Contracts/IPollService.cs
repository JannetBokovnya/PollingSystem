using Calabonga.OperationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PollingSystem.Contracts
{
    //это верхнеуровневая сборка, в которой есть сервис IPollService
    //этот сервис используется в BlazorLib (т.е. мы нажимаем кнопку сохранить)
    // а реализация в application PollingSystem.Web в Pollservice (имплементация)
    public interface IPollService
    {
        //сохранение Task, question -сохранение в базе данных
        Task<OperationResult<SaveResult>> SaveAsync(string question, List<string> answers, CancellationToken cancellationToken);
    }
}
