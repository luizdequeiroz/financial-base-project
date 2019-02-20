using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseProj.Core.Migrations
{
    public partial class BaseDB005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Cell",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cell",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Clients",
                nullable: false,
                defaultValue: 0);
        }
    }
}
