using GymTrackerApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.Data.Data.Configurations
{
    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            const string AdminId = "11111111-2222-3333-4444-555555555555";
            const string TestUserId = "22222222-3333-4444-5555-666666666666";

            builder.HasData(
                new Workout
                {
                    Id = 1,
                    Title = "Full Body Workout",
                    Description = "A comprehensive workout targeting all major muscle groups.",
                    CreatorId = AdminId
                },
                new Workout
                {
                    Id = 2,
                    Title = "Upper Body",
                    Description = "Focuses on building strength in the upper body.",
                    CreatorId = AdminId
                },
                new Workout
                {
                    Id = 3,
                    Title = "Lower Body",
                    Description = "Targets the lower body muscles for strength and endurance.",
                    CreatorId = AdminId
                }
                , 
                new Workout
                {
                    Id = 4,
                    Title = "Full Body",
                    Description = "A comprehensive workout targeting all major muscle groups in the body.",
                    CreatorId = TestUserId
                },
                new Workout
                {
                    Id = 5,
                    Title = "Push",
                    Description = "Focuses on building strength in the pushing muscles.",
                    CreatorId = TestUserId
                },
                new Workout
                {
                    Id = 6,
                    Title = "Pull",
                    Description = "Targets the pulling muscles for strength and endurance.",
                    CreatorId = TestUserId
                },
                new Workout
                {
                    Id = 7,
                    Title = "Legs",
                    Description = "Focuses on building strength in the leg muscles.",
                    CreatorId = TestUserId
                }
                );
        }
    }
}
