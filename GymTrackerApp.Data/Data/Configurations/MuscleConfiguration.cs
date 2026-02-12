using GymTrackerApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.Data.Data.Configurations
{
    public class MuscleConfiguration : IEntityTypeConfiguration<Muscle>
    {
        public void Configure(EntityTypeBuilder<Muscle> builder)
        {
            builder.HasData
                (
                    new Muscle { Id = 1, Name = "Chest" },
                    new Muscle { Id = 2, Name = "Upper Back" },
                    new Muscle { Id = 3, Name = "Lower Back" },
                    new Muscle { Id = 4, Name = "Lats" },
                    new Muscle { Id = 5, Name = "Traps" },
                    new Muscle { Id = 6, Name = "Shoulders" },
                    new Muscle { Id = 7, Name = "Biceps" },
                    new Muscle { Id = 8, Name = "Triceps" },
                    new Muscle { Id = 9, Name = "Forearms" },
                    new Muscle { Id = 10, Name = "Upper Abs" },
                    new Muscle { Id = 11, Name = "Lower Abs" },
                    new Muscle { Id = 12, Name = "Obliques" }, 
                    new Muscle { Id = 13, Name = "Quads" },
                    new Muscle { Id = 14, Name = "Hamstrings" },
                    new Muscle { Id = 15, Name = "Glutes" },
                    new Muscle { Id = 16, Name = "Calves" },
                    new Muscle { Id = 18, Name = "Full Body" }
                );
        }
    }
}
