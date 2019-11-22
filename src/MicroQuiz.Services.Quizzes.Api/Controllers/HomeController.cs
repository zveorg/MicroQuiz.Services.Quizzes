using Microsoft.AspNetCore.Mvc;

namespace MicroQuiz.Services.Quizzes.Api.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("MicroQuiz Quiz Service");
    }
}