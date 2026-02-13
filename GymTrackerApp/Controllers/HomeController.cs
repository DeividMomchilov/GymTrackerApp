using System.Diagnostics;
using GymTrackerApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymTrackerApp.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
