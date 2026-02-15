using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static GymTrackerApp.Common.EntityValidation;

namespace GymTrackerApp.ViewModels.ViewModels.Workout
{
    public class WorkoutExerciseViewModel
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; } = null!;
        public string? ExerciseImageUrl { get; set; }
        public string MuscleName { get; set; } = null!;
        public int Sets { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
    }
}