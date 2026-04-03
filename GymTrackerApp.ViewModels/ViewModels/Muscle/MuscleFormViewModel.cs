using System.ComponentModel.DataAnnotations;
using static GymTrackerApp.Common.EntityValidation;

namespace GymTrackerApp.ViewModels.ViewModels.Muscle
{
    public class MuscleFormViewModel
    {
        [Required]
        [StringLength(MuscleNameMaxLength,MinimumLength = MuscleNameMinLength)]
        public string Name { get; set; } = null!;

        [StringLength(MuscleDescriptionMaxLength, MinimumLength = MuscleDescriptionMinLength)]
        public string? Description { get; set; }

        [Url]
        [StringLength(MuscleImageUrlMaxLength, MinimumLength = MuscleImageUrlMinLength)]
        public string? ImageUrl { get; set; }
    }
}
