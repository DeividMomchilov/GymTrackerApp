using GymTrackerApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymTrackerApp.Data.Data.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
           const string SeedUserId = "3026ea73-023b-4901-b63b-ca12cd6fe019";

            builder.HasData(
                new Exercise
                {
                    Id = 1,
                    Name = "Squat",
                    Description = "The king of leg exercises. Targets quads, hamstrings, and glutes.",
                    ImageUrl = "https://example.com/squat.jpg",
                    MuscleId = 13, // Quads
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Deadlift",
                    Description = "A compound movement that works the entire posterior chain.",
                    ImageUrl = "https://example.com/deadlift.jpg",
                    MuscleId = 3, // Lower Back
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 4,
                    Name = "Overhead Press",
                    Description = "A classic shoulder builder performed with a barbell.",
                    ImageUrl = "https://example.com/ohp.jpg",
                    MuscleId = 6, // Shoulders
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 5,
                    Name = "Lat Pulldown",
                    Description = "A machine exercise that targets the latissimus dorsi.",
                    ImageUrl = "https://example.com/latpulldown.jpg",
                    MuscleId = 4, // Lats
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 6,
                    Name = "Barbell Curl",
                    Description = "An isolation exercise for the biceps.",
                    ImageUrl = "https://example.com/bicepcurl.jpg",
                    MuscleId = 7, // Biceps
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 7,
                    Name = "Tricep Rope Pushdown",
                    Description = "An isolation exercise for the triceps using a cable machine.",
                    ImageUrl = "https://example.com/triceppushdown.jpg",
                    MuscleId = 8, // Triceps
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 8,
                    Name = "Leg Curl",
                    Description = "Isolation exercise for the hamstrings.",
                    ImageUrl = "https://example.com/legcurl.jpg",
                    MuscleId = 14, // Hamstrings
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 9,
                    Name = "Calf Raise",
                    Description = "Simple but effective exercise for building calves.",
                    ImageUrl = "https://example.com/calfraise.jpg",
                    MuscleId = 16, // Calves
                    CreatorId = SeedUserId
                }
            );
        }
    }
}