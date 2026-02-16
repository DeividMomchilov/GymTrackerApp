using GymTrackerApp.Data.Models;
using GymTrackerApp.ViewModels.ViewModels.Exercise;
using GymTrackerApp.ViewModels.ViewModels.Workout;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.Services.Contracts
{
    public interface IWorkoutService
    {
        public Task CreateWorkoutAsync(WorkoutFormViewModel model, string userId);

        public Task<IEnumerable<WorkoutViewModel>> GetWorkoutsForTheCurrentUserAsync(string userId);

        public Task<Workout> GetWorkoutByTitleAndCreatorIdAsync(WorkoutFormViewModel model, string userId);

        public Task EditWorkoutAsync(Workout workout, WorkoutFormViewModel model);

        public Task DeleteWorkoutAsync(Workout workout);

        public Task<Workout> GetSpecificWorkoutByIdAndCreatorIdAsync(int id, string userId);

        public Task AddExerciseToWorkoutAsync(WorkoutExerciseFormViewModel model);

        public Task RemoveExerciseFromWorkoutAsync(WorkoutExercise workoutExercise);

        public Task<IEnumerable<ExerciseViewModel>> GetExercisesAsync();

        public Task<Workout> GetDetailedWorkoutAsync(int id, string userId);

        public Task<WorkoutExercise> GetWorkoutExerciseAsync(int workoutId,int exerciseId);
    }
}
