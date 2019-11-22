using Dapper.FluentMap.Dommel.Mapping;
using MicroQuiz.Services.Quizzes.Core.Entities;

namespace MicroQuiz.Services.Quizzes.Infrastructure.Dapper.Configuration
{
    public class QuestionMap : DommelEntityMap<Question>
    {
        public QuestionMap()
        {
            ToTable("Questions");
            Map(p => p.Id).IsKey();
        }
    }
}
