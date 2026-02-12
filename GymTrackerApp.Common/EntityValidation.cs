using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.Common
{
    public static class EntityValidation
    {
        public const int MuscleNameMinLength = 3;
        public const int MuscleNameMaxLength = 50;

        public const int ExerciseNameMinLength = 3;
        public const int ExerciseNameMaxLength = 50;

        public const int ExerciseDescriptionMinLength = 10;
        public const int ExerciseDescriptionMaxLength = 1000;

        public const int ExerciseImageUrlMinLength = 5;
        public const int ExerciseUrlMaxLength = 2048;

        public const int WorkoutTitleMinLength = 3;
        public const int WorkoutTitleMaxLength = 50;

        public const int WorkoutDescriptionMinLength = 10;
        public const int WorkoutDescriptionMaxLength = 1000;
    }
}
