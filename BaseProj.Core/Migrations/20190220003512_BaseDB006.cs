using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseProj.Core.Migrations
{
    public partial class BaseDB006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SIAPNumber",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Clients",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SIAPNumber",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Clients");
        }
    }
}
