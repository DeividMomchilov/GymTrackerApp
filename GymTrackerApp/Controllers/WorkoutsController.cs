using GymTrackerApp.Data;
using GymTrackerApp.Data.Models;
using GymTrackerApp.Services.Contracts;
using GymTrackerApp.ViewModels.ViewModels.Exercise;
using GymTrackerApp.ViewModels.ViewModels.Workout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace GymTrackerApp.Controllers
{
    public class WorkoutsController(ApplicationDbContext dbContext, IWorkoutService workoutService)
        : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var workouts = await workoutService
                .GetWorkoutsForTheCurrentUserAsync(GetUserId()!);

            return View(workouts);
        }

        //Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new WorkoutFormViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkoutFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existingWorkout = await workoutService
                .GetWorkoutByTitleAndCreatorIdAsync(model, GetUserId()!);

            if (existingWorkout != null)
            {
                ModelState.AddModelError(nameof(model.Title), "You already have a workout with this title.");
                return View(model);
            }

            try
            {
                await workoutService.CreateWorkoutAsync(model, GetUserId()!);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving the workout. Please try again.");
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        //Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var workout = await workoutService
                .GetSpecificWorkoutByIdAndCreatorIdAsync(id,GetUserId()!);

            if (workout == null)
            {
                ModelState.AddModelError(string.Empty, "Workout not found.");
                return RedirectToAction(nameof(Index));
            }

            var model = new WorkoutFormViewModel
            {
                Title = workout.Title,
                Description = workout.Description
            };

            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, WorkoutFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var workout = await workoutService
                .GetSpecificWorkoutByIdAndCreatorIdAsync(id, GetUserId()!);

            if (workout == null)
            {
                ModelState.AddModelError(string.Empty, "Workout not found.");
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await workoutService.EditWorkoutAsync(workout, model);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the workout. Please try again.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        //Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var workout = await workoutService
                .GetSpecificWorkoutByIdAndCreatorIdAsync(id, GetUserId()!);

            if (workout == null)
            {
                ModelState.AddModelError(string.Empty, "Workout not found.");
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await workoutService.DeleteWorkoutAsync(workout);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the workout. Please try again.");
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        //Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var workout = await workoutService
                .GetDetailedWorkoutAsync(id,GetUserId()!);

            if (workout == null)
            {
                ModelState.AddModelError(string.Empty, "Workout not found.");
                return RedirectToAction(nameof(Index));
            }

            var model = new WorkoutDetailsViewModel
            {
                Id = workout.Id,
                Title = workout.Title,
                Description = workout.Description,
                Exercises = workout.WorkoutExercises.Select(we => new WorkoutExerciseViewModel
                {
                    ExerciseId = we.ExerciseId,
                    ExerciseName = we.Exercise.Name,
                    MuscleName = we.Exercise.Muscle.Name,
                    Sets = we.Sets,
                    Reps = we.Reps,
                    Weight = we.Weight,
                }).ToList()
            };

            return View(model);
        }

        //Add Exercise
        [HttpGet]
        public async Task<IActionResult> AddExercise(int id)
        {
            var workout = await workoutService
                .GetSpecificWorkoutByIdAndCreatorIdAsync(id, GetUserId()!);

            if (workout == null)
            {
                ModelState.AddModelError(string.Empty, "Workout not found.");
                return RedirectToAction(nameof(Index));
            }

            var model = new WorkoutExerciseFormViewModel
            {
                WorkoutId = workout.Id,
                WorkoutTitle = workout.Title,
                AvailableExercises = await dbContext.Exercises
                    .Select(e => new ExerciseViewModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        MuscleName = e.Muscle.Name
                    })
                    .ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddExercise(int id, WorkoutExerciseFormViewModel model)
        {
            var workout = await workoutService
                .GetSpecificWorkoutByIdAndCreatorIdAsync(id, GetUserId()!);

            if (workout == null)
            {
                ModelState.AddModelError(string.Empty, "Workout not found.");
                return RedirectToAction(nameof(Index));
            }

            if(workout.WorkoutExercises.Any(we => we.ExerciseId == model.ExerciseId))
            {
                ModelState.AddModelError(string.Empty, "This exercise is already in your workout.");
                model.AvailableExercises = await workoutService.GetExercisesAsync();
                return View(model);
            }

            try
            {
                await workoutService.AddExerciseToWorkoutAsync(model);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while adding the exercise to the workout. Please try again.");
                return RedirectToAction(nameof(Details), new { id = id });
            }

            return RedirectToAction(nameof(Details), new { id = id });
        }

        //Remove Exercise
        [HttpPost]
        public async Task<IActionResult> RemoveExercise(int workoutId, int exerciseId)
        {
            var workout = await workoutService
                .GetSpecificWorkoutByIdAndCreatorIdAsync(workoutId, GetUserId()!);

            if (workout == null)
            {
                ModelState.AddModelError(string.Empty, "Workout not found.");
                return RedirectToAction(nameof(Index));
            }

            var workoutExercise = await workoutService.GetWorkoutExerciseAsync(workoutId, exerciseId);

            if (workoutExercise == null)
            {
                ModelState.AddModelError(string.Empty, "Exercise not found in this workout.");
                return RedirectToAction(nameof(Details), new { id = workoutId });
            }

            try
            {
                await workoutService.RemoveExerciseFromWorkoutAsync(workoutExercise);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while removing the exercise from the workout. Please try again.");
            }
            return RedirectToAction(nameof(Details), new { id = workoutId });
        }
    }
}