using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsWebApp.Migrations
{
    public partial class ChangeStringIdToGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey("PK_QTables", "QTables");

            migrationBuilder.AddColumn<Guid>(
                name: "TempId",
                table: "QTables",
                nullable: true
                );

            migrationBuilder.Sql("UPDATE QTables SET TempId = CAST(Id AS UNIQUEIDENTIFIER)");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "QTables"
                );

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "QTables",
                newName: "Id"
                );

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QTables",
                nullable: false,
                oldNullable: true
                );

            ///

            migrationBuilder.DropForeignKey("FK_QTables_WTables_WTableId", "QTables");
            migrationBuilder.DropIndex("IX_QTables_WTableId", "QTables");

            migrationBuilder.AddColumn<Guid>(
                name: "TempWTableId",
                table: "QTables",
                nullable: true
                );

            migrationBuilder.Sql("UPDATE QTables SET TempWTableId = CAST(WTableId AS UNIQUEIDENTIFIER)");

            migrationBuilder.DropColumn(
                name: "WTableId",
                table: "QTables"
                );

            migrationBuilder.RenameColumn(
                name: "TempWTableId",
                table: "QTables",
                newName: "WTableId"
                );

            migrationBuilder.AlterColumn<Guid>(
                name: "WTableId",
                table: "QTables",
                nullable: false,
                oldNullable: true
                );
            ///
            migrationBuilder.DropPrimaryKey("PK_WTables", "WTables");
            
            migrationBuilder.AddColumn<Guid>(
                name: "TempId",
                table: "WTables",
                nullable: true
                );

            migrationBuilder.Sql("UPDATE WTables SET TempId = CAST(Id AS UNIQUEIDENTIFIER)");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WTables"
                );

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "WTables",
                newName: "Id"
                );

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "WTables",
                nullable: false,
                oldNullable: true
                );

            ///
            migrationBuilder.AddPrimaryKey("PK_WTables", "WTables", "Id");
            migrationBuilder.AddPrimaryKey("PK_QTables", "QTables", "Id");
            migrationBuilder.AddForeignKey(
                name: "FK_QTables_WTables_WTableId",
                table: "QTables",
                column: "WTableId",
                principalTable: "WTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.CreateIndex(
                name: "IX_QTables_WTableId",
                table: "QTables",
                column: "WTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "WTables",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "WTableId",
                table: "QTables",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "QTables",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
