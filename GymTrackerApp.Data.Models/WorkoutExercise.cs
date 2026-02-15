using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static GymTrackerApp.Common.EntityValidation;

namespace GymTrackerApp.Data.Models
{
    public class WorkoutExercise
    {
        [ForeignKey(nameof(Workout))]
        public int WorkoutId { get; set; }

        [Required]
        public virtual Workout Workout { get; set; } = null!;

        [ForeignKey(nameof(Exercise))]
        public int ExerciseId { get; set; } 

        [Required]
        public virtual Exercise Exercise { get; set; } = null!;

        [Required]
        [Range(SetsMinValue, SetsMaxValue)]
        public int Sets { get; set; }

        [Required]
        [Range(RepsMinValue, RepsMaxValue)]
        public int Reps { get; set; }

        [Required]
        public double Weight { get; set; }
    }
}
