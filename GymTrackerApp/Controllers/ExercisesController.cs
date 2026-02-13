using Microsoft.AspNetCore.Mvc;

namespace GymTrackerApp.Controllers
{
    public class ExercisesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
