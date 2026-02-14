using GymTrackerApp.Data;
using GymTrackerApp.Data.Models;
using GymTrackerApp.ViewModels.ViewModels.Workout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerApp.Controllers
{
    [Authorize]
    public class WorkoutsController(ApplicationDbContext dbContext) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var workouts = await dbContext.Workouts
                .Where(w => w.CreatorId == GetUserId())
                .Select(w => new WorkoutViewModel
                {
                    Id = w.Id,
                    Title = w.Title,
                    Description = w.Description
                })
                .AsNoTracking()
                .ToListAsync();

            return View(workouts);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new WorkoutFormViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkoutFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var workout = new Workout
            {
                Title = model.Title,
                Description = model.Description,
                CreatorId = GetUserId()!
            };       

            var existingWorkout = await dbContext
                .Workouts
                .FirstOrDefaultAsync(w => w.Title == model.Title && w.CreatorId == GetUserId());

            if (existingWorkout != null)
            {
                ModelState.AddModelError(nameof(model.Title), "You already have a workout with this title.");
                return View(model);
            }

            await dbContext.Workouts.AddAsync(workout);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}