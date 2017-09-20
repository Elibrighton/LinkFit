using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LinkFit.Migrations
{
    public partial class AddModelAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramEnrollment",
                table: "ProgramEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_ProgramEnrollment_AthleteID",
                table: "ProgramEnrollment");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ProgramEnrollment");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Athlete");

            migrationBuilder.DropColumn(
                name: "EntrantCategory",
                table: "Athlete");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Athlete");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Athlete");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Athlete",
                newName: "First name");

            migrationBuilder.RenameColumn(
                name: "EnrollmentDate",
                table: "Athlete",
                newName: "Enrollment date");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TrainingProgram",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "TrainingProgram",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "First name",
                table: "Athlete",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Athlete",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramEnrollment",
                table: "ProgramEnrollment",
                columns: new[] { "AthleteID", "TrainingProgramID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramEnrollment",
                table: "ProgramEnrollment");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "TrainingProgram");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Athlete");

            migrationBuilder.RenameColumn(
                name: "First name",
                table: "Athlete",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Enrollment date",
                table: "Athlete",
                newName: "EnrollmentDate");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TrainingProgram",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "ProgramEnrollment",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Athlete",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Athlete",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EntrantCategory",
                table: "Athlete",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Athlete",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Athlete",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramEnrollment",
                table: "ProgramEnrollment",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramEnrollment_AthleteID",
                table: "ProgramEnrollment",
                column: "AthleteID");
        }
    }
}
