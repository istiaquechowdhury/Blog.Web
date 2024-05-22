using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Diagnostics;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
       
        private readonly IMembership _Membership;

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, IMembership membership)
        {
            _logger = logger;
            _emailSender = emailSender;
          
            _Membership = membership;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("index");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            TestModel testModel = new TestModel();

            return View(testModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Test(TestModel testModel)
        {
            if (ModelState.IsValid)
            {
                _emailSender.SendEmail("hello", "hello", "helo");
               
            }

            return View(testModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
