using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class compteProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "comptes");

            migrationBuilder.DropColumn(
                name: "cin",
                table: "comptes");

            migrationBuilder.DropColumn(
                name: "nom",
                table: "comptes");

            migrationBuilder.DropColumn(
                name: "prenom",
                table: "comptes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "comptes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "cin",
                table: "comptes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nom",
                table: "comptes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "prenom",
                table: "comptes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
