using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoChefSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RefactorEntityForRobot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Order__DishId__14270015",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK__Order__Phone__693CA210",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Broths");

            migrationBuilder.DropTable(
                name: "Noodles");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Order__C3905BCF668B17E3",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_DishId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_Phone",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Order",
                newName: "OrderedTime");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Order",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedTime",
                table: "Order",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RobotId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Order__C3905BCFCF563AD0",
                table: "Order",
                column: "OrderId");

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
                name: "RobotTask",
                columns: table => new
                {
                    RobotTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RobotTaskName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EstimatedTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RobotTas__52CCC00BF0F4ACD9", x => x.RobotTaskId);
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
                name: "StepTask",
                columns: table => new
                {
                    StepTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    TaskOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StepTask__45192A89CDCABAFE", x => x.StepTaskId);
                    table.ForeignKey(
                        name: "FK_StepTask_RecipeStep",
                        column: x => x.StepId,
                        principalTable: "RecipeStep",
                        principalColumn: "StepId");
                    table.ForeignKey(
                        name: "FK_StepTask_RobotTask",
                        column: x => x.TaskId,
                        principalTable: "RobotTask",
                        principalColumn: "RobotTaskId");
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
                name: "IX_StepTask_StepId",
                table: "StepTask",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_StepTask_TaskId",
                table: "StepTask",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Location",
                table: "Order",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Recipe",
                table: "Order",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Robot",
                table: "Order",
                column: "RobotId",
                principalTable: "Robot",
                principalColumn: "RobotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Location",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Recipe",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Robot",
                table: "Order");

            migrationBuilder.DropTable(
                name: "RobotOperationLog");

            migrationBuilder.DropTable(
                name: "StepTask");

            migrationBuilder.DropTable(
                name: "Robot");

            migrationBuilder.DropTable(
                name: "RecipeStep");

            migrationBuilder.DropTable(
                name: "RobotTask");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "RobotType");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Order__C3905BCFCF563AD0",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_LocationId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_RecipeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_RobotId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CompletedTime",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "RobotId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "OrderedTime",
                table: "Order",
                newName: "OrderDate");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Order",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "DishId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Order",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Order__C3905BCF668B17E3",
                table: "Order",
                column: "OrderId");

            migrationBuilder.CreateTable(
                name: "Broths",
                columns: table => new
                {
                    BrothsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrothsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Broths__9F37327F45A2D929", x => x.BrothsId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__5C7E359F03449E5C", x => x.Phone);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ingredie__BEAEB25A2BFFBF74", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Noodles",
                columns: table => new
                {
                    NoodlesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    NoodlesName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Noodles__A38C5092C0E02B25", x => x.NoodlesId);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feedback__6A4BEDD6B680CDB9", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK__Feedback__OrderI__70DDC3D8",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK__Feedback__Phone__6FE99F9F",
                        column: x => x.Phone,
                        principalTable: "Customer",
                        principalColumn: "Phone");
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrothsId = table.Column<int>(type: "int", nullable: true),
                    NoodlesId = table.Column<int>(type: "int", nullable: true),
                    DishName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dish__18834F50F2AD62CC", x => x.DishId);
                    table.ForeignKey(
                        name: "FK__Dish__BrothsId__59FA5E80",
                        column: x => x.BrothsId,
                        principalTable: "Broths",
                        principalColumn: "BrothsId");
                    table.ForeignKey(
                        name: "FK__Dish__NoodlesId__59063A47",
                        column: x => x.NoodlesId,
                        principalTable: "Noodles",
                        principalColumn: "NoodlesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_DishId",
                table: "Order",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Phone",
                table: "Order",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_BrothsId",
                table: "Dish",
                column: "BrothsId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_NoodlesId",
                table: "Dish",
                column: "NoodlesId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_Phone",
                table: "Feedback",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "UQ_FeedbackOrder",
                table: "Feedback",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK__Order__DishId__14270015",
                table: "Order",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK__Order__Phone__693CA210",
                table: "Order",
                column: "Phone",
                principalTable: "Customer",
                principalColumn: "Phone");
        }
    }
}
