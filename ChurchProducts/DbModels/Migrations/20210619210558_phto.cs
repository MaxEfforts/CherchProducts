using Microsoft.EntityFrameworkCore.Migrations;

namespace DbModels.Migrations
{
    public partial class phto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImgPath",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImgPath",
                table: "products");
        }
    }
}
