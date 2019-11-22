using Dommel;
using MicroQuiz.Services.Quizzes.Core.Entities;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Infrastructure.Dapper.Repositories
{
    public class ReadQuestionRepository : IReadQuestionRepository
    {
        private readonly ReadDbContext _readContext;

        public ReadQuestionRepository(ReadDbContext readContext)
            => _readContext = readContext;


        public async Task<Question> GetByIdAsync(Guid id)
        {
            return await _readContext
                .Connection
                .GetAsync<Question>(id);
        }

        public async Task<IEnumerable<Question>> GetByQuizIdAsync(Guid id)
        {
            return await _readContext
                .Connection
                .SelectAsync<Question>(i => i.QuizId == id);
        }
    }
}
