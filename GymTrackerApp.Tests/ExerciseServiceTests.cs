using GymTrackerApp.Data;
using GymTrackerApp.Data.Models;
using GymTrackerApp.Services.Services;
using GymTrackerApp.ViewModels.ViewModels;
using GymTrackerApp.ViewModels.ViewModels.Muscle;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerApp.Tests
{
    [TestFixture]
    public class ExerciseServiceTests
    {
        private DbContextOptions<ApplicationDbContext> GetDbOptions()
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task AddExerciseAsync_ShouldAddExerciseToDatabase()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            dbContext.Muscles.Add(new Muscle { Id = 1, Name = "Chest" });
            await dbContext.SaveChangesAsync();

            var service = new ExerciseService(dbContext);
            var model = new ExerciseFormViewModel
            {
                Name = "Bench Press",
                Description = "Push the bar up",
                ImageUrl = "bench.jpg",
                MuscleId = 1
            };
            string userId = "user123";

            await service.AddExerciseAsync(model, userId);

            var savedExercise = await dbContext.Exercises.FirstOrDefaultAsync();
            Assert.That(savedExercise, Is.Not.Null);
            Assert.That(savedExercise.Name, Is.EqualTo("Bench Press"));
            Assert.That(savedExercise.CreatorId, Is.EqualTo(userId));
        }

        [Test]
        public async Task DeleteExerciseAsync_ShouldRemoveExerciseFromDatabase()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            var exercise = new Exercise { Id = 1, Name = "Squat", Description = "Legs", CreatorId = "user1" };
            dbContext.Exercises.Add(exercise);
            await dbContext.SaveChangesAsync();

            var service = new ExerciseService(dbContext);

            await service.DeleteExerciseAsync(1);

            var exists = await dbContext.Exercises.AnyAsync(e => e.Id == 1);
            Assert.That(exists, Is.False);
        }

        [Test]
        public async Task EditExerciseAsync_ShouldUpdateExerciseProperties()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            dbContext.Muscles.Add(new Muscle { Id = 1, Name = "Legs" });
            dbContext.Muscles.Add(new Muscle { Id = 2, Name = "Back" }); 

            dbContext.Exercises.Add(new Exercise
            {
                Id = 1,
                Name = "Old Squat",
                Description = "Old Desc",
                CreatorId = "user1",
                MuscleId = 1
            });
            await dbContext.SaveChangesAsync();

            var service = new ExerciseService(dbContext);
            var editModel = new ExerciseFormViewModel
            {
                Name = "New Squat",
                Description = "New Desc",
                ImageUrl = "new.jpg",
                MuscleId = 2
            };

            await service.EditExerciseAsync(1, editModel);

            var updated = await dbContext.Exercises.FirstAsync(e => e.Id == 1);
            Assert.That(updated.Name, Is.EqualTo("New Squat"));
            Assert.That(updated.Description, Is.EqualTo("New Desc"));
            Assert.That(updated.MuscleId, Is.EqualTo(2));
        }

        [Test]
        public async Task GetExercisesPaginatedAndFilterdAsync_ShouldReturnCorrectData()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            dbContext.Muscles.Add(new Muscle { Id = 1, Name = "Chest" });

            dbContext.Exercises.Add(new Exercise { Id = 1, Name = "Apple", Description = "A", CreatorId = "U", MuscleId = 1 });
            dbContext.Exercises.Add(new Exercise { Id = 2, Name = "Banana", Description = "B", CreatorId = "U", MuscleId = 1 });
            dbContext.Exercises.Add(new Exercise { Id = 3, Name = "Blueberry", Description = "B2", CreatorId = "U", MuscleId = 1 });
            await dbContext.SaveChangesAsync();

            var service = new ExerciseService(dbContext);

            var result = await service.GetExercisesPaginatedAndFilterdAsync(page: 1, pageSize: 1, search: "b");

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Name, Is.EqualTo("Banana"));
            Assert.That(result.First().MuscleName, Is.EqualTo("Chest"));
        }

        [Test]
        public async Task GetExerciseByIdAsyncWithMusclesIncluded_ShouldIncludeMuscleData()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            dbContext.Muscles.Add(new Muscle { Id = 5, Name = "Shoulders" });
            dbContext.Exercises.Add(new Exercise { Id = 10, Name = "Overhead Press", Description = "Push", CreatorId = "U", MuscleId = 5 });
            await dbContext.SaveChangesAsync();

            var service = new ExerciseService(dbContext);

            var result = await service.GetExerciseByIdAsyncWithMusclesIncluded(10);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Muscle, Is.Not.Null);
            Assert.That(result.Muscle.Name, Is.EqualTo("Shoulders"));
        }

        [Test]
        public async Task GetExerciseByNameAsync_ShouldReturnExerciseCaseInsensitive()
        { 
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            dbContext.Exercises.Add(new Exercise { Id = 1, Name = "DEADLIFT", Description = "Pull", CreatorId = "U" });
            await dbContext.SaveChangesAsync();

            var service = new ExerciseService(dbContext);

            var result = await service.GetExerciseByNameAsync("deadlift");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("DEADLIFT"));
        }

        [Test]
        public async Task GetTotalExercisesCountAsync_ShouldReturnCorrectNumber()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            dbContext.Exercises.Add(new Exercise { Id = 1, Name = "Curl", Description = "D", CreatorId = "U" });
            dbContext.Exercises.Add(new Exercise { Id = 2, Name = "Crunch", Description = "D", CreatorId = "U" });
            dbContext.Exercises.Add(new Exercise { Id = 3, Name = "Squat", Description = "D", CreatorId = "U" });
            await dbContext.SaveChangesAsync();

            var service = new ExerciseService(dbContext);

            var totalCount = await service.GetTotalExercisesCountAsync("");
            var searchCount = await service.GetTotalExercisesCountAsync("Cru");

            Assert.That(totalCount, Is.EqualTo(3));
            Assert.That(searchCount, Is.EqualTo(1));
        }
    }
}
