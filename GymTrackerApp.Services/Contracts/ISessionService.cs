using GymTrackerApp.ViewModels.ViewModels.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.Services.Contracts
{
    public interface ISessionService
    {
        public Task LogSessionAsync(int workoutId, string userId, int duration);

        public Task <IEnumerable<WorkoutSessionViewModel>> GetSessionsAsync(string userId,int page, int PageSize, string search);

        public Task<int> GetTotalSessionsCountAsync(string userId, string search);
    }
}
