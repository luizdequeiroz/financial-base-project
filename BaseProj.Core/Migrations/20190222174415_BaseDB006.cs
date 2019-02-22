using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseProj.Core.Migrations
{
    public partial class BaseDB006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DebtorBalance",
                table: "Loans",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DebtorBalanceQtdPart",
                table: "Loans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Loans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebtorBalance",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "DebtorBalanceQtdPart",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Loans");
        }
    }
}
