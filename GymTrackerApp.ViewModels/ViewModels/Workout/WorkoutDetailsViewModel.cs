using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.ViewModels.ViewModels.Workout
{
    public class WorkoutDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CreatorId { get; set; } = null!;
        public IEnumerable<WorkoutExerciseViewModel> Exercises { get; set; }
            = new List<WorkoutExerciseViewModel>();
    }
}
