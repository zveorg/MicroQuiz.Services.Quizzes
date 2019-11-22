using MicroQuiz.Services.Quizzes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroQuiz.Services.Quizzes.Infrastructure.EntityFramework.Configuration
{
    internal class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> entity)
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.QuizId);

            entity.HasOne(d => d.Quiz)
                .WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId);

            entity.Property(e => e.Answer)
                .HasMaxLength(30)
                .IsRequired();

            entity.Property(e => e.Text)
                .HasMaxLength(300)
                .IsRequired();

            entity.Property(e => e.Text)
                .IsRequired();
        }
    }
}
