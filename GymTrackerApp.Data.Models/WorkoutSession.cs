using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymTrackerApp.Data.Models
{
    public class WorkoutSession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public int WorkoutId { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public virtual Workout Workout { get; set; } = null!;

        [Required]
        public DateTime DateCompleted { get; set; }

        public int DurationInMinutes { get; set; }
    }
}
