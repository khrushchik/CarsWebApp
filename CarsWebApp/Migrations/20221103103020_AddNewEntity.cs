using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsWebApp.Migrations
{
    public partial class AddNewEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WTables",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QTables",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WTableId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QTables_WTables_WTableId",
                        column: x => x.WTableId,
                        principalTable: "WTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QTables_WTableId",
                table: "QTables",
                column: "WTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QTables");

            migrationBuilder.DropTable(
                name: "WTables");
        }
    }
}
