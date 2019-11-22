using AutoMapper;
using MediatR;
using MicroQuiz.Services.Quizzes.Core.Dtos;
using MicroQuiz.Services.Quizzes.Core.Extensions;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using MicroQuiz.Services.Quizzes.Core.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Application.QueryHandlers
{
    public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, QuestionDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadQuestionRepository _readQuestionRepository;

        public GetQuestionByIdQueryHandler(IMapper mapper, IReadQuestionRepository readQuestionRepository)
        {
            _mapper = mapper.ThrowIfNull(nameof(mapper));
            _readQuestionRepository = readQuestionRepository.ThrowIfNull(nameof(readQuestionRepository));
        }

        public async Task<QuestionDto> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _readQuestionRepository.GetByIdAsync(request.Id);
            var dto = _mapper.Map<QuestionDto>(entity);

            return dto;
        }
    }
}
