using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static GymTrackerApp.Common.EntityValidation;

namespace GymTrackerApp.Data.Models
{
    public class Muscle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MuscleNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Exercise> Exercises { get; set; } 
            = new HashSet<Exercise>();
    }
}