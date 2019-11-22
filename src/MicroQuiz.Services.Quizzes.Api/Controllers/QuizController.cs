using MediatR;
using MicroQuiz.Services.Quizzes.Core.Commands;
using MicroQuiz.Services.Quizzes.Core.Dtos;
using MicroQuiz.Services.Quizzes.Core.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Api.Controllers
{
    [ApiController, Route("api/[controller]/[action]")]
    public class QuizController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuizController(IMediator mediator) =>
            _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> List(GetQuizListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetQuizByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuizCommand createQuizCommand)
        {
            await _mediator.Send(createQuizCommand);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateQuizCommand updateQuizCommand)
        {
            if (id != updateQuizCommand.Id)
                return BadRequest();

            await _mediator.Send(updateQuizCommand);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteQuizCommand(id));
            return Ok();
        }
    }
}