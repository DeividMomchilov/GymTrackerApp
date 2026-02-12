using GymTrackerApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore;

namespace GymTrackerApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public virtual DbSet<Exercise> Exercises { get; set; } 
        public virtual DbSet<Muscle> Muscles { get; set; } 
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    }
}