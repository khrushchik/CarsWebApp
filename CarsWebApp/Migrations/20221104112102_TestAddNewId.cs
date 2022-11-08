using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CarsWebApp.Migrations
{
    public partial class TestAddNewId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_QTables_WTables_WTableId", "QTables");
            migrationBuilder.DropIndex("IX_QTables_WTableId", "QTables");
            migrationBuilder.DropPrimaryKey("PK_WTables", "WTables");

            migrationBuilder.AddColumn<Guid>(
                name: "TestId",
                table: "WTables",
                nullable: true
                );
            
            migrationBuilder.Sql("UPDATE WTables SET TestId = NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "TestWTableId",
                table: "QTables",
                nullable: true
                );

            migrationBuilder.Sql("UPDATE QTables SET QTables.TestWTableId = WTables.TestId FROM QTables INNER JOIN WTables ON QTables.WTableId = WTables.Id");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WTables"
                );

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "WTables",
                newName: "Id"
                );

            migrationBuilder.DropColumn(
                name: "WTableId",
                table: "QTables"
                );

            migrationBuilder.RenameColumn(
                name: "TestWTableId",
                table: "QTables",
                newName: "WTableId"
                );

            //
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "WTables",
                nullable: false,
                oldNullable: true
                );
            migrationBuilder.AlterColumn<Guid>(
                name: "WTableId",
                table: "QTables",
                nullable: false,
                oldNullable: true
                );

            migrationBuilder.AddPrimaryKey("PK_WTables", "WTables", "Id");
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
           
        }
    }
}
