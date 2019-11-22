using AutoMapper;
using MediatR;
using MicroQuiz.Services.Quizzes.Core.Dtos;
using MicroQuiz.Services.Quizzes.Core.Extensions;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using MicroQuiz.Services.Quizzes.Core.Queries;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Application.QueryHandlers
{
    public class GetQuizListQueryHandler : IRequestHandler<GetQuizListQuery, QuizListDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadQuizRepository _readQuizRepository;

        public GetQuizListQueryHandler(IMapper mapper, IReadQuizRepository readQuizRepository)
        {
            _mapper = mapper.ThrowIfNull(nameof(mapper));
            _readQuizRepository = readQuizRepository.ThrowIfNull(nameof(readQuizRepository));
        }

        public async Task<QuizListDto> Handle(GetQuizListQuery request, CancellationToken cancellationToken)
        {
            var list = await _readQuizRepository.GetListAsync();

            var dtos = list
                .Select(entity => _mapper.Map<QuizDto>(entity));

            return new QuizListDto { QuizList = dtos };
        }
    }
}
