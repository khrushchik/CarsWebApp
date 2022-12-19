using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsWebApp.Migrations
{
    public partial class ChangeTypeIdentityQwerty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey("PK_Qwerties", "Qwerties");

            migrationBuilder.AddColumn<Guid>(
                name: "TempId",
                table: "Qwerties",
                nullable: true
                );
            migrationBuilder.Sql("UPDATE Qwerties SET TempId = CAST(Id AS UNIQUEIDENTIFIER)");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Qwerties"
                );

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "Qwerties",
                newName: "Id"
                );

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Qwerties",
                nullable: false,
                oldNullable: true
                );

            migrationBuilder.AddPrimaryKey("PK_Qwerties", "Qwerties", "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Qwerties",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
