using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoChefSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RefactorEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "UQ__Dish__A38C5093BFCE1636",
                table: "Dish");

            migrationBuilder.AddColumn<int>(
                name: "DishId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_DishId",
                table: "Order",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_NoodlesId",
                table: "Dish",
                column: "NoodlesId");

            migrationBuilder.AddForeignKey(
                name: "FK__Order__DishId__14270015",
                table: "Order",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "DishId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Order__DishId__14270015",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_DishId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Dish_NoodlesId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "Order");

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__3214EC0770816040", x => x.Id);
                    table.ForeignKey(
                        name: "FK__OrderDeta__DishI__75A278F5",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "DishId");
                    table.ForeignKey(
                        name: "FK__OrderDeta__Order__74AE54BC",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Dish__A38C5093BFCE1636",
                table: "Dish",
                column: "NoodlesId",
                unique: true,
                filter: "[NoodlesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_DishId",
                table: "OrderDetail",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");
        }
    }
}
