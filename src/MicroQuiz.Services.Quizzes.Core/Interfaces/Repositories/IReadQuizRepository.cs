using MicroQuiz.Services.Quizzes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories
{
    public interface IReadQuizRepository : IReadRepository<Quiz>
    {
        Task<IEnumerable<Quiz>> GetListAsync();
        Task<IEnumerable<Quiz>> GetByIdOrNameAsync(Guid id, string name);
    }
}
