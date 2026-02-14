using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static GymTrackerApp.Common.EntityValidation;

namespace GymTrackerApp.Data.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(ExerciseNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ExerciseDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [MaxLength(ExerciseUrlMaxLength)]
        public string? ImageUrl { get; set; }

        [ForeignKey(nameof(Muscle))]
        public int MuscleId { get; set; }

        [Required]
        public virtual Muscle Muscle { get; set; } = null!;

        public string CreatorId { get; set; } = null!;
        public virtual IdentityUser? Creator { get; set; } = null!;

        public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; }
            = new HashSet<WorkoutExercise>();
    }
}