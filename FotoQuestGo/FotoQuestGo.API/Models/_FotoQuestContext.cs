using FotoQuestGo.API.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace FotoQuestGo.API.Quest.Context
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

        public DbSet<Common.Models.Quest> Quests { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}