﻿// <auto-generated />
using LinkFit.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace LinkFit.Migrations
{
    [DbContext(typeof(CoachContext))]
    [Migration("20171005082205_SingularizeTables")]
    partial class SingularizeTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LinkFit.Models.Message", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("SentDate");

                    b.HasKey("ID");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("LinkFit.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("OwnerID")
                        .IsRequired();

                    b.Property<int>("RecordStatus");

                    b.Property<string>("Surname")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("LinkFit.Models.ProgramEnrollment", b =>
                {
                    b.Property<int>("AthleteID");

                    b.Property<int>("TrainingProgramID");

                    b.HasKey("AthleteID", "TrainingProgramID");

                    b.HasIndex("TrainingProgramID");

                    b.ToTable("ProgramEnrollment");
                });

            modelBuilder.Entity("LinkFit.Models.TrainingProgram", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cost");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("TrainingProgram");
                });

            modelBuilder.Entity("LinkFit.Models.Athlete", b =>
                {
                    b.HasBaseType("LinkFit.Models.Person");

                    b.Property<DateTime>("EnrollmentDate");

                    b.ToTable("Person");

                    b.HasDiscriminator().HasValue("Athlete");
                });

            modelBuilder.Entity("LinkFit.Models.Coach", b =>
                {
                    b.HasBaseType("LinkFit.Models.Person");

                    b.Property<DateTime>("HireDate");

                    b.ToTable("Person");

                    b.HasDiscriminator().HasValue("Coach");
                });

            modelBuilder.Entity("LinkFit.Models.ProgramEnrollment", b =>
                {
                    b.HasOne("LinkFit.Models.Athlete", "Athlete")
                        .WithMany("ProgramEnrollments")
                        .HasForeignKey("AthleteID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LinkFit.Models.TrainingProgram", "TrainingProgram")
                        .WithMany("ProgramEnrollments")
                        .HasForeignKey("TrainingProgramID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
