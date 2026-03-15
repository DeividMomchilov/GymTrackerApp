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
        public async Task<IEnumerable<WorkoutSessionViewModel>> LogUserSessionsAsync(string userId)
        {
            return await dbContext.WorkoutSessions
                .Include(ws => ws.Workout)
                .Where(ws => ws.UserId == userId)
                .OrderByDescending(ws => ws.DateCompleted)
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

        public async Task LogSessionAsync(int workoutId, string userId, int duration)
        {
            var session = new WorkoutSession
            {
                WorkoutId = workoutId,
                UserId = userId,
                DurationInMinutes = duration,
                DateCompleted = DateTime.UtcNow
            };

            await dbContext.WorkoutSessions.AddAsync(session);
            await dbContext.SaveChangesAsync();
        }
    }
}
