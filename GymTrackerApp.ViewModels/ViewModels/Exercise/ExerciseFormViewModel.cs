using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static GymTrackerApp.Common.EntityValidation;

namespace GymTrackerApp.ViewModels.ViewModels
{
    public class ExerciseFormViewModel
    {
        [Required]
        [StringLength(ExerciseNameMaxLength,MinimumLength = ExerciseNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ExerciseDescriptionMaxLength, MinimumLength = ExerciseDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [StringLength(ExerciseUrlMaxLength,MinimumLength = ExerciseImageUrlMinLength)]
        public string? ImageUrl { get; set; }

        [Required]
        public int MuscleId { get; set; }

        public IEnumerable<MuscleViewModel> Muscles { get; set; } = new List<MuscleViewModel>();
    }
}
