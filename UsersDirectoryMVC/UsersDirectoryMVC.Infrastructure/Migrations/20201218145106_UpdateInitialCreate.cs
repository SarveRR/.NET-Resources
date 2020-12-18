using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersDirectoryMVC.Infrastructure.Migrations
{
    public partial class UpdateInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CEOFisrtName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEOLastName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Customers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEOFisrtName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CEOLastName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Customers");
        }
    }
}
