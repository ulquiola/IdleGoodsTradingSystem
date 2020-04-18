using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaSaler.Api.Migrations
{
    public partial class altershoppingcart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<double>(
                name: "TotalAmount",
                table: "ShoppingCarts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
