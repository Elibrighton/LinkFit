using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LinkFit.Migrations
{
    public partial class AthleteEntrantCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramEnrollment");

            migrationBuilder.DropTable(
                name: "Athlete");

            migrationBuilder.DropTable(
                name: "TrainingProgram");

            migrationBuilder.CreateTable(
                name: "Athlete",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntrantCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athlete", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgram",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingProgram", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProgramEnrollment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AthleteID = table.Column<int>(type: "int", nullable: false),
                    TrainingProgramID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramEnrollment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProgramEnrollment_Athlete_AthleteID",
                        column: x => x.AthleteID,
                        principalTable: "Athlete",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramEnrollment_TrainingProgram_TrainingProgramID",
                        column: x => x.TrainingProgramID,
                        principalTable: "TrainingProgram",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramEnrollment_AthleteID",
                table: "ProgramEnrollment",
                column: "AthleteID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramEnrollment_TrainingProgramID",
                table: "ProgramEnrollment",
                column: "TrainingProgramID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramEnrollment");

            migrationBuilder.DropTable(
                name: "Athlete");

            migrationBuilder.DropTable(
                name: "TrainingProgram");
        }
    }
}
