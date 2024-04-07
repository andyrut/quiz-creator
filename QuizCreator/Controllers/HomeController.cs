using Microsoft.AspNetCore.Mvc;
using QuizCreator.Models;
using System.Diagnostics;
using CSharpVitamins;
using QuizCreator.Models.Database;
using QuizCreator.Models.Home;
using QuizCreator.Quiz;

namespace QuizCreator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly QuizDbContext context;

        public HomeController(ILogger<HomeController> logger, QuizDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/create")]
        public IActionResult Create()
        {
            var quizMethods = new QuizMethods(context);
            var template = quizMethods.CreateTemplate();
            var templateSguid = ShortGuid.Encode(template.TemplateGuid);

            return RedirectToAction("Make", new {templateSguid});
        }

        [Route("/make/{templateSguid}")]
        public IActionResult Make(string templateSguid)
        {
            var createModel = new CreateModel
            {
                TemplateGuid = ShortGuid.Decode(templateSguid)
            };
            return View(createModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
