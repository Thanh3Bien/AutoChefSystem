using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoChefSystem.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StepTaskId",
                table: "RobotStepTask",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
                //.Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Recipe",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Recipe");

            migrationBuilder.AlterColumn<int>(
                name: "StepTaskId",
                table: "RobotStepTask",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
                //.OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
