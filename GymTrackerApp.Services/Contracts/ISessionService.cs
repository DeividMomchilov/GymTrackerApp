using GymTrackerApp.ViewModels.ViewModels.Session;

namespace GymTrackerApp.Services.Contracts
{
    public interface ISessionService
    {
        public Task LogSessionAsync(WorkoutSessionFormViewModel model, string userId);

        public Task <IEnumerable<WorkoutSessionViewModel>> GetSessionsAsync(string userId,int page, int PageSize, string search);

        public Task<int> GetTotalSessionsCountAsync(string userId, string search);

        public Task<WorkoutSessionViewModel?> GetLatestSessionForWorkoutAsync(int workoutId, string userId);
    }
}
