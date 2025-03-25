using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackagingAutomation.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPackagingMachineModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackagingMachines_ProductionLines_ProductionLineId",
                table: "PackagingMachines");

            migrationBuilder.AlterColumn<int>(
                name: "ProductionLineId",
                table: "PackagingMachines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PackagingMachines_ProductionLines_ProductionLineId",
                table: "PackagingMachines",
                column: "ProductionLineId",
                principalTable: "ProductionLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackagingMachines_ProductionLines_ProductionLineId",
                table: "PackagingMachines");

            migrationBuilder.AlterColumn<int>(
                name: "ProductionLineId",
                table: "PackagingMachines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PackagingMachines_ProductionLines_ProductionLineId",
                table: "PackagingMachines",
                column: "ProductionLineId",
                principalTable: "ProductionLines",
                principalColumn: "Id");
        }
    }
}
