using GymTrackerApp.Data.Models;
using GymTrackerApp.ViewModels.ViewModels.Muscle;

namespace GymTrackerApp.Services.Contracts
{
    public interface IMuscleService
    {
        public Task<IEnumerable<Muscle>> GetAllMusclesAsync();

        public Task<Muscle> GetMuscleByIdAsync(int id);

        public Task<IEnumerable<Exercise>> GetMusclesExercisesAsync(int id);

        public Task EditMuscleAsync(int id,MuscleFormViewModel model);
    }
}
