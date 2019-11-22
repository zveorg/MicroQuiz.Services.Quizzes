using MicroQuiz.Services.Quizzes.Core.Entities;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Infrastructure.EntityFramework.Repositories
{
    public class WriteQuizRepository : IWriteQuizRepository
    {
        private readonly WriteDbContext _writeContext;

        public WriteQuizRepository(WriteDbContext writeContext)
            => _writeContext = writeContext ?? throw new ArgumentNullException(nameof(_writeContext));

        public void Create(Quiz entity)
        {
            _writeContext.Quizzes.Add(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _writeContext.Quizzes.Find(id);
            _writeContext.Quizzes.Remove(entity);           
        }

        public void Update(Quiz entity)
        {
            _writeContext.Quizzes.Attach(entity);
            _writeContext.Entry(entity).Property(p => p.Name).IsModified = true;
            _writeContext.Entry(entity).Property(p => p.Description).IsModified = true;
            _writeContext.Entry(entity).Property(p => p.Enabled).IsModified = true;
        }

        public async Task SaveChangesAsync()
        {
            await _writeContext.SaveChangesAsync();
        }
    }
}
