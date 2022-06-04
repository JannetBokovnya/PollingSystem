﻿using Microsoft.EntityFrameworkCore;
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

        ////т.к. работаем в режиме памяти то можно конфигурацию сделать override

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("In-MEMORY");
        //}
    }
# nullable enable
}
