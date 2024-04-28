#region Using Directives
using Microsoft.AspNetCore.Mvc;
using QuizCreator.Models;
using System.Diagnostics;
using CSharpVitamins;
using QuizCreator.Models.Database;
using QuizCreator.Models.Home;
using QuizCreator.Quiz;
#endregion

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
            try
            {
                logger.LogDebug("Called Create method");

                var quizMethods = new QuizMethods(context);
                var templateGuid = quizMethods.CreateTemplate();
                var templateSguid = ShortGuid.Encode(templateGuid);

                return RedirectToAction("Make", new { templateSguid });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in Create method");
                throw;
            }
        }

        [Route("/make/{templateSguid}")]
        public IActionResult Make(string templateSguid)
        {
            try
            {
                logger.LogDebug("Called Make method");

                var createModel = new CreateModel
                {
                    TemplateGuid = ShortGuid.Decode(templateSguid)
                };
                return View(createModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in Make method");
                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}