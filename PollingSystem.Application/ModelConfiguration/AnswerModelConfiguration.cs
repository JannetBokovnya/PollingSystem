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
    //для настроек сущностей, которые будут храниться в базе данных
    public class AnswerModelConfiguration : IEntityTypeConfiguration<PollAnswer>
    {
        public void Configure(EntityTypeBuilder<PollAnswer> builder)
        {
            //настройки базы данных по Answer и положем в базу данных
            builder.ToTable("Answers");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Percents);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(512);
            builder.Property(x => x.Votes);
        }
    }
}
