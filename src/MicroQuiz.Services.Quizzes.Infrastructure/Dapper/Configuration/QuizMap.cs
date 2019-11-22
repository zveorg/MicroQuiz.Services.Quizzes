using Dapper.FluentMap.Dommel.Mapping;
using MicroQuiz.Services.Quizzes.Core.Entities;

namespace MicroQuiz.Services.Quizzes.Infrastructure.Dapper.Configuration
{
    public class QuizMap : DommelEntityMap<Quiz>
    {
        public QuizMap()
        {
            ToTable("Quizzes");
            Map(p => p.Id).IsKey();
        }
    }
}
