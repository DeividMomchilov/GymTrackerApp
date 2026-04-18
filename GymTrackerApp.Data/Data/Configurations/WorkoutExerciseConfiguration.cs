using GymTrackerApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.Data.Data.Configurations
{
    public class WorkoutExerciseConfiguration : IEntityTypeConfiguration<WorkoutExercise>
    {
        public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
        {
            builder.HasKey(we => new { we.WorkoutId, we.ExerciseId });

            builder.HasOne(we => we.Workout)
                .WithMany(w => w.WorkoutExercises)
                .HasForeignKey(we => we.WorkoutId)
                .OnDelete(DeleteBehavior.Restrict); 
            
            builder.HasOne(we => we.Exercise)
                .WithMany(e => e.WorkoutExercises)
                .HasForeignKey(we => we.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData
            (
                 // ADMIN WORKOUTS 
                 // Workout 1: Full Body Workout
                 new WorkoutExercise { WorkoutId = 1, ExerciseId = 1, Sets = 4, Reps = 6, Weight = 100 },  // Squat
                 new WorkoutExercise { WorkoutId = 1, ExerciseId = 10, Sets = 4, Reps = 8, Weight = 80 },  // Bench Press
                 new WorkoutExercise { WorkoutId = 1, ExerciseId = 11, Sets = 4, Reps = 8, Weight = 0 },   // Pull-up
                 new WorkoutExercise { WorkoutId = 1, ExerciseId = 4, Sets = 3, Reps = 10, Weight = 50 },  // Overhead Press

                 // Workout 2: Upper Body
                 new WorkoutExercise { WorkoutId = 2, ExerciseId = 20, Sets = 4, Reps = 8, Weight = 60 },  // Incline DB Press
                 new WorkoutExercise { WorkoutId = 2, ExerciseId = 23, Sets = 4, Reps = 8, Weight = 70 },  // T-Bar Row
                 new WorkoutExercise { WorkoutId = 2, ExerciseId = 24, Sets = 3, Reps = 12, Weight = 15 }, // Lateral Raise
                 new WorkoutExercise { WorkoutId = 2, ExerciseId = 28, Sets = 3, Reps = 10, Weight = 35 }, // Skull Crushers

                 // Workout 3: Lower Body
                 new WorkoutExercise { WorkoutId = 3, ExerciseId = 2, Sets = 4, Reps = 5, Weight = 120 },  // Deadlift
                 new WorkoutExercise { WorkoutId = 3, ExerciseId = 30, Sets = 3, Reps = 10, Weight = 40 }, // Bulgarian Split Squat
                 new WorkoutExercise { WorkoutId = 3, ExerciseId = 19, Sets = 3, Reps = 12, Weight = 50 }, // Leg Extension

                 // TEST USER WORKOUTS 
                 // Workout 4: Full Body
                 new WorkoutExercise { WorkoutId = 4, ExerciseId = 2, Sets = 4, Reps = 5, Weight = 110 },  // Deadlift
                 new WorkoutExercise { WorkoutId = 4, ExerciseId = 12, Sets = 4, Reps = 15, Weight = 0 },  // Push-up
                 new WorkoutExercise { WorkoutId = 4, ExerciseId = 5, Sets = 4, Reps = 10, Weight = 55 },  // Lat Pulldown

                 // Workout 5: Push
                 new WorkoutExercise { WorkoutId = 5, ExerciseId = 10, Sets = 4, Reps = 8, Weight = 75 },  // Bench Press
                 new WorkoutExercise { WorkoutId = 5, ExerciseId = 4, Sets = 4, Reps = 8, Weight = 45 },   // Overhead Press
                 new WorkoutExercise { WorkoutId = 5, ExerciseId = 29, Sets = 3, Reps = 12, Weight = 0 },  // Tricep Dips
                 new WorkoutExercise { WorkoutId = 5, ExerciseId = 21, Sets = 3, Reps = 12, Weight = 25 }, // Cable Crossover

                 // Workout 6: Pull
                 new WorkoutExercise { WorkoutId = 6, ExerciseId = 11, Sets = 4, Reps = 8, Weight = 0 },   // Pull-up
                 new WorkoutExercise { WorkoutId = 6, ExerciseId = 22, Sets = 4, Reps = 10, Weight = 60 }, // Seated Cable Row
                 new WorkoutExercise { WorkoutId = 6, ExerciseId = 6, Sets = 3, Reps = 10, Weight = 30 },  // Barbell Curl
                 new WorkoutExercise { WorkoutId = 6, ExerciseId = 25, Sets = 3, Reps = 15, Weight = 20 }, // Face Pulls

                 // Workout 7: Legs
                 new WorkoutExercise { WorkoutId = 7, ExerciseId = 1, Sets = 4, Reps = 6, Weight = 95 },   // Squat
                 new WorkoutExercise { WorkoutId = 7, ExerciseId = 32, Sets = 4, Reps = 8, Weight = 80 },  // RDL
                 new WorkoutExercise { WorkoutId = 7, ExerciseId = 8, Sets = 3, Reps = 12, Weight = 40 },  // Leg Curl
                 new WorkoutExercise { WorkoutId = 7, ExerciseId = 9, Sets = 4, Reps = 15, Weight = 60 }   // Calf Raise
            );
        }
    }
}