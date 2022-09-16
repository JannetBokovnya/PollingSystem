using PollingSystem.Contracts;
using PollingSystem.Entities;
using PollingSystem.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Calabonga.OperationResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PollingSystem.Web.Infrastructure
{
    public class PollService : IPollService
    {
        public PollService(ApplicationDbContext context)
        {
            _context=context;
            _dbSet = _context.Set<Poll>();
        }
        public ApplicationDbContext _context { get; }
        private readonly DbSet<Poll> _dbSet;

        //public async Task<bool> SaveAsync(string question, List<string> answers)
        //{


        //}

        public async Task<OperationResult<SaveResult>> SaveAsync(string question, List<string> answers, CancellationToken cancellationToken)
        {
            var answersForPoll = answers.Select(x => new PollAnswer(Guid.Empty, x)).ToList();
            var poll = new Poll(question, answersForPoll);
           

        //сщхранение в базу
        _context.Add(poll);
            
            await _dbSet.AddAsync(poll, cancellationToken);
            var operation = OperationResult.CreateResult<SaveResult>();
            //begin моделирование ошибки
            //operation.AddError(new NotImplementedException("WRONG WAY"));
            //return operation;
            //end моделирование ошибки

            try
            {
                await _context.SaveChangesAsync();
                
                operation.Result=new SaveResult
                {
                    TotalPolls= await CountAsync(null, cancellationToken)
                };
                operation.AddSuccess("Успешно сохранено новое голосование");
                return operation;


            }
            catch (Exception ex)
            {
                operation.AddError(ex ?? new InvalidOperationException());
                return operation;
            }

            
        }

        public async Task<int> CountAsync(
       Expression<Func<Poll, bool>>? predicate = null,
       CancellationToken cancellationToken = default) =>
       predicate is null
           ? await _dbSet.CountAsync(cancellationToken)
           : await _dbSet.CountAsync(predicate, cancellationToken);
    }
}
