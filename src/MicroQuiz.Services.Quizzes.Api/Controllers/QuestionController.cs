using MediatR;
using MicroQuiz.Services.Quizzes.Core.Commands;
using MicroQuiz.Services.Quizzes.Core.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Api.Controllers
{
    [ApiController, Route("api/[controller]/[action]")]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator) =>
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("{id}")]
        public async Task<IActionResult> Quiz(Guid id)
        {
            var result = await _mediator.Send(new GetQuizQuestionListQuery(id));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetQuestionByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionCommand createQuizCommand)
        {
            await _mediator.Send(createQuizCommand);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateQuestionCommand updateQuizCommand)
        {
            if (id != updateQuizCommand.Id)
                return BadRequest();

            await _mediator.Send(updateQuizCommand);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteQuestionCommand(id));
            return Ok();
        }
    }
}