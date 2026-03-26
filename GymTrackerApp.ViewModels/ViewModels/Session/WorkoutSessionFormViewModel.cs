using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static GymTrackerApp.Common.EntityValidation;

namespace GymTrackerApp.ViewModels.ViewModels.Session
{
    public class WorkoutSessionFormViewModel
    {
        public int WorkoutId { get; set; }

        [Range(SessionDurationMinValue,SessionDurationMaxValue)]
        public int DurationInMinutes { get; set; }
    }
}
