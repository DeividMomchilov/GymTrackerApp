using System.Linq;
using System.Threading.Tasks;
using GymTrackerApp.Services.Contracts;
using GymTrackerApp.ViewModels.ViewModels.Exercise;
using GymTrackerApp.ViewModels.ViewModels.Muscle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymTrackerApp.Controllers
{
    public class MusclesController(IMuscleService muscleService) : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var muscles = await muscleService.GetAllMusclesAsync();

            return View(muscles);
        }

        [HttpGet]
        [AllowAnonymous]
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
    }
}
