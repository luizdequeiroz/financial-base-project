using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BaseProj.Core.Migrations
{
    public partial class BaseDB002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CounterCheckPassword",
                table: "Clients",
                newName: "Registration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Registration",
                table: "Clients",
                newName: "CounterCheckPassword");
        }
    }
}
