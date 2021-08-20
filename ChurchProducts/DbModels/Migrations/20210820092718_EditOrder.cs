using Microsoft.EntityFrameworkCore.Migrations;

namespace DbModels.Migrations
{
    public partial class EditOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_UserIDFK",
                table: "orders");

            migrationBuilder.AlterColumn<string>(
                name: "UserIDFK",
                table: "orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_UserIDFK",
                table: "orders",
                column: "UserIDFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_UserIDFK",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "orders");

            migrationBuilder.AlterColumn<string>(
                name: "UserIDFK",
                table: "orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_UserIDFK",
                table: "orders",
                column: "UserIDFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
