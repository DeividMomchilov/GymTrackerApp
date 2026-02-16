using GymTrackerApp.Data;
using GymTrackerApp.Data.Models;
using GymTrackerApp.Services.Contracts;
using GymTrackerApp.ViewModels.ViewModels.Exercise;
using GymTrackerApp.ViewModels.ViewModels.Workout;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.Services
{
    public class WorkoutService(ApplicationDbContext dbContext) : IWorkoutService
    {
        public async Task AddExerciseToWorkoutAsync(WorkoutExerciseFormViewModel model)
        {
            var workoutExercise = new WorkoutExercise
            {
                WorkoutId = model.WorkoutId,
                ExerciseId = model.ExerciseId,
                Sets = model.Sets,
                Reps = model.Reps,
                Weight = model.Weight
            };

            await dbContext.WorkoutExercises.AddAsync(workoutExercise);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateWorkoutAsync(WorkoutFormViewModel model,string userId)
        {
            var workout = new Workout
            {
                Title = model.Title,
                Description = model.Description,
                CreatorId = userId
            };

            await dbContext.Workouts.AddAsync(workout);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteWorkoutAsync(Workout workout)
        {
            var exercisesInWorkout = dbContext.WorkoutExercises.Where(we => we.WorkoutId == workout.Id);
            dbContext.WorkoutExercises.RemoveRange(exercisesInWorkout);

            dbContext.Workouts.Remove(workout);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditWorkoutAsync(Workout workout, WorkoutFormViewModel model)
        {
            workout.Title = model.Title;
            workout.Description = model.Description;

            dbContext.Workouts.Update(workout);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExerciseViewModel>> GetExercisesAsync()
        {
            return await dbContext
                .Exercises
                .AsNoTracking()
                .Select(e => new ExerciseViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    MuscleName = e.Muscle.Name
                })
                .OrderBy(e => e.Name)
                .ThenBy(e => e.MuscleName)
                .ToListAsync();
        }

        public async Task<Workout> GetSpecificWorkoutByIdAndCreatorIdAsync(int id, string userId)
        {
           var workout =  await dbContext.Workouts
                .Where(w => w.Id == id && w.CreatorId == userId)
                .FirstOrDefaultAsync();

            return workout!;
        }

        public async Task<Workout> GetWorkoutByTitleAndCreatorIdAsync(WorkoutFormViewModel model, string userId)
        {
            var workout = await dbContext.Workouts
                .Where(w => w.Title == model.Title && w.CreatorId == userId)
                .FirstOrDefaultAsync();

            return workout!;
        }

        public async Task<IEnumerable<WorkoutViewModel>> GetWorkoutsForTheCurrentUserAsync(string userId)
        {
            return await dbContext.Workouts
                .Where(w => w.CreatorId == userId)
                .Select(w => new WorkoutViewModel
                {
                    Id = w.Id,
                    Title = w.Title,
                    Description = w.Description
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task RemoveExerciseFromWorkoutAsync(WorkoutExercise workoutExercise)
        {
            dbContext.WorkoutExercises.Remove(workoutExercise);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Workout> GetDetailedWorkoutAsync(int id, string userId)
        {
            var workout = await dbContext
                .Workouts
                .Include(w => w.WorkoutExercises)
                .ThenInclude(we => we.Exercise)
                .ThenInclude(e => e.Muscle)
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.Id == id && w.CreatorId == userId);

            return workout!;
        }

        public async Task<WorkoutExercise> GetWorkoutExerciseAsync(int workoutId, int exerciseId)
        {
            var workoutExercise = await dbContext
               .WorkoutExercises
               .FirstOrDefaultAsync(we => we.WorkoutId == workoutId && we.ExerciseId == exerciseId);

            return workoutExercise!;
        }
    }
}
