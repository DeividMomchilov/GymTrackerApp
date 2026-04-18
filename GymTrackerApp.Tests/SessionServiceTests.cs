using GymTrackerApp.Data;
using GymTrackerApp.Data.Models;
using GymTrackerApp.Services.Services;
using GymTrackerApp.ViewModels.ViewModels.Muscle;
using GymTrackerApp.ViewModels.ViewModels.Session;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerApp.Tests
{
    [TestFixture]
    public class SessionServiceTests
    {
        private DbContextOptions<ApplicationDbContext> GetDbOptions()
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task GetSessionsAsync_ShouldReturnPaginatedAndFilteredSessions()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            string userId = "user123";

            dbContext.Workouts.Add(new Workout { Id = 1, Title = "Morning Cardio", Description = "Running", CreatorId = userId });
            dbContext.Workouts.Add(new Workout { Id = 2, Title = "Evening Lifting", Description = "Weights", CreatorId = userId });

            dbContext.WorkoutSessions.Add(new WorkoutSession { Id = 1, UserId = userId, WorkoutId = 1, DateCompleted = DateTime.UtcNow.AddDays(-1), DurationInMinutes = 30 });
            dbContext.WorkoutSessions.Add(new WorkoutSession { Id = 2, UserId = userId, WorkoutId = 2, DateCompleted = DateTime.UtcNow.AddDays(-2), DurationInMinutes = 60 });
            dbContext.WorkoutSessions.Add(new WorkoutSession { Id = 3, UserId = userId, WorkoutId = 1, DateCompleted = DateTime.UtcNow, DurationInMinutes = 45 });

            dbContext.WorkoutSessions.Add(new WorkoutSession { Id = 4, UserId = "otherUser", WorkoutId = 2, DateCompleted = DateTime.UtcNow, DurationInMinutes = 20 });

            await dbContext.SaveChangesAsync();

            var sessionService = new SessionService(dbContext);

            var result1 = await sessionService.GetSessionsAsync(userId, page: 1, pageSize: 1, search: "cardio");

            var result2 = await sessionService.GetSessionsAsync(userId, page: 2, pageSize: 1, search: "cardio");

            Assert.That(result1.Count(), Is.EqualTo(1));
            Assert.That(result1.First().DurationInMinutes, Is.EqualTo(45));

            Assert.That(result2.Count(), Is.EqualTo(1));
            Assert.That(result2.First().DurationInMinutes, Is.EqualTo(30));
        }

        [Test]
        public async Task LogSessionAsync_ShouldAddSessionToDatabase()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            var sessionService = new SessionService(dbContext);

            var model = new WorkoutSessionFormViewModel
            {
                WorkoutId = 10,
                DurationInMinutes = 90
            };
            string userId = "testUser";

            await sessionService.LogSessionAsync(model, userId);

            var savedSession = await dbContext.WorkoutSessions.FirstOrDefaultAsync(ws => ws.UserId == userId);

            Assert.That(savedSession, Is.Not.Null);
            Assert.That(savedSession.WorkoutId, Is.EqualTo(10));
            Assert.That(savedSession.DurationInMinutes, Is.EqualTo(90));

            Assert.That(savedSession.DateCompleted, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromSeconds(5)));
        }

        [Test]
        public async Task GetTotalSessionsCountAsync_ShouldReturnCorrectCount()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            string userId = "user123";

            dbContext.Workouts.Add(new Workout { Id = 1, Title = "Chest Day", Description = "Chest routine", CreatorId = userId });
            dbContext.Workouts.Add(new Workout { Id = 2, Title = "Leg Day", Description = "Leg routine", CreatorId = userId });

            dbContext.WorkoutSessions.Add(new WorkoutSession { Id = 1, UserId = userId, WorkoutId = 1, DateCompleted = DateTime.UtcNow, DurationInMinutes = 40 });
            dbContext.WorkoutSessions.Add(new WorkoutSession { Id = 2, UserId = userId, WorkoutId = 1, DateCompleted = DateTime.UtcNow, DurationInMinutes = 50 });
            dbContext.WorkoutSessions.Add(new WorkoutSession { Id = 3, UserId = userId, WorkoutId = 2, DateCompleted = DateTime.UtcNow, DurationInMinutes = 60 });

            dbContext.WorkoutSessions.Add(new WorkoutSession { Id = 4, UserId = "diffUser", WorkoutId = 1, DateCompleted = DateTime.UtcNow, DurationInMinutes = 40 });

            await dbContext.SaveChangesAsync();

            var sessionService = new SessionService(dbContext);

            var totalCount = await sessionService.GetTotalSessionsCountAsync(userId, search: "");
            var searchCount = await sessionService.GetTotalSessionsCountAsync(userId, search: "chest");

            Assert.That(totalCount, Is.EqualTo(3));
            Assert.That(searchCount, Is.EqualTo(2));
        }

        [Test]
        public async Task GetLatestSessionForWorkoutAsync_ShouldReturnMostRecentSession()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            string userId = "user123";
            int workoutId = 1;

            dbContext.Workouts.Add(new Workout { Id = workoutId, Title = "Back Day", Description = "Back routine", CreatorId = userId });

            dbContext.WorkoutSessions.Add(new WorkoutSession { Id = 1, UserId = userId, WorkoutId = workoutId, DateCompleted = DateTime.UtcNow.AddDays(-10), DurationInMinutes = 40 });
            dbContext.WorkoutSessions.Add(new WorkoutSession { Id = 2, UserId = userId, WorkoutId = workoutId, DateCompleted = DateTime.UtcNow.AddDays(-2), DurationInMinutes = 60 }); // This is the latest
            dbContext.WorkoutSessions.Add(new WorkoutSession { Id = 3, UserId = userId, WorkoutId = workoutId, DateCompleted = DateTime.UtcNow.AddDays(-5), DurationInMinutes = 50 });

            await dbContext.SaveChangesAsync();

            var sessionService = new SessionService(dbContext);

            var result = await sessionService.GetLatestSessionForWorkoutAsync(workoutId, userId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(2));
            Assert.That(result.DurationInMinutes, Is.EqualTo(60));
        }

        [Test]
        public async Task GetLatestSessionForWorkoutAsync_ShouldReturnNull_WhenNoSessionsExist()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            var sessionService = new SessionService(dbContext);

            var result = await sessionService.GetLatestSessionForWorkoutAsync(workoutId: 99, userId: "someUser");

            Assert.That(result, Is.Null);
        }
        [Test]
        public async Task GetSessionsAsync_ShouldReturnAllSessions_WhenSearchIsEmpty()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            string userId = "user123";
            dbContext.Workouts.Add(new Workout { Id = 1, Title = "Workout A", Description = "A", CreatorId = userId });
            dbContext.WorkoutSessions.Add(new WorkoutSession { Id = 1, UserId = userId, WorkoutId = 1, DateCompleted = DateTime.UtcNow, DurationInMinutes = 30 });
            dbContext.WorkoutSessions.Add(new WorkoutSession { Id = 2, UserId = userId, WorkoutId = 1, DateCompleted = DateTime.UtcNow, DurationInMinutes = 40 });
            await dbContext.SaveChangesAsync();

            var sessionService = new SessionService(dbContext);

            var result = await sessionService.GetSessionsAsync(userId, 1, 10, search: "");

            Assert.That(result.Count(), Is.EqualTo(2));
        }
    }
}
