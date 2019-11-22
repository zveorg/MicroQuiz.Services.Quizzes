using System;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
    }
}
