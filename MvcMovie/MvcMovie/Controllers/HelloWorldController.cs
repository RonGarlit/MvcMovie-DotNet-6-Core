using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    // Get started with ASP.NET Core MVC
    // https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc

    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}