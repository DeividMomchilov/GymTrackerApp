using GymTrackerApp.Data;
using GymTrackerApp.Data.Models;
using GymTrackerApp.Services;
using GymTrackerApp.Services.Contracts;
using GymTrackerApp.ViewModels.ViewModels;
using GymTrackerApp.ViewModels.ViewModels.Exercise;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerApp.Controllers
{
    public class ExercisesController(IExerciseService exerciseService) 
        : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var exercises = await exerciseService.GetAllExercisesAsync();

            return View(exercises);
        }

        //Add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ExerciseFormViewModel
            {
                Muscles = await exerciseService.GetMusclesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExerciseFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Muscles = await exerciseService.GetMusclesAsync();
                return View(model);
            }

            var existingExercise = await exerciseService.GetExerciseByNameAsync(model.Name);

            if (existingExercise != null)
            {
                ModelState.AddModelError(nameof(model.Name), "An exercise with this name already exists.");
                model.Muscles = await exerciseService.GetMusclesAsync();
                return View(model);
            }

            try
            {
                await exerciseService.AddExerciseAsync(model,GetUserId()!);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving the exercise. Please try again.");
                model.Muscles = await exerciseService.GetMusclesAsync();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        //Details
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var exercise = await exerciseService.GetExerciseByIdAsyncWithMusclesIncluded(id);

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
            var exercise = await exerciseService.GetExerciseByIdAsyncWithMusclesIncluded(id);

            if (exercise?.CreatorId != GetUserId())
                return Unauthorized();

            if (exercise == null)
                return NotFound();

            var model = new ExerciseFormViewModel
            {
                Name = exercise.Name,
                Description = exercise.Description,
                ImageUrl = exercise.ImageUrl,
                MuscleId = exercise.MuscleId,
                Muscles = await exerciseService.GetMusclesAsync()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, ExerciseFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Muscles = await exerciseService.GetMusclesAsync();
                return View("Add", model);
            }

            var exercise = await exerciseService.GetExerciseByIdAsync(id);

            if (exercise?.CreatorId != GetUserId())
                return Unauthorized();

            if (exercise == null)
                return NotFound();

            try
            {
                await exerciseService.EditExerciseAsync(id, model);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving the exercise. Please try again.");
                model.Muscles = await exerciseService.GetMusclesAsync();
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        //Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var exercise = await exerciseService.GetExerciseByIdAsync(id);

            if (exercise == null)
                return NotFound();

            if (exercise.CreatorId != GetUserId())
                return Unauthorized();

            try
            {
                await exerciseService.DeleteExerciseAsync(id);
            }
            catch (DbUpdateException)
            {
                TempData["ErrorMessage"] = "Cannot delete this exercise because it is part of a workout. Remove it from all workouts first.";
                return RedirectToAction(nameof(Details), new { id });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}