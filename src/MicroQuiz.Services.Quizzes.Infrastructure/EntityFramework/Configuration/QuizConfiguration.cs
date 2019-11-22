using MicroQuiz.Services.Quizzes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroQuiz.Services.Quizzes.Infrastructure.EntityFramework.Configuration
{
    internal class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> entity)
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id);

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsRequired();

            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}
