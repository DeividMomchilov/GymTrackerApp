using GymTrackerApp.Data;
using GymTrackerApp.Data.Models;
using GymTrackerApp.Services.Services;
using GymTrackerApp.ViewModels.ViewModels.Muscle;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerApp.Tests
{
    [TestFixture]
    public class MuscleServiceTests
    {
        private DbContextOptions<ApplicationDbContext> GetDbOptions()
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task GetAllMusclesAsync_ShouldReturnAllMuscles()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            dbContext.Muscles.Add(new Muscle { Id = 1, Name = "Chest", Description = "Chest muscle" });
            dbContext.Muscles.Add(new Muscle { Id = 2, Name = "Back", Description = "Back muscle" });
            await dbContext.SaveChangesAsync();

            var muscleService = new MuscleService(dbContext);

            var result = await muscleService.GetAllMusclesAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetMuscleByIdAsync_ShouldReturnCorrectMuscle()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            dbContext.Muscles.Add(new Muscle { Id = 1, Name = "Chest", Description = "Chest muscle" });
            await dbContext.SaveChangesAsync();

            var muscleService = new MuscleService(dbContext);

            var result = await muscleService.GetMuscleByIdAsync(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Chest"));
        }

        [Test]
        public async Task EditMuscleAsync_ShouldUpdateMuscleProperties()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            var originalMuscle = new Muscle { Id = 1, Name = "Chest", Description = "Old Desc" };
            dbContext.Muscles.Add(originalMuscle);
            await dbContext.SaveChangesAsync();

            var muscleService = new MuscleService(dbContext);

            var editModel = new MuscleFormViewModel
            {
                Name = "Updated Chest",
                Description = "New Desc",
                ImageUrl = "new-image.jpg"
            };

            await muscleService.EditMuscleAsync(1, editModel);

            var updatedMuscle = await dbContext.Muscles.FirstAsync(m => m.Id == 1);
            Assert.That(updatedMuscle.Name, Is.EqualTo("Updated Chest"));
            Assert.That(updatedMuscle.Description, Is.EqualTo("New Desc"));
            Assert.That(updatedMuscle.ImageUrl, Is.EqualTo("new-image.jpg"));
        }
        [Test]
        public async Task GetMusclesExercisesAsync_ShouldReturnCorrectExercises()
        {
            var options = GetDbOptions();
            using var dbContext = new ApplicationDbContext(options);

            dbContext.Muscles.Add(new Muscle { Id = 1, Name = "Chest" });

            dbContext.Exercises.Add(new Exercise
            {
                Id = 1,
                Name = "Bench Press",
                Description = "Dummy description",
                CreatorId = "dummyUserId",
                MuscleId = 1
            });

            dbContext.Exercises.Add(new Exercise
            {
                Id = 2,
                Name = "Push Up",
                Description = "Dummy description",
                CreatorId = "dummyUserId",
                MuscleId = 1
            });

            dbContext.Exercises.Add(new Exercise
            {
                Id = 3,
                Name = "Pull Up",
                Description = "Dummy description",
                CreatorId = "dummyUserId",
                MuscleId = 2
            }); 

            await dbContext.SaveChangesAsync();

            var muscleService = new MuscleService(dbContext);

            var result = await muscleService.GetMusclesExercisesAsync(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Any(e => e.Name == "Pull Up"), Is.False, "Should not return exercises for other muscles.");
        }
    }
}
