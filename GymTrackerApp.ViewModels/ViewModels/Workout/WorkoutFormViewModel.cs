using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static GymTrackerApp.Common.EntityValidation;

namespace GymTrackerApp.ViewModels.ViewModels.Workout
{
    public class WorkoutFormViewModel
    {
        [Required]
        [StringLength(WorkoutTitleMaxLength, MinimumLength = WorkoutTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(WorkoutDescriptionMaxLength, MinimumLength = WorkoutDescriptionMinLength)]
        public string Description { get; set; } = null!;
    }
}
