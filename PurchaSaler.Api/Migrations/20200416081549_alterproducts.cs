using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaSaler.Api.Migrations
{
    public partial class alterproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photos",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "photo1",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "photo2",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "photo3",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "photo1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "photo2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "photo3",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Photos",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
