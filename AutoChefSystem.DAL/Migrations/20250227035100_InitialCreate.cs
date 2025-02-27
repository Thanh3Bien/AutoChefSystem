using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoChefSystem.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__E7FEA49726A610A3", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recipe__FDD988B070C73FCA", x => x.RecipeId);
                });

            migrationBuilder.CreateTable(
                name: "RobotType",
                columns: table => new
                {
                    RobotTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RobotTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RobotTyp__B4BB3C4D0B11CC04", x => x.RobotTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__8AFACE1AA8C07C01", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "RecipeStep",
                columns: table => new
                {
                    StepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    StepDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StepNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RecipeSt__24343357B09B0472", x => x.StepId);
                    table.ForeignKey(
                        name: "FK_RecipeStep_Recipe",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId");
                });

            migrationBuilder.CreateTable(
                name: "Robot",
                columns: table => new
                {
                    RobotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RobotTypeId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Robot__FBB3324148DE6123", x => x.RobotId);
                    table.ForeignKey(
                        name: "FK_Robot_Location",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_Robot_RobotType",
                        column: x => x.RobotTypeId,
                        principalTable: "RobotType",
                        principalColumn: "RobotTypeId");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserFullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__1788CC4C449E6D91", x => x.UserId);
                    table.ForeignKey(
                        name: "FK__User__RoleId__4CA06362",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "RobotStepTask",
                columns: table => new
                {
                    StepTaskId = table.Column<int>(type: "int", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TaskOrder = table.Column<int>(type: "int", nullable: false),
                    EstimatedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    RepeatCount = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RobotSte__45192A89670340D3", x => x.StepTaskId);
                    table.ForeignKey(
                        name: "FK_RobotStepTask_StepId",
                        column: x => x.StepId,
                        principalTable: "RecipeStep",
                        principalColumn: "StepId");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    RobotId = table.Column<int>(type: "int", nullable: false),
                    OrderedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompletedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order__C3905BCFCF563AD0", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Location",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_Order_Recipe",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId");
                    table.ForeignKey(
                        name: "FK_Order_Robot",
                        column: x => x.RobotId,
                        principalTable: "Robot",
                        principalColumn: "RobotId");
                });

            migrationBuilder.CreateTable(
                name: "RobotOperationLog",
                columns: table => new
                {
                    RobotOperationLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    RobotId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompletionStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OperationLog = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RobotOpe__19FE31E8F59DCC6F", x => x.RobotOperationLogId);
                    table.ForeignKey(
                        name: "FK_RobotOperationLog_Order",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_RobotOperationLog_Robot",
                        column: x => x.RobotId,
                        principalTable: "Robot",
                        principalColumn: "RobotId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_LocationId",
                table: "Order",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RecipeId",
                table: "Order",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RobotId",
                table: "Order",
                column: "RobotId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeStep_RecipeId",
                table: "RecipeStep",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Robot_LocationId",
                table: "Robot",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Robot_RobotTypeId",
                table: "Robot",
                column: "RobotTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RobotOperationLog_OrderId",
                table: "RobotOperationLog",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_RobotOperationLog_RobotId",
                table: "RobotOperationLog",
                column: "RobotId");

            migrationBuilder.CreateIndex(
                name: "IX_RobotStepTask_StepId",
                table: "RobotStepTask",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RobotOperationLog");

            migrationBuilder.DropTable(
                name: "RobotStepTask");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "RecipeStep");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Robot");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "RobotType");
        }
    }
}
