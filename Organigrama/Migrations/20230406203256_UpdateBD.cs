using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organigrama.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "WorkStation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BossId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NroDocumento",
                table: "Employee",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "WorkStation");

            migrationBuilder.DropColumn(
                name: "BossId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "NroDocumento",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
