using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollingSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingSystem.Application.ModelConfiguration
{
    //конфигурация сущности Poll
    public class PolModelConfiguration : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            //настройки базы данных по Answer и положем в базу данных
            builder.ToTable("Polls");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
           
            builder.Property(x => x.QuestionText).IsRequired().HasMaxLength(512);
            builder.HasMany(x => x.Answers);
        }
    }
}
