using System;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class
    {
        void Create(T entity);
        void Delete(Guid id);
        void Update(T entity);
        Task SaveChangesAsync();
    }
}
