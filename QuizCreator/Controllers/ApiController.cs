using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizCreator.Models.Database;
using QuizCreator.Quiz;

namespace QuizCreator.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<HomeController> logger;
        private readonly QuizDbContext context;

        public ApiController(ILogger<HomeController> logger, QuizDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        [Route("api/makefetch/{templateGuid}")]
        public IActionResult MakeFetch(Guid templateGuid)
        {
            var quizMethods = new QuizMethods(context);
            var template = quizMethods.GetTemplate(templateGuid);
            return Ok(template);
        }

        [HttpPost]
        [Route("api/makeupdate")]
        public IActionResult MakeUpdate(Template template)
        {
            var quizMethods = new QuizMethods(context);
            quizMethods.UpdateTemplate(template);
            return Ok();
        }
    }
}
