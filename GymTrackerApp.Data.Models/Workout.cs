using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Text;
using Microsoft.AspNetCore.Identity;
using static GymTrackerApp.Common.EntityValidation;


namespace GymTrackerApp.Data.Models
{
    public class Workout
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(WorkoutTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(WorkoutDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        
        public string CreatorId { get; set; } = null!;

        public virtual IdentityUser Creator { get; set; } = null!;

        public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; }
            = new HashSet<WorkoutExercise>();
    }
}
