using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
        [Range(1,50)]
        public int Sets { get; set; }

        [Required]
        [Range(1, 50)]
        public int Repetitions { get; set; }

        [Required]
        public double Weight { get; set; }
    }
}
