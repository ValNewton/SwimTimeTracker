﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SwimTimeTracker.Models;

namespace SwimTimeTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Swimmer> Swimmers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Stroke> Strokes { get; set; }
        public DbSet<Distance> Distances { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Race> Races { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //builder.Entity<Event>()
            //    .HasKey(e => new { e.CourseID, e.StrokeID, e.DistanceID });
        }
    }
}
