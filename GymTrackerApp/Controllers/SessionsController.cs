using GymTrackerApp.Services.Contracts;
using GymTrackerApp.ViewModels.ViewModels.Session;
using Microsoft.AspNetCore.Mvc;

namespace GymTrackerApp.Controllers
{
    public class SessionsController(ISessionService sessionService) : BaseController
    {
        private const int PageSize = 15;
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, string search = "")
        {
            int totalCount = await sessionService.GetTotalSessionsCountAsync(GetUserId()!, search);
            var sessions = await sessionService.GetSessionsAsync(GetUserId()!,page,PageSize, search);
            int totalPages = (int)Math.Ceiling((double)totalCount / PageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Search = search;

            return View(sessions);
        }

        [HttpPost]
        public async Task<IActionResult> LogSession(WorkoutSessionFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid data. Please check your input.";
                return RedirectToAction("Details", "Workouts", new { id = model.WorkoutId });
            }

            await sessionService.LogSessionAsync(model, GetUserId()!);
            TempData["SuccessMessage"] = "Workout logged successfully! Great job!";
            return RedirectToAction(nameof(Index));
        }
    }
}