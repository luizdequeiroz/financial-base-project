using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseProj.Core.Migrations
{
    public partial class BaseDB001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    RG = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Cell = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Registration = table.Column<string>(nullable: true),
                    PortalPassword = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    BenefitNumber = table.Column<string>(nullable: true),
                    SIAPNumber = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    Agency = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    Op = table.Column<string>(nullable: true),
                    Observation = table.Column<string>(nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false),
                    Modality = table.Column<int>(nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: true),
                    LoanDate = table.Column<DateTime>(nullable: true),
                    LoanValue = table.Column<decimal>(nullable: false),
                    InstallmentAmount = table.Column<int>(nullable: false),
                    InstallmentValue = table.Column<decimal>(nullable: false),
                    TotalPayable = table.Column<decimal>(nullable: false),
                    BankId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
