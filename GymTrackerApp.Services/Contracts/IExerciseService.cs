using GymTrackerApp.Data.Models;
using GymTrackerApp.ViewModels.ViewModels;
using GymTrackerApp.ViewModels.ViewModels.Exercise;
using GymTrackerApp.ViewModels.ViewModels.Muscle;

namespace GymTrackerApp.Services.Contracts
{
    public interface IExerciseService
    {
        public Task<IEnumerable<ExerciseViewModel>> GetExercisesPaginatedAndFilterdAsync(int page, int PageSize,string search);

        public Task<int> GetTotalExercisesCountAsync(string search);

        public Task<Exercise> GetExerciseByIdAsync(int id);

        public Task<Exercise> GetExerciseByIdAsyncWithMusclesIncluded(int id);

        public Task<Exercise> GetExerciseByNameAsync(string name);

        public Task AddExerciseAsync(ExerciseFormViewModel model, string userId);

        public Task EditExerciseAsync(int id, ExerciseFormViewModel model);

        public Task DeleteExerciseAsync(int id);

        public Task<IEnumerable<MuscleViewModel>> GetMusclesAsync();
    }
}
