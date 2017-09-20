using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LinkFit.Migrations
{
    public partial class FixDbColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "First name",
                table: "Athlete",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Enrollment date",
                table: "Athlete",
                newName: "EnrollmentDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Athlete",
                newName: "First name");

            migrationBuilder.RenameColumn(
                name: "EnrollmentDate",
                table: "Athlete",
                newName: "Enrollment date");
        }
    }
}
