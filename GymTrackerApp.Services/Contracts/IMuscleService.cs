using GymTrackerApp.Data.Models;

namespace GymTrackerApp.Services.Contracts
{
    public interface IMuscleService
    {
        public Task<IEnumerable<Muscle>> GetAllMusclesAsync();

        public Task<Muscle> GetMuscleByIdAsync(int id);

        public Task<IEnumerable<Exercise>> GetMusclesExercisesAsync(int id);
    }
}
