using GymTrackerApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymTrackerApp.Data.Data.Configurations
{
    public class MuscleConfiguration : IEntityTypeConfiguration<Muscle>
    {
        public void Configure(EntityTypeBuilder<Muscle> builder)
        {
            builder.HasData(
                new Muscle
                {
                    Id = 1,
                    Name = "Chest",
                    Description = "The pectoralis major makes up the bulk of the chest muscles. It is responsible for movement of the shoulder joint and arms across the body.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Chest"
                },
                new Muscle
                {
                    Id = 2,
                    Name = "Upper Back",
                    Description = "Includes the rhomboids and upper latissimus dorsi. These muscles pull the shoulder blades together and help maintain proper posture.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Upper+Back"
                },
                new Muscle
                {
                    Id = 3,
                    Name = "Lower Back",
                    Description = "The erector spinae muscles support the spine and allow for extending the back. Crucial for core stability and lifting.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Lower+Back"
                },
                new Muscle
                {
                    Id = 4,
                    Name = "Lats",
                    Description = "The latissimus dorsi is the largest muscle in the upper body, responsible for pulling actions and giving the back its V-taper.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Lats"
                },
                new Muscle
                {
                    Id = 5,
                    Name = "Traps",
                    Description = "The trapezius muscles run down the neck and middle back. They elevate and depress the shoulder blades.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Traps"
                },
                new Muscle
                {
                    Id = 6,
                    Name = "Shoulders",
                    Description = "The deltoids consist of three heads (anterior, lateral, and posterior) that allow the arms to lift and rotate in all directions.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Shoulders"
                },
                new Muscle
                {
                    Id = 7,
                    Name = "Biceps",
                    Description = "The biceps brachii sits on the front of the upper arm and is responsible for elbow flexion (curling) and forearm rotation.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Biceps"
                },
                new Muscle
                {
                    Id = 8,
                    Name = "Triceps",
                    Description = "The triceps brachii makes up about 2/3 of the upper arm's mass. It consists of three heads responsible for extending the elbow.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Triceps"
                },
                new Muscle
                {
                    Id = 9,
                    Name = "Forearms",
                    Description = "A complex group of smaller muscles responsible for grip strength, wrist flexion, and extension.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Forearms"
                },
                new Muscle
                {
                    Id = 10,
                    Name = "Abs",
                    Description = "The rectus abdominis is the front core muscle layer. It flexes the spine and provides essential core stabilization.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Abs"
                },
                new Muscle
                {
                    Id = 11,
                    Name = "Obliques",
                    Description = "Situated on the sides of the abdomen, these muscles handle rotational movements and lateral flexion of the torso.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Obliques"
                },
                new Muscle
                {
                    Id = 12,
                    Name = "Glutes",
                    Description = "The gluteus maximus is one of the strongest muscles in the human body, serving as the main extensor of the hip.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Glutes"
                },
                new Muscle
                {
                    Id = 13,
                    Name = "Quads",
                    Description = "The quadriceps femoris consists of four large muscles on the front of the thigh that extend the knee.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Quads"
                },
                new Muscle
                {
                    Id = 14,
                    Name = "Hamstrings",
                    Description = "Located on the back of the thigh, these muscles are responsible for knee flexion and assist in hip extension.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Hamstrings"
                },
                new Muscle
                {
                    Id = 15,
                    Name = "Adductors",
                    Description = "The inner thigh muscles that pull the legs together toward the midline of the body.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Adductors"
                },
                new Muscle
                {
                    Id = 16,
                    Name = "Calves",
                    Description = "Consisting of the gastrocnemius and soleus, these lower leg muscles act to flex the foot and ankle.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Calves"
                },
                new Muscle
                {
                    Id = 17,
                    Name = "Neck",
                    Description = "Various muscles supporting the cervical spine, responsible for rotating and bending the head.",
                    ImageUrl = "https://placehold.co/600x400/212529/0dcaf0?text=Neck"
                }
            );
        }
    }
}