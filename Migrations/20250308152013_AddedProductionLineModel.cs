using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackagingAutomation.Migrations
{
    /// <inheritdoc />
    public partial class AddedProductionLineModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductionLineId",
                table: "PackagingMachines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductionLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionLines", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackagingMachines_ProductionLineId",
                table: "PackagingMachines",
                column: "ProductionLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackagingMachines_ProductionLines_ProductionLineId",
                table: "PackagingMachines",
                column: "ProductionLineId",
                principalTable: "ProductionLines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackagingMachines_ProductionLines_ProductionLineId",
                table: "PackagingMachines");

            migrationBuilder.DropTable(
                name: "ProductionLines");

            migrationBuilder.DropIndex(
                name: "IX_PackagingMachines_ProductionLineId",
                table: "PackagingMachines");

            migrationBuilder.DropColumn(
                name: "ProductionLineId",
                table: "PackagingMachines");
        }
    }
}
