using MicroQuiz.Services.Quizzes.Core.Entities;
using MicroQuiz.Services.Quizzes.Infrastructure.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MicroQuiz.Services.Quizzes.Infrastructure.EntityFramework
{
    public class WriteDbContext : DbContext
    {
        public WriteDbContext(DbContextOptions options)
            : base(options) {}

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new QuizConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
        }
    }
}
