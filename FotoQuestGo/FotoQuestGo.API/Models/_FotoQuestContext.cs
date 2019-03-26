using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.API.Models
{
    public class FotoQuestContext : DbContext
    {
        public FotoQuestContext(DbContextOptions<FotoQuestContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    ID = 1,
                    Text = "Question 1"
                },
                new Question
                {
                    ID = 2,
                    Text = "Question 2"
                },
                new Question
                {
                    ID = 3,
                    Text = "Question 3"
                }
            );
        }

        public DbSet<Quest> Quests { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}