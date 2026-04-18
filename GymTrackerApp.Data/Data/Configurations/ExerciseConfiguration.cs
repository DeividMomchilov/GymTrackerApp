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
                    ImageUrl = "https://thumbs.dreamstime.com/b/basic-rgb-228479863.jpg",
                    MuscleId = 13, // Quads
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Deadlift",
                    Description = "A compound movement that works the entire posterior chain.",
                    ImageUrl = "https://static.vecteezy.com/system/resources/previews/006/417/718/non_2x/man-doing-barbell-deadlifts-exercise-flat-illustration-isolated-on-white-background-free-vector.jpg",
                    MuscleId = 3, // Lower Back
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 4,
                    Name = "Overhead Press",
                    Description = "A classic shoulder builder performed with a barbell.",
                    ImageUrl = "https://www.shutterstock.com/image-vector/man-doing-overhead-dumbbell-shoulder-600nw-2031950852.jpg",
                    MuscleId = 6, // Shoulders
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 5,
                    Name = "Lat Pulldown",
                    Description = "A machine exercise that targets the latissimus dorsi.",
                    ImageUrl = "https://thumbs.dreamstime.com/b/basic-rgb-248990552.jpg",
                    MuscleId = 4, // Lats
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 6,
                    Name = "Barbell Curl",
                    Description = "An isolation exercise for the biceps.",
                    ImageUrl = "https://thumbs.dreamstime.com/b/man-doing-barbell-curls-exercise-standing-bicep-curl-arm-workout-man-doing-barbell-curls-exercise-standing-bicep-curl-arm-workout-201313766.jpg",
                    MuscleId = 7, // Biceps
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 7,
                    Name = "Tricep Rope Pushdown",
                    Description = "An isolation exercise for the triceps using a cable machine.",
                    ImageUrl = "https://www.shutterstock.com/image-vector/man-doing-cable-rope-pushdown-260nw-2169476315.jpg",
                    MuscleId = 8, // Triceps
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 8,
                    Name = "Leg Curl",
                    Description = "Isolation exercise for the hamstrings.",
                    ImageUrl = "https://t4.ftcdn.net/jpg/04/66/42/97/360_F_466429708_7KoDFAbfozTD5YcOneKgX5K6MaUqtEqF.jpg",
                    MuscleId = 14, // Hamstrings
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 9,
                    Name = "Calf Raise",
                    Description = "Simple but effective exercise for building calves.",
                    ImageUrl = "https://thumbs.dreamstime.com/b/man-doing-standing-calf-raise-assisted-machine-man-doing-standing-calf-raise-assisted-machine-flat-vector-illustration-259075988.jpg",
                    MuscleId = 16, // Calves
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 10,
                    Name = "Bench Press",
                    Description = "The ultimate chest builder. A compound push exercise using a barbell.",
                    ImageUrl = "https://www.shutterstock.com/shutterstock/photos/1841766727/display_1500/stock-vector-man-doing-barbell-bench-press-chest-press-flat-vector-illustration-isolated-on-white-background-1841766727.jpg",
                    MuscleId = 1, // Chest
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 11,
                    Name = "Pull-up",
                    Description = "A bodyweight exercise that builds upper back and lat width.",
                    ImageUrl = "https://thumbs.dreamstime.com/b/man-doing-pull-ups-exercise-flat-vector-illustration-man-doing-pull-ups-exercise-flat-vector-illustration-isolated-white-228445780.jpg",
                    MuscleId = 2, // Upper Back
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 12,
                    Name = "Push-up",
                    Description = "A classic bodyweight exercise for chest, shoulders, and triceps.",
                    ImageUrl = "https://thumbs.dreamstime.com/b/art-illustration-200146808.jpg",
                    MuscleId = 1, // Chest
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 13,
                    Name = "Dumbbell Shrugs",
                    Description = "An isolation exercise to build the upper trapezius muscles.",
                    ImageUrl = "https://www.shutterstock.com/image-vector/man-doing-dumbbell-shrugs-exercise-260nw-1986762905.jpg",
                    MuscleId = 5, // Traps
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 14,
                    Name = "Wrist Curls",
                    Description = "An isolation exercise for forearm size and grip strength.",
                    ImageUrl = "https://thumbs.dreamstime.com/b/man-doing-seated-palm-wrist-curls-exercise-flat-vector-illustration-isolated-white-background-223602922.jpg",
                    MuscleId = 9, // Forearms
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 15,
                    Name = "Crunches",
                    Description = "A basic core exercise targeting the upper abdominal muscles.",
                    ImageUrl = "https://www.shutterstock.com/image-vector/man-doing-crunches-abdominals-exercise-600nw-1842272014.jpg",
                    MuscleId = 10, // Upper Abs
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 16,
                    Name = "Hanging Leg Raises",
                    Description = "An advanced core exercise primarily targeting the lower abs.",
                    ImageUrl = "https://thumbs.dreamstime.com/b/art-illustration-201075897.jpg",
                    MuscleId = 11, // Lower Abs
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 17,
                    Name = "Russian Twists",
                    Description = "A core exercise designed to target the oblique muscles.",
                    ImageUrl = "https://previews.123rf.com/images/lioputra/lioputra2111/lioputra211100044/177362267-man-doing-weighted-russian-mason-twists-exercise-flat-vector-illustration-isolated-on-white.jpg",
                    MuscleId = 12, // Obliques
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 18,
                    Name = "Hip Thrusts",
                    Description = "The best exercise for isolating and building the glutes.",
                    ImageUrl = "https://thumbs.dreamstime.com/b/basic-rgb-221835143.jpg",
                    MuscleId = 15, // Glutes
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 19,
                    Name = "Leg Extension",
                    Description = "A machine isolation exercise specifically for the quadriceps.",
                    ImageUrl = "https://www.shutterstock.com/image-vector/man-doing-seated-machine-leg-260nw-2316630653.jpg",
                    MuscleId = 13, // Quads
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 20,
                    Name = "Incline Dumbbell Press",
                    Description = "Excellent for targeting the upper portion of the pectoral muscles.",
                    ImageUrl = "https://static.vecteezy.com/system/resources/previews/032/647/051/non_2x/man-doing-incline-dumbbell-bench-press-twist-exercise-vector.jpg",
                    MuscleId = 1, // Chest
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 21,
                    Name = "Cable Crossover",
                    Description = "An isolation exercise that provides constant tension on the chest.",
                    ImageUrl = "https://www.shutterstock.com/image-vector/man-doing-standing-cable-crossover-600nw-2164371137.jpg",
                    MuscleId = 1, // Chest
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 22,
                    Name = "Seated Cable Row",
                    Description = "Builds middle back thickness and improves posture.",
                    ImageUrl = "https://www.shutterstock.com/image-vector/man-doing-seated-low-cable-600nw-2205405029.jpg",
                    MuscleId = 2, // Upper Back
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 23,
                    Name = "T-Bar Row",
                    Description = "A heavy compound pulling exercise for mass in the lats and mid-back.",
                    ImageUrl = "https://www.shutterstock.com/image-vector/man-doing-bent-over-t-260nw-1837676119.jpg",
                    MuscleId = 4, // Lats
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 24,
                    Name = "Lateral Raise",
                    Description = "The best exercise for isolating the side deltoids to build wider shoulders.",
                    ImageUrl = "https://www.shutterstock.com/shutterstock/photos/2044846490/display_1500/stock-vector-man-doing-seated-dumbbell-lateral-raises-power-partials-exercise-flat-vector-illustration-2044846490.jpg",
                    MuscleId = 6, // Shoulders
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 25,
                    Name = "Face Pulls",
                    Description = "Crucial for rear deltoid development and overall shoulder health.",
                    ImageUrl = "https://www.shutterstock.com/image-vector/man-doing-cable-face-pull-600w-1885368556.jpg",
                    MuscleId = 6, // Shoulders
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 26,
                    Name = "Hammer Curl",
                    Description = "Targets the brachialis and the brachioradialis for thicker arms.",
                    ImageUrl = "https://static.vecteezy.com/system/resources/previews/008/572/891/non_2x/man-doing-standing-dumbbell-bicep-hammer-curls-flat-illustration-isolated-on-different-layer-workout-character-vector.jpg",
                    MuscleId = 7, // Biceps
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 27,
                    Name = "Preacher Curl",
                    Description = "Strict isolation for the biceps, preventing momentum.",
                    ImageUrl = "https://static.vecteezy.com/system/resources/previews/017/423/220/non_2x/man-doing-one-arm-dumbbell-preacher-curl-side-view-flat-illustration-isolated-on-different-layer-workout-character-vector.jpg",
                    MuscleId = 7, // Biceps
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 28,
                    Name = "Skull Crushers",
                    Description = "A barbell extension movement that heavily targets the long head of the triceps.",
                    ImageUrl = "https://www.gofitnessplan.com/images/exercises/mixed/dumbbell-triceps-skullcrusher.jpg",
                    MuscleId = 8, // Triceps
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 29,
                    Name = "Tricep Dips",
                    Description = "A heavy compound bodyweight movement for thick triceps and chest.",
                    ImageUrl = "https://www.shutterstock.com/image-vector/chair-tricep-dips-exercise-guide-600nw-2658932277.jpg",
                    MuscleId = 8, // Triceps
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 30,
                    Name = "Bulgarian Split Squat",
                    Description = "A unilateral leg exercise that builds immense quad and glute strength.",
                    ImageUrl = "https://thumbs.dreamstime.com/b/man-doing-bulgarian-split-squats-exercise-flat-vector-illustration-isolated-white-background-man-doing-bulgarian-split-squats-224056268.jpg",
                    MuscleId = 13, // Quads
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 31,
                    Name = "Hack Squat",
                    Description = "A machine variation of the squat that isolates the quads effectively.",
                    ImageUrl = "https://static.vecteezy.com/system/resources/thumbnails/008/418/359/small/man-doing-hack-squat-exercise-flat-illustration-isolated-on-white-background-vector.jpg",
                    MuscleId = 13, // Quads
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 32,
                    Name = "Romanian Deadlift (RDL)",
                    Description = "Focuses entirely on the hamstrings and glutes through a hip hinge.",
                    ImageUrl = "https://www.shutterstock.com/image-vector/woman-doing-romanian-deadlift-exercise-600nw-2118315965.jpg",
                    MuscleId = 14, // Hamstrings
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 33,
                    Name = "Good Mornings",
                    Description = "Builds immense lower back, glute, and hamstring strength.",
                    ImageUrl = "https://thumbs.dreamstime.com/z/basic-rgb-252099603.jpg",
                    MuscleId = 3, // Lower Back
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 34,
                    Name = "Seated Calf Raise",
                    Description = "Targets the soleus muscle of the calves.",
                    ImageUrl = "https://www.shutterstock.com/image-vector/man-doing-seated-dumbbell-chair-600nw-2214158705.jpg",
                    MuscleId = 16, // Calves
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 35,
                    Name = "Farmer's Walk",
                    Description = "A full-body carry that builds extreme grip strength and traps.",
                    ImageUrl = "https://www.shutterstock.com/image-vector/man-doing-single-one-arm-260nw-2389002669.jpg",
                    MuscleId = 9, // Forearms
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 36,
                    Name = "Plank",
                    Description = "An isometric core exercise that builds endurance and stability.",
                    ImageUrl = "https://static.vecteezy.com/system/resources/thumbnails/008/573/039/small/man-doing-plank-abdominals-exercise-flat-illustration-isolated-on-white-background-vector.jpg",
                    MuscleId = 10, // Upper Abs
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 37,
                    Name = "Bicycle Crunches",
                    Description = "Dynamic movement hitting both the rectus abdominis and obliques.",
                    ImageUrl = "https://www.shutterstock.com/image-vector/man-doing-abdominal-workout-bicycle-600nw-1831638793.jpg",
                    MuscleId = 12, // Obliques
                    CreatorId = SeedUserId
                },
                new Exercise
                {
                    Id = 38,
                    Name = "Cable Woodchoppers",
                    Description = "Rotational core movement perfect for athletic performance and obliques.",
                    ImageUrl = "https://static.vecteezy.com/system/resources/previews/006/417/746/non_2x/man-character-doing-downward-cable-wood-chops-exercise-flat-illustration-isolated-on-different-layers-free-vector.jpg",
                    MuscleId = 12, // Obliques
                    CreatorId = SeedUserId
                }
            );
        }
    }
}