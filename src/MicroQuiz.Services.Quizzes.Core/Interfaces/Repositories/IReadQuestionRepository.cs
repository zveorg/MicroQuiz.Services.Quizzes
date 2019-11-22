using MicroQuiz.Services.Quizzes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories
{
    public interface IReadQuestionRepository : IReadRepository<Question>
    {
        Task<IEnumerable<Question>> GetByQuizIdAsync(Guid id);
    }
}
