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
        private const int PageSize = 9;

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1,string search = "")
        {
            var exercises = await exerciseService.GetExercisesPaginatedAndFilterdAsync(page, PageSize,search);
            int totalCount = await exerciseService.GetTotalExercisesCountAsync(search);
            int totalPages = (int)Math.Ceiling((double)totalCount / PageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Search = search;

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
                TempData["ErrorMessage"] = "Please correct the errors in the form.";
                model.Muscles = await exerciseService.GetMusclesAsync();
                return View(model);
            }

            var existingExercise = await exerciseService.GetExerciseByNameAsync(model.Name);

            if (existingExercise != null)
            {
                TempData["ErrorMessage"] = "An exercise with this name already exists. Please choose a different name.";
                model.Muscles = await exerciseService.GetMusclesAsync();
                return View(model);
            }

            try
            {
                await exerciseService.AddExerciseAsync(model,GetUserId()!);
                TempData["SuccessMessage"] = "Exercise added successfully.";
            }
            catch (DbUpdateException)
            {
                TempData["ErrorMessage"] = "An error occurred while adding the exercise. Please try again.";
                model.Muscles = await exerciseService.GetMusclesAsync();
                return View(model);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"An unexpected error occurred: {ex.Message}";
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

            if (exercise == null)
                return NotFound();

            if (exercise?.CreatorId != GetUserId() && !User.IsInRole("Admin"))
                return Unauthorized();

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
                TempData["ErrorMessage"] = "Please correct the errors in the form.";
                model.Muscles = await exerciseService.GetMusclesAsync();
                return View("Add", model);
            }

            var exercise = await exerciseService.GetExerciseByIdAsync(id);

            if (exercise == null)
                return NotFound();

            if (exercise?.CreatorId != GetUserId() && !User.IsInRole("Admin"))
                return Unauthorized();

            try
            {
                await exerciseService.EditExerciseAsync(id, model);
                TempData["SuccessMessage"] = "Exercise updated successfully.";
            }
            catch (DbUpdateException)
            {
                TempData["ErrorMessage"] = "An error occurred while updating the exercise. Please try again.";
                model.Muscles = await exerciseService.GetMusclesAsync();
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An unexpected error occurred: {ex.Message}";
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

            if (exercise?.CreatorId != GetUserId() && !User.IsInRole("Admin"))
                return Unauthorized();

            try
            {
                await exerciseService.DeleteExerciseAsync(id);
                TempData["SuccessMessage"] = "Exercise deleted successfully.";
            }
            catch (DbUpdateException)
            {
                TempData["ErrorMessage"] = "Cannot delete this exercise because it is part of a workout. Remove it from all workouts first.";
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An unexpected error occurred: {ex.Message}";
                return RedirectToAction(nameof(Details), new { id });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}