using GymTrackerApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.Services.Contracts
{
    public interface IMuscleService
    {
        public Task<IEnumerable<Muscle>> GetAllMusclesAsync();

        public Task<Muscle> GetMuscleByIdAsync(int id);

        public Task<IEnumerable<Exercise>> GetMusclesExercisesAsync(int id);
    }
}
