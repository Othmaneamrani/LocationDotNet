using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class vehiculeUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "annonce",
                table: "vehicules");

            migrationBuilder.DropColumn(
                name: "kilometrage",
                table: "vehicules");

            migrationBuilder.DropColumn(
                name: "nombreSieges",
                table: "vehicules");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "vehicules",
                newName: "estDispo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "estDispo",
                table: "vehicules",
                newName: "type");

            migrationBuilder.AddColumn<string>(
                name: "annonce",
                table: "vehicules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "kilometrage",
                table: "vehicules",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "nombreSieges",
                table: "vehicules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
