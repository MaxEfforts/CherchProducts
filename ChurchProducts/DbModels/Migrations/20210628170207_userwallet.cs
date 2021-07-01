using Microsoft.EntityFrameworkCore.Migrations;

namespace DbModels.Migrations
{
    public partial class userwallet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserPalance",
                table: "userWallets",
                newName: "Balance");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImgPath",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "userWallets",
                newName: "UserPalance");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImgPath",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
