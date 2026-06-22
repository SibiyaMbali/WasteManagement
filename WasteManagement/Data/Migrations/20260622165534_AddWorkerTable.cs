using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WorkerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_WorkerId",
                table: "Reports",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Workers_WorkerId",
                table: "Reports",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Workers_WorkerId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Reports_WorkerId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Reports");
        }
    }
}
