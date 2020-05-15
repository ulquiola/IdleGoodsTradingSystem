using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaSaler.Api.Migrations
{
    public partial class ModifyAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "phone",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "County",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "Addresses");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
