using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.ViewModels.ViewModels.Session
{
    public class WorkoutSessionViewModel
    {
        public int Id { get; set; }
        public string WorkoutTitle { get; set; } = null!;
        public DateTime DateCompleted { get; set; }

        public int DurationInMinutes { get; set; }
    }
}
