using GymTrackerApp.ViewModels.ViewModels.Exercise;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static GymTrackerApp.Common.EntityValidation;

namespace GymTrackerApp.ViewModels.ViewModels.Workout
{
    public class WorkoutExerciseFormViewModel
    {
        public int WorkoutId { get; set; }

        public string WorkoutTitle { get; set; } = null!;

        [Required]
        [Display(Name = "Select Exercise")]
        public int ExerciseId { get; set; }

        public IEnumerable<ExerciseViewModel> AvailableExercises { get; set; } 
            = new List<ExerciseViewModel>();

        [Required]
        [Range(SetsMinValue,SetsMaxValue)]
        public int Sets { get; set; }

        [Required]
        [Range(RepsMinValue, RepsMaxValue)]
        public int Reps { get; set; }

        public double Weight { get; set; }
    }
}