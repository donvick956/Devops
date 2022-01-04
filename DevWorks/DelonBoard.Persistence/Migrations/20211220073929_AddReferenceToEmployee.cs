using Microsoft.EntityFrameworkCore.Migrations;

namespace DelonBoard.Persistence.Migrations.ApplicationDb
{
    public partial class AddReferenceToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reference1Address",
                table: "Employees",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reference1Email",
                table: "Employees",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reference1Name",
                table: "Employees",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reference1Occupation",
                table: "Employees",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reference1PhoneNumber",
                table: "Employees",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reference1PlaceOfWork",
                table: "Employees",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reference1Relationship",
                table: "Employees",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reference2Address",
                table: "Employees",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reference2Email",
                table: "Employees",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reference2Name",
                table: "Employees",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reference2Occupation",
                table: "Employees",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reference2PhoneNumber",
                table: "Employees",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reference2PlaceOfWork",
                table: "Employees",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reference2Relationship",
                table: "Employees",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reference1Address",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Reference1Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Reference1Name",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Reference1Occupation",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Reference1PhoneNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Reference1PlaceOfWork",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Reference1Relationship",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Reference2Address",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Reference2Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Reference2Name",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Reference2Occupation",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Reference2PhoneNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Reference2PlaceOfWork",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Reference2Relationship",
                table: "Employees");
        }
    }
}
