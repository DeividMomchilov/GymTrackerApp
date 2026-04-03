using System.ComponentModel.DataAnnotations;
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

        [MaxLength(MuscleDescriptionMaxLength)]
        public string? Description { get; set; }

        [MaxLength(MuscleImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; } 
            = new HashSet<Exercise>();
    }
}