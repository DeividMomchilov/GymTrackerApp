using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.ViewModels.ViewModels.Exercise
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string MuscleName { get; set; } = null!;
    }
}
