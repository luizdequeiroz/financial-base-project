using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseProj.Core.Migrations
{
    public partial class BaseDB002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "Loans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observation",
                table: "Loans");
        }
    }
}
