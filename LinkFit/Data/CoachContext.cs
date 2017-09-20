using LinkFit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkFit.Data
{
    public class CoachContext : DbContext
    {
        public CoachContext(DbContextOptions<CoachContext> options) : base(options)
        {
        }

        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<ProgramEnrollment> ProgramEnrollments { get; set; }
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>().ToTable("Athlete");
            modelBuilder.Entity<ProgramEnrollment>().ToTable("ProgramEnrollment");
            modelBuilder.Entity<TrainingProgram>().ToTable("TrainingProgram");


            modelBuilder.Entity<ProgramEnrollment>()
                .HasKey(c => new { c.AthleteID, c.TrainingProgramID });
        }
    }
}
