using GymTrackerApp.Data;
using GymTrackerApp.Data.Models;
using GymTrackerApp.Services.Contracts;
using GymTrackerApp.ViewModels.ViewModels;
using GymTrackerApp.ViewModels.ViewModels.Exercise;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.Services
{
    public class ExerciseService(ApplicationDbContext dbContext) : IExerciseService
    {
        public async Task AddExerciseAsync(ExerciseFormViewModel model, string userId)
        {
            var existingExercise = await GetExerciseByNameAsync(model.Name);

            var exercise = new Exercise
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                MuscleId = dbContext.Muscles.FirstOrDefault(m => m.Id == model.MuscleId)?.Id ?? 0,
                CreatorId = userId
            };

            await dbContext.Exercises.AddAsync(exercise);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteExerciseAsync(int id)
        {
            var exercise = await GetExerciseByIdAsync(id);
            dbContext.Exercises.Remove(exercise);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditExerciseAsync(int id, ExerciseFormViewModel model)
        {
            var exercise = await GetExerciseByIdAsync(id);

            exercise.Name = model.Name;
            exercise.Description = model.Description;
            exercise.ImageUrl = model.ImageUrl;
            exercise.MuscleId = dbContext.Muscles.FirstOrDefault(m => m.Id == model.MuscleId)?.Id ?? 0;
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExerciseViewModel>> GetAllExercisesAsync()
        {
            return await dbContext
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
        }

        public async Task<Exercise> GetExerciseByIdAsync(int id)
        {
            var exercise = await dbContext
                .Exercises
                .FindAsync(id);

            return exercise!;
        }

        public async Task<Exercise> GetExerciseByIdAsyncWithMusclesIncluded(int id)
        {
            var exercise = await dbContext
                .Exercises
                .Include (e => e.Muscle)
                .FirstOrDefaultAsync(e => e.Id == id);

            return exercise!;
        }

        public async Task<Exercise> GetExerciseByNameAsync(string name)
        {
            var exercise = await dbContext
                .Exercises
                .FirstOrDefaultAsync(e => e.Name.ToLower() == name.ToLower());

            return exercise!;
        }

        public async Task<IEnumerable<MuscleViewModel>> GetMusclesAsync()
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
