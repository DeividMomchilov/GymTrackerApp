using GymTrackerApp.Data;
using GymTrackerApp.Data.Models;
using GymTrackerApp.ViewModels.ViewModels.Exercise;
using GymTrackerApp.ViewModels.ViewModels.Workout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace GymTrackerApp.Controllers
{
    public class WorkoutsController(ApplicationDbContext dbContext)
        : BaseController
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

            var existingWorkout = await dbContext
                .Workouts
                .FirstOrDefaultAsync(w => w.Title == model.Title && w.CreatorId == GetUserId());

            if (existingWorkout != null)
            {
                ModelState.AddModelError(nameof(model.Title), "You already have a workout with this title.");
                return View(model);
            }

            var workout = new Workout
            {
                Title = model.Title,
                Description = model.Description,
                CreatorId = GetUserId()!
            };

            try
            {
                await dbContext.Workouts.AddAsync(workout);
                await dbContext.SaveChangesAsync();
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
            var workout = await dbContext.Workouts
                .Where(w => w.Id == id && w.CreatorId == GetUserId())
                .FirstOrDefaultAsync();

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

            var workout = await dbContext.Workouts
                .Where(w => w.Id == id && w.CreatorId == GetUserId())
                .FirstOrDefaultAsync();

            if (workout == null)
            {
                ModelState.AddModelError(string.Empty, "Workout not found.");
                return RedirectToAction(nameof(Index));
            }

            try
            {
                workout.Title = model.Title;
                workout.Description = model.Description;

                dbContext.Workouts.Update(workout);
                await dbContext.SaveChangesAsync();
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
            var workout = await dbContext
                .Workouts
                .FirstOrDefaultAsync(w => w.Id == id && w.CreatorId == GetUserId());

            if (workout == null)
            {
                ModelState.AddModelError(string.Empty, "Workout not found.");
                return RedirectToAction(nameof(Index));
            }

            try
            {
                dbContext.Workouts.Remove(workout);
                await dbContext.SaveChangesAsync();
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
            var workout = await dbContext
                .Workouts
                .Include(w => w.WorkoutExercises)
                .ThenInclude(we => we.Exercise)
                .ThenInclude(e => e.Muscle)
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.Id == id && w.CreatorId == GetUserId());

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
        public async Task<IActionResult> AddExercise(int workoutId)
        {
            var workout = await dbContext.Workouts
                .Where(w => w.Id == workoutId && w.CreatorId == GetUserId())
                .FirstOrDefaultAsync();

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
                    .AsNoTracking()
                    .ToListAsync()
            };

            return RedirectToAction(nameof(Details), new { id = workoutId });
        }

        [HttpPost]
        public async Task<IActionResult> AddExercise(int workoutId, WorkoutExerciseFormViewModel model)
        {
            var workout = await dbContext.Workouts
                .Where(w => w.Id == workoutId && w.CreatorId == GetUserId())
                .FirstOrDefaultAsync();

            if (workout == null)
            {
                ModelState.AddModelError(string.Empty, "Workout not found.");
                return RedirectToAction(nameof(Index));
            }

            if(workout.WorkoutExercises.Any(we => we.ExerciseId == model.ExerciseId))
            {
                ModelState.AddModelError(string.Empty, "This exercise is already in your workout.");
                model.AvailableExercises = await GetExercises();
                return View(model);
            }

            var workoutExercise = new WorkoutExercise
            {
                WorkoutId = workoutId,
                ExerciseId = model.ExerciseId,
                Sets = model.Sets,
                Reps = model.Reps,
                Weight = model.Weight
            };

            try
            {
                await dbContext.WorkoutExercises.AddAsync(workoutExercise);
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while adding the exercise to the workout. Please try again.");
                return RedirectToAction(nameof(Details), new { id = workoutId });
            }

            return RedirectToAction(nameof(Details), new { id = workoutId });
        }

        //Remove Exercise
        [HttpPost]
        public async Task<IActionResult> RemoveExercise(int workoutId, int exerciseId)
        {
            var workout = await dbContext
                .Workouts
                .Where(w => w.Id == workoutId && w.CreatorId == GetUserId())
                .FirstOrDefaultAsync();

            if (workout == null)
            {
                ModelState.AddModelError(string.Empty, "Workout not found.");
                return RedirectToAction(nameof(Index));
            }

            var workoutExercise = await dbContext
                .WorkoutExercises
                .FirstOrDefaultAsync(we => we.WorkoutId == workoutId && we.ExerciseId == exerciseId);

            if(workoutExercise == null)
            {
                ModelState.AddModelError(string.Empty, "Exercise not found in this workout.");
                return RedirectToAction(nameof(Details), new { id = workoutId });
            }

            try
            {
                dbContext.WorkoutExercises.Remove(workoutExercise);
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while removing the exercise from the workout. Please try again.");
            }
            return RedirectToAction(nameof(Details), new { id = workoutId });
        }


        public async Task<IEnumerable<ExerciseViewModel>> GetExercises()
        {
            return await dbContext
                .Exercises
                .AsNoTracking()
                .Select(e => new ExerciseViewModel
                {
                    Id= e.Id,
                    Name = e.Name,
                    MuscleName = e.Muscle.Name
                })
                .OrderBy(e => e.Name)
                .ThenBy(e => e.MuscleName)
                .ToListAsync();
        }
    }
}