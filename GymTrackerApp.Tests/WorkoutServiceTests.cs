using GymTrackerApp.Data;
using GymTrackerApp.Data.Models;
using GymTrackerApp.Services.Services;
using GymTrackerApp.ViewModels.ViewModels.Workout;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerApp.Tests
{
    [TestFixture]
    public class WorkoutServiceTests
    {
        private DbContextOptions<ApplicationDbContext> GetDbOptions()
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task CreateWorkoutAsync_ShouldAddWorkoutToDatabase()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);
            var service = new WorkoutService(dbContext);

            var model = new WorkoutFormViewModel { Title = "Push Day", Description = "Push hard" };
            string userId = "user123";

            await service.CreateWorkoutAsync(model, userId);

            var savedWorkout = await dbContext.Workouts.FirstOrDefaultAsync();
            Assert.That(savedWorkout, Is.Not.Null);
            Assert.That(savedWorkout.Title, Is.EqualTo("Push Day"));
            Assert.That(savedWorkout.CreatorId, Is.EqualTo(userId));
        }

        [Test]
        public async Task EditWorkoutAsync_ShouldUpdateWorkoutProperties()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);
            var workout = new Workout { Id = 1, Title = "Old Title", Description = "Old Desc", CreatorId = "u1" };
            dbContext.Workouts.Add(workout);
            await dbContext.SaveChangesAsync();

            var service = new WorkoutService(dbContext);
            var model = new WorkoutFormViewModel { Title = "New Title", Description = "New Desc" };

            await service.EditWorkoutAsync(workout, model);

            var updatedWorkout = await dbContext.Workouts.FirstAsync();
            Assert.That(updatedWorkout.Title, Is.EqualTo("New Title"));
            Assert.That(updatedWorkout.Description, Is.EqualTo("New Desc"));
        }

        [Test]
        public async Task DeleteWorkoutAsync_ShouldRemoveWorkoutAndItsExercises()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);
            var workout = new Workout { Id = 1, Title = "Test", Description = "Test", CreatorId = "u1" };
            dbContext.Workouts.Add(workout);
            dbContext.WorkoutExercises.Add(new WorkoutExercise { WorkoutId = 1, ExerciseId = 1, Sets = 3, Reps = 10, Weight = 50 });
            await dbContext.SaveChangesAsync();

            var service = new WorkoutService(dbContext);

            await service.DeleteWorkoutAsync(workout);

            Assert.That(await dbContext.Workouts.AnyAsync(), Is.False);
            Assert.That(await dbContext.WorkoutExercises.AnyAsync(), Is.False);
        }

        [Test]
        public async Task AddExerciseToWorkoutAsync_ShouldAddRelation()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);
            var service = new WorkoutService(dbContext);

            var model = new WorkoutExerciseFormViewModel
            {
                WorkoutId = 1,
                ExerciseId = 2,
                Sets = 3,
                Reps = 10,
                Weight = 100
            };

            await service.AddExerciseToWorkoutAsync(model);

            var relation = await dbContext.WorkoutExercises.FirstOrDefaultAsync();
            Assert.That(relation, Is.Not.Null);
            Assert.That(relation.WorkoutId, Is.EqualTo(1));
            Assert.That(relation.Weight, Is.EqualTo(100));
        }

        [Test]
        public async Task RemoveExerciseFromWorkoutAsync_ShouldDeleteRelation()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);
            var relation = new WorkoutExercise { WorkoutId = 1, ExerciseId = 2, Sets = 3, Reps = 10, Weight = 50 };
            dbContext.WorkoutExercises.Add(relation);
            await dbContext.SaveChangesAsync();

            var service = new WorkoutService(dbContext);

            await service.RemoveExerciseFromWorkoutAsync(relation);

            Assert.That(await dbContext.WorkoutExercises.AnyAsync(), Is.False);
        }

        [Test]
        public async Task GetWorkoutsForTheCurrentUserAsync_ShouldReturnOnlyUsersWorkouts()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);
            dbContext.Workouts.Add(new Workout { Id = 1, Title = "W1", Description = "D1", CreatorId = "user1" });
            dbContext.Workouts.Add(new Workout { Id = 2, Title = "W2", Description = "D2", CreatorId = "user1" });
            dbContext.Workouts.Add(new Workout { Id = 3, Title = "W3", Description = "D3", CreatorId = "user2" });
            await dbContext.SaveChangesAsync();

            var service = new WorkoutService(dbContext);

            var result = await service.GetWorkoutsForTheCurrentUserAsync("user1");

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Any(w => w.Id == 3), Is.False);
        }

        [Test]
        public async Task GetSpecificWorkoutByIdAndCreatorIdAsync_ShouldReturnCorrectWorkout()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);
            dbContext.Workouts.Add(new Workout { Id = 1, Title = "W1", Description = "D1", CreatorId = "user1" });
            await dbContext.SaveChangesAsync();

            var service = new WorkoutService(dbContext);

            var result = await service.GetSpecificWorkoutByIdAndCreatorIdAsync(1, "user1");
            var notFoundResult = await service.GetSpecificWorkoutByIdAndCreatorIdAsync(1, "wrongUser");

            Assert.That(result, Is.Not.Null);
            Assert.That(notFoundResult, Is.Null);
        }

        [Test]
        public async Task GetDetailedWorkoutAsync_ShouldReturnWorkoutWithIncludedEntities()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            dbContext.Muscles.Add(new Muscle { Id = 1, Name = "Chest" });
            dbContext.Exercises.Add(new Exercise { Id = 1, Name = "Bench", Description = "D", CreatorId = "u", MuscleId = 1 });
            dbContext.Workouts.Add(new Workout { Id = 1, Title = "W1", Description = "D1", CreatorId = "user1" });
            dbContext.WorkoutExercises.Add(new WorkoutExercise { WorkoutId = 1, ExerciseId = 1, Sets = 3, Reps = 10, Weight = 50 });
            await dbContext.SaveChangesAsync();

            var service = new WorkoutService(dbContext);

            var result = await service.GetDetailedWorkoutAsync(1, "user1");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.WorkoutExercises.Count, Is.EqualTo(1));
            Assert.That(result.WorkoutExercises.First().Exercise.Name, Is.EqualTo("Bench"));
            Assert.That(result.WorkoutExercises.First().Exercise.Muscle.Name, Is.EqualTo("Chest"));
        }
    }
}