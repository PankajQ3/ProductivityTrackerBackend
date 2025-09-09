using Microsoft.EntityFrameworkCore;
using ProductivityTrackerBackend.Models;

namespace ProductivityTrackerBackend.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Check if data already exists
                if (context.Users.Any() || context.Goals.Any() || context.Items.Any() || context.TimeLogs.Any())
                {
                    return; // Database has been seeded already
                }

                // Seed Users
                var user = new User
                {
                    Username = "john_doe",
                    Email = "john.doe@example.com",
                    PasswordHash = "hashed_password" // Example hashed password
                };
                context.Users.Add(user);
                context.SaveChanges();

                // Seed Goals
                var goal = new Goal
                {
                    Title = "Learn a New Programming Language",
                    Description = "Spend time learning C# by completing a project.",
                    TargetValue = 100,
                    ProgressValue = 30,
                    Unit = "Hours",
                    StartDate = DateTime.UtcNow.AddDays(-10),
                    EndDate = DateTime.UtcNow.AddMonths(1),
                    IsCompleted = false,
                    UserId = user.Id
                };
                context.Goals.Add(goal);
                context.SaveChanges();

                // Seed Items
                var item1 = new Item
                {
                    Title = "Complete C# Basics",
                    Description = "Go through tutorials and complete basic exercises.",
                    Category = "Learning",
                    Deadline = DateTime.UtcNow.AddDays(5),
                    Completed = false,
                    GoalId = goal.Id,
                    CreatedAt = DateTime.UtcNow
                };

                var item2 = new Item
                {
                    Title = "Build a C# Project",
                    Description = "Create a simple productivity tracker using C# and EF Core.",
                    Category = "Project",
                    Deadline = DateTime.UtcNow.AddDays(10),
                    Completed = false,
                    GoalId = goal.Id,
                    CreatedAt = DateTime.UtcNow
                };

                context.Items.AddRange(item1, item2);
                context.SaveChanges();

                // Seed TimeLogs
                var timeLog1 = new TimeLog
                {
                    StartTime = DateTime.UtcNow.AddHours(-4),
                    EndTime = DateTime.UtcNow.AddHours(-2),
                    DurationInMinutes = 120,
                    ItemId = item1.Id
                };

                var timeLog2 = new TimeLog
                {
                    StartTime = DateTime.UtcNow.AddDays(-1).AddHours(-3),
                    EndTime = DateTime.UtcNow.AddDays(-1).AddHours(-1),
                    DurationInMinutes = 120,
                    ItemId = item2.Id
                };

                context.TimeLogs.AddRange(timeLog1, timeLog2);
                context.SaveChanges();
            }
        }
    }
}