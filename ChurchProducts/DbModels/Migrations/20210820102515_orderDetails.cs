using Microsoft.EntityFrameworkCore.Migrations;

namespace DbModels.Migrations
{
    public partial class orderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_products_productIDFK",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_productIDFK",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "productIDFK",
                table: "orders");

            migrationBuilder.CreateTable(
                name: "orderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productIDFK = table.Column<int>(type: "int", nullable: false),
                    orderIDFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderDetails_orders_orderIDFK",
                        column: x => x.orderIDFK,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderDetails_products_productIDFK",
                        column: x => x.productIDFK,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_orderIDFK",
                table: "orderDetails",
                column: "orderIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_productIDFK",
                table: "orderDetails",
                column: "productIDFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderDetails");

            migrationBuilder.AddColumn<int>(
                name: "productIDFK",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orders_productIDFK",
                table: "orders",
                column: "productIDFK");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_products_productIDFK",
                table: "orders",
                column: "productIDFK",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
