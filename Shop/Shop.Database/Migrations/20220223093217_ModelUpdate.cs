using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Database.Migrations
{
    public partial class ModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CharghingTime",
                table: "Specifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Length",
                table: "Specifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Specifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Weigth",
                table: "Specifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Width",
                table: "Specifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AvRating",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharghingTime",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Weigth",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "AvRating",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "Products");
        }
    }
}
