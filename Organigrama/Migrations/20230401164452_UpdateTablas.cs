using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organigrama.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_WorkStation_WorkStationId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "WorkStationId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_WorkStation_WorkStationId",
                table: "Employee",
                column: "WorkStationId",
                principalTable: "WorkStation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_WorkStation_WorkStationId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "WorkStationId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_WorkStation_WorkStationId",
                table: "Employee",
                column: "WorkStationId",
                principalTable: "WorkStation",
                principalColumn: "Id");
        }
    }
}
