using Dommel;
using MicroQuiz.Services.Quizzes.Core.Entities;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Infrastructure.Dapper.Repositories
{
    public class ReadQuizRepository : IReadQuizRepository
    {
        private readonly ReadDbContext _readContext;

        public ReadQuizRepository(ReadDbContext readContext)
            => _readContext = readContext;

        public async Task<IEnumerable<Quiz>> GetListAsync()
        {
            return await _readContext
                .Connection
                .GetAllAsync<Quiz>();
        }

        public async Task<Quiz> GetByIdAsync(Guid id)
        {
            return await _readContext
                .Connection
                .GetAsync<Quiz>(id);            
        }

        public async Task<IEnumerable<Quiz>> GetByIdOrNameAsync(Guid id, string name)
        {
            return await _readContext
                .Connection
                .SelectAsync<Quiz>(i => i.Id == id || i.Name == name);
        }
    }
}
