using GymTrackerApp.Data;
using GymTrackerApp.Data.Models;
using GymTrackerApp.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.Services.Services
{
    public class MuscleService(ApplicationDbContext dbContext) : IMuscleService
    {
        public async Task<IEnumerable<Muscle>> GetAllMusclesAsync()
        {
            var muscles = await dbContext
                .Muscles
                .AsNoTracking()
                .ToListAsync();

            return muscles;
        }
        
        public async Task<Muscle> GetMuscleByIdAsync(int id)
        {
            var muscle = await dbContext
                .Muscles
                .FirstOrDefaultAsync(m => m.Id == id);

            return muscle!;
        }

        public async Task<IEnumerable<Exercise>> GetMusclesExercisesAsync(int id)
        {
            var exercises = await dbContext
                .Exercises
                .Where(e => e.MuscleId == id)
                .AsNoTracking()
                .ToListAsync();

            return exercises;
        }
    }
}
