using Microsoft.EntityFrameworkCore;
using PollingSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingSystem.Application
{
    //база данных
    //отключена проверка на null
# nullable disable
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Poll> Polls { get; set; }

        public DbSet<PollAnswer> Answers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        //конфигурация таблиц в базе, потом вызываем update-database
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        ////т.к. работаем в режиме памяти то можно конфигурацию сделать override подключаем пакет inmemory

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("In-MEMORY");
        //}
    }
# nullable enable
}
