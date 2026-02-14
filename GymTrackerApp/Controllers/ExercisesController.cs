using GymTrackerApp.Data;
using GymTrackerApp.Data.Models;
using GymTrackerApp.ViewModels.ViewModels;
using GymTrackerApp.ViewModels.ViewModels.Exercise;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerApp.Controllers
{
    [Authorize]
    public class ExercisesController(ApplicationDbContext dbContext) 
        : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var exercises = await dbContext
                .Exercises
                .Include(e => e.Muscle)
                .AsNoTracking()
                .Select(e => new ExerciseViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    ImageUrl = e.ImageUrl,
                    MuscleName = e.Muscle.Name,
                    CreatorId = e.CreatorId
                })
                .OrderBy(e => e.Name)
                .ToListAsync();

            return View(exercises);
        }


        //Add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ExerciseFormViewModel
            {
                Muscles = await GetMuscles()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExerciseFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Muscles = await GetMuscles();
                return View(model);
            }

            var existingExercise = await dbContext
                .Exercises
                .FirstOrDefaultAsync(e => e.Name.ToLower() == model.Name.ToLower());

            if (existingExercise != null)
            {
                ModelState.AddModelError(nameof(model.Name), "An exercise with this name already exists.");
                model.Muscles = await GetMuscles();
                return View(model);
            }

            var exercise = new Exercise
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                MuscleId = dbContext.Muscles.FirstOrDefault(m => m.Id == model.MuscleId)?.Id ?? 0,
                CreatorId = GetUserId()!
            };

            try
            {
                await dbContext.Exercises.AddAsync(exercise);
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving the exercise. Please try again.");
                model.Muscles = await GetMuscles();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        //Details
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var exercise = await dbContext
                .Exercises
                .Include(e => e.Muscle)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            if (exercise == null)
                return NotFound();

            var model = new ExerciseViewModel
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Description = exercise.Description,
                ImageUrl = exercise.ImageUrl,
                MuscleName = exercise.Muscle.Name,
                CreatorId = exercise.CreatorId
            };
            return View(model);
        }


        //Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var exercise = await dbContext
                .Exercises
                .Include(e => e.Muscle)
                .FirstOrDefaultAsync(e => e.Id == id);

            var userId = GetUserId();
             if (exercise?.CreatorId != userId)
               return Unauthorized();

            if (exercise == null)
                return NotFound();

            var model = new ExerciseFormViewModel
            {
                Name = exercise.Name,
                Description = exercise.Description,
                ImageUrl = exercise.ImageUrl,
                MuscleId = exercise.MuscleId,
                Muscles = await GetMuscles()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, ExerciseFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Muscles = await GetMuscles();
                return View("Add", model);
            }

            var exercise = await dbContext
                .Exercises
                .FirstOrDefaultAsync(e => e.Id == id);

            var userId = GetUserId();
            if (exercise?.CreatorId != userId)
                return Unauthorized();

            if (exercise == null)
                return NotFound();

            try
            {
                exercise.Name = model.Name;
                exercise.Description = model.Description;
                exercise.ImageUrl = model.ImageUrl;
                exercise.MuscleId = dbContext.Muscles.FirstOrDefault(m => m.Id == model.MuscleId)?.Id ?? 0;
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving the exercise. Please try again.");
                model.Muscles = await GetMuscles();
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        //Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var exercise = await dbContext
                .Exercises
                .FindAsync(id);

            if (exercise == null)
                return NotFound();

            var userId = GetUserId();
            if (exercise.CreatorId != userId)
                return Unauthorized();

            try
            {
                dbContext.Exercises.Remove(exercise);
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the exercise. Please try again.");
                return RedirectToAction(nameof(Details), new { id });
            }

            return RedirectToAction(nameof(Index));
        }

        //Helper method
        private async Task<IEnumerable<MuscleViewModel>> GetMuscles()
        {
            return await dbContext
                .Muscles
                .AsNoTracking()
                .Select(m => new MuscleViewModel
                {
                    Id = m.Id,
                    Name = m.Name
                })
                .OrderBy(m => m.Name)
                .ToListAsync();
        }
    }
}