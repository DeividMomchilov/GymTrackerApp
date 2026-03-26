using GymTrackerApp.Data;
using GymTrackerApp.Data.Models;
using GymTrackerApp.Services.Contracts;
using GymTrackerApp.ViewModels.ViewModels.Session;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.Services.Services
{
    public class SessionService(ApplicationDbContext dbContext) : ISessionService
    {
        public async Task<IEnumerable<WorkoutSessionViewModel>> GetSessionsAsync(string userId, int page, int pageSize, string search)
        {
            int recordsToSkip = (page - 1) * pageSize;

            var sessionsQuery = dbContext.WorkoutSessions
                .Include(ws => ws.Workout)
                .Where(ws => ws.UserId == userId);

            if (!string.IsNullOrWhiteSpace(search))
                sessionsQuery = sessionsQuery.Where(ws => ws.Workout.Title.ToLower().Contains(search.ToLower()));

            return await sessionsQuery
                .OrderByDescending(ws => ws.DateCompleted)
                .Skip(recordsToSkip)
                .Take(pageSize)
                .Select(ws => new WorkoutSessionViewModel
                {
                    Id = ws.Id,
                    WorkoutTitle = ws.Workout.Title,
                    DateCompleted = ws.DateCompleted,
                    DurationInMinutes = ws.DurationInMinutes
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task LogSessionAsync(WorkoutSessionFormViewModel model, string userId)
        {
            var session = new WorkoutSession
            {
                UserId = userId,
                WorkoutId = model.WorkoutId,
                DateCompleted = DateTime.UtcNow,
                DurationInMinutes = model.DurationInMinutes
            };

            await dbContext.WorkoutSessions.AddAsync(session);
            await dbContext.SaveChangesAsync();
        }

        public Task<int> GetTotalSessionsCountAsync(string userId, string search)
        {
            var sessionsQuery = dbContext.WorkoutSessions
                .Include(ws => ws.Workout)
                .Where(ws => ws.UserId == userId);

            if (!string.IsNullOrWhiteSpace(search))
                sessionsQuery = sessionsQuery.Where(ws => ws.Workout.Title.ToLower().Contains(search.ToLower()));

            return sessionsQuery.CountAsync();

        }

        public async Task<WorkoutSessionViewModel?> GetLatestSessionForWorkoutAsync(int workoutId, string userId)
        {
            return await dbContext.WorkoutSessions
                .Where(ws => ws.WorkoutId == workoutId && ws.UserId == userId)
                .OrderByDescending(ws => ws.DateCompleted)
                .Select(ws => new WorkoutSessionViewModel
                {
                    Id = ws.Id,
                    WorkoutTitle = ws.Workout.Title,
                    DateCompleted = ws.DateCompleted,
                    DurationInMinutes = ws.DurationInMinutes
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
