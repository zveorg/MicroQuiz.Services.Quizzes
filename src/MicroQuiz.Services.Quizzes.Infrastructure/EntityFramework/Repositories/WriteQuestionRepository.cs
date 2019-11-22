using MicroQuiz.Services.Quizzes.Core.Entities;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Infrastructure.EntityFramework.Repositories
{
    public class WriteQuestionRepository : IWriteQuestionRepository
    {
        private readonly WriteDbContext _writeContext;

        public WriteQuestionRepository(WriteDbContext writeContext)
            => _writeContext = writeContext ?? throw new ArgumentNullException(nameof(_writeContext));

        public void Create(Question entity)
        {
            _writeContext.Questions.Add(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _writeContext.Questions.Find(id);
            _writeContext.Questions.Remove(entity);
        }
        public void Update(Question entity)
        {
            _writeContext.Questions.Attach(entity);
            _writeContext.Entry(entity).Property(p => p.Text).IsModified = true;
            _writeContext.Entry(entity).Property(p => p.Answer).IsModified = true;
        }

        public async Task SaveChangesAsync()
        {
            await _writeContext.SaveChangesAsync();
        }
    }
}
