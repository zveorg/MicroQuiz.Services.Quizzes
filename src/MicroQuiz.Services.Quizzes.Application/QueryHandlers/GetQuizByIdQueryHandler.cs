using AutoMapper;
using MediatR;
using MicroQuiz.Services.Quizzes.Core.Dtos;
using MicroQuiz.Services.Quizzes.Core.Extensions;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using MicroQuiz.Services.Quizzes.Core.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Application.QueryHandlers
{
    public class GetQuizByIdQueryHandler : IRequestHandler<GetQuizByIdQuery, QuizDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadQuizRepository _readQuizRepository;
        private readonly IReadQuestionRepository _readQuestionRepository;

        public GetQuizByIdQueryHandler(IMapper mapper, IReadQuizRepository readQuizRepository, IReadQuestionRepository readQuestionRepository)
        {
            _mapper = mapper.ThrowIfNull(nameof(mapper));
            _readQuizRepository = readQuizRepository.ThrowIfNull(nameof(readQuizRepository));
            _readQuestionRepository = readQuestionRepository.ThrowIfNull(nameof(readQuestionRepository));
        }

        public async Task<QuizDto> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
            var entity =  await _readQuizRepository.GetByIdAsync(request.Id);
            if (entity == null) return null;

            var dto = _mapper.Map<QuizDto>(entity);
            var questions = await _readQuestionRepository.GetByQuizIdAsync(request.Id);
            dto.QuestionCount = questions.Count();

            return dto;
        }
    }
}
