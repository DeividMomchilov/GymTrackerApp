using GymTrackerApp.Controllers;
using GymTrackerApp.Services.Contracts;
using GymTrackerApp.ViewModels.ViewModels.Exercise;
using GymTrackerApp.ViewModels.ViewModels.Muscle;
using Microsoft.AspNetCore.Mvc;

namespace GymTrackerApp.Areas.Admin.Controllers
{
    public class MusclesController(IMuscleService muscleService) : BaseAdminController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var muscles = await muscleService.GetAllMusclesAsync();

            List<MuscleViewModel> muscleViewModels = muscles.Select(m => new MuscleViewModel
            {
                Id = m.Id,
                Name = m.Name
            }).ToList();

            return View(muscleViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var muscle = await muscleService.GetMuscleByIdAsync(id);
            var exercises = await muscleService.GetMusclesExercisesAsync(id);

            var model = new MuscleDetailsViewModel
            {
                Id = muscle.Id,
                Name = muscle.Name,
                Exercises = exercises.Select(e => new ExerciseViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    ImageUrl = e.ImageUrl,
                    MuscleName = muscle.Name,
                    CreatorId = e.CreatorId
                })
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var muscle = await muscleService.GetMuscleByIdAsync(id);

            if (muscle == null)
                return NotFound();

            var model = new MuscleDetailsViewModel
            {
                Id = muscle.Id,
                Name = muscle.Name
            };

            // TODO: Add a view for muscle edit
            return Ok(model);
        }

        // TODO: Implement Edit POST action

    }
}