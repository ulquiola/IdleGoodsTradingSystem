using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaSaler.Api.Migrations
{
    public partial class addfieldincart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImg",
                table: "ShoppingCarts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "ShoppingCarts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImg",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "ShoppingCarts");
        }
    }
}
