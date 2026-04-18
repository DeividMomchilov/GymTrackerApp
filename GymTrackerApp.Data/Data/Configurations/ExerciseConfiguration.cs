using GymTrackerApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymTrackerApp.Data.Data.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
           const string SeedUserId = "11111111-2222-3333-4444-555555555555";

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
                },
                new Exercise
                {
                    Id = 10,
                    Name = "Bench Press",
                    Description = "The ultimate chest builder. A compound push exercise using a barbell.",
                    ImageUrl = "https://example.com/benchpress.jpg",
                    MuscleId = 1, // Chest
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 11,
                    Name = "Pull-up",
                    Description = "A bodyweight exercise that builds upper back and lat width.",
                    ImageUrl = "https://example.com/pullup.jpg",
                    MuscleId = 2, // Upper Back
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 12,
                    Name = "Push-up",
                    Description = "A classic bodyweight exercise for chest, shoulders, and triceps.",
                    ImageUrl = "https://example.com/pushup.jpg",
                    MuscleId = 1, // Chest
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 13,
                    Name = "Dumbbell Shrugs",
                    Description = "An isolation exercise to build the upper trapezius muscles.",
                    ImageUrl = "https://example.com/shrugs.jpg",
                    MuscleId = 5, // Traps
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 14,
                    Name = "Wrist Curls",
                    Description = "An isolation exercise for forearm size and grip strength.",
                    ImageUrl = "https://example.com/wristcurl.jpg",
                    MuscleId = 9, // Forearms
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 15,
                    Name = "Crunches",
                    Description = "A basic core exercise targeting the upper abdominal muscles.",
                    ImageUrl = "https://example.com/crunches.jpg",
                    MuscleId = 10, // Upper Abs
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 16,
                    Name = "Hanging Leg Raises",
                    Description = "An advanced core exercise primarily targeting the lower abs.",
                    ImageUrl = "https://example.com/legraises.jpg",
                    MuscleId = 11, // Lower Abs
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 17,
                    Name = "Russian Twists",
                    Description = "A core exercise designed to target the oblique muscles.",
                    ImageUrl = "https://example.com/russiantwist.jpg",
                    MuscleId = 12, // Obliques
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 18,
                    Name = "Hip Thrusts",
                    Description = "The best exercise for isolating and building the glutes.",
                    ImageUrl = "https://example.com/hipthrust.jpg",
                    MuscleId = 15, // Glutes
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 19,
                    Name = "Leg Extension",
                    Description = "A machine isolation exercise specifically for the quadriceps.",
                    ImageUrl = "https://example.com/legextension.jpg",
                    MuscleId = 13, // Quads
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 20,
                    Name = "Incline Dumbbell Press",
                    Description = "Excellent for targeting the upper portion of the pectoral muscles.",
                    ImageUrl = "https://example.com/inclinepress.jpg",
                    MuscleId = 1, // Chest
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 21,
                    Name = "Cable Crossover",
                    Description = "An isolation exercise that provides constant tension on the chest.",
                    ImageUrl = "https://example.com/cablecrossover.jpg",
                    MuscleId = 1, // Chest
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 22,
                    Name = "Seated Cable Row",
                    Description = "Builds middle back thickness and improves posture.",
                    ImageUrl = "https://example.com/cablerow.jpg",
                    MuscleId = 2, // Upper Back
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 23,
                    Name = "T-Bar Row",
                    Description = "A heavy compound pulling exercise for mass in the lats and mid-back.",
                    ImageUrl = "https://example.com/tbarrow.jpg",
                    MuscleId = 4, // Lats
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 24,
                    Name = "Lateral Raise",
                    Description = "The best exercise for isolating the side deltoids to build wider shoulders.",
                    ImageUrl = "https://example.com/lateralraise.jpg",
                    MuscleId = 6, // Shoulders
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 25,
                    Name = "Face Pulls",
                    Description = "Crucial for rear deltoid development and overall shoulder health.",
                    ImageUrl = "https://example.com/facepull.jpg",
                    MuscleId = 6, // Shoulders
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 26,
                    Name = "Hammer Curl",
                    Description = "Targets the brachialis and the brachioradialis for thicker arms.",
                    ImageUrl = "https://example.com/hammercurl.jpg",
                    MuscleId = 7, // Biceps
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 27,
                    Name = "Preacher Curl",
                    Description = "Strict isolation for the biceps, preventing momentum.",
                    ImageUrl = "https://example.com/preachercurl.jpg",
                    MuscleId = 7, // Biceps
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 28,
                    Name = "Skull Crushers",
                    Description = "A barbell extension movement that heavily targets the long head of the triceps.",
                    ImageUrl = "https://example.com/skullcrusher.jpg",
                    MuscleId = 8, // Triceps
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 29,
                    Name = "Tricep Dips",
                    Description = "A heavy compound bodyweight movement for thick triceps and chest.",
                    ImageUrl = "https://example.com/dips.jpg",
                    MuscleId = 8, // Triceps
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 30,
                    Name = "Bulgarian Split Squat",
                    Description = "A unilateral leg exercise that builds immense quad and glute strength.",
                    ImageUrl = "https://example.com/splitsquat.jpg",
                    MuscleId = 13, // Quads
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 31,
                    Name = "Hack Squat",
                    Description = "A machine variation of the squat that isolates the quads effectively.",
                    ImageUrl = "https://example.com/hacksquat.jpg",
                    MuscleId = 13, // Quads
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 32,
                    Name = "Romanian Deadlift (RDL)",
                    Description = "Focuses entirely on the hamstrings and glutes through a hip hinge.",
                    ImageUrl = "https://example.com/rdl.jpg",
                    MuscleId = 14, // Hamstrings
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 33,
                    Name = "Good Mornings",
                    Description = "Builds immense lower back, glute, and hamstring strength.",
                    ImageUrl = "https://example.com/goodmorning.jpg",
                    MuscleId = 3, // Lower Back
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 34,
                    Name = "Seated Calf Raise",
                    Description = "Targets the soleus muscle of the calves.",
                    ImageUrl = "https://example.com/seatedcalf.jpg",
                    MuscleId = 16, // Calves
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 35,
                    Name = "Farmer's Walk",
                    Description = "A full-body carry that builds extreme grip strength and traps.",
                    ImageUrl = "https://example.com/farmerswalk.jpg",
                    MuscleId = 9, // Forearms
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 36,
                    Name = "Plank",
                    Description = "An isometric core exercise that builds endurance and stability.",
                    ImageUrl = "https://example.com/plank.jpg",
                    MuscleId = 10, // Upper Abs
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 37,
                    Name = "Bicycle Crunches",
                    Description = "Dynamic movement hitting both the rectus abdominis and obliques.",
                    ImageUrl = "https://example.com/bicycle.jpg",
                    MuscleId = 12, // Obliques
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 38,
                    Name = "Cable Woodchoppers",
                    Description = "Rotational core movement perfect for athletic performance and obliques.",
                    ImageUrl = "https://example.com/woodchopper.jpg",
                    MuscleId = 12, // Obliques
                    CreatorId = SeedUserId
                }
            );
        }
    }
}