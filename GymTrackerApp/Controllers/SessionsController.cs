using GymTrackerApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GymTrackerApp.Controllers
{
    public class SessionsController(ISessionService sessionService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sessions = await sessionService.LogUserSessionsAsync(GetUserId()!);

            return View(sessions);
        }

        [HttpPost]
        public async Task<IActionResult> LogSession(int workoutId, int duration = 60)
        {
            await sessionService.LogSessionAsync(workoutId, GetUserId()!, duration);
            TempData["SuccessMessage"] = "Workout logged successfully! Great job!";
            return RedirectToAction(nameof(Index));
        }
    }
}