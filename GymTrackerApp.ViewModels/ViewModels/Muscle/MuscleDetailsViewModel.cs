using GymTrackerApp.ViewModels.ViewModels.Exercise;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.ViewModels.ViewModels.Muscle
{
    public class MuscleDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public IEnumerable<ExerciseViewModel> Exercises { get; set; } 
             = new List<ExerciseViewModel>();
    }
}
