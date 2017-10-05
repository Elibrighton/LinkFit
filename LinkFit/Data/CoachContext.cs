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
        
        public DbSet<ProgramEnrollment> ProgramEnrollments { get; set; }
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramEnrollment>().ToTable("ProgramEnrollment");
            modelBuilder.Entity<TrainingProgram>().ToTable("TrainingProgram");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<Athlete>().ToTable("Person");
            modelBuilder.Entity<Coach>().ToTable("Person");

            modelBuilder.Entity<ProgramEnrollment>()
                .HasKey(c => new { c.AthleteID, c.TrainingProgramID });
        }
    }
}
