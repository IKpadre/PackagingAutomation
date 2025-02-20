using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackagingAutomation.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProductionScheduleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionSchedules_Orders_OrderId",
                table: "ProductionSchedules");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ProductionSchedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ReconfigType",
                table: "ProductionSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionSchedules_Orders_OrderId",
                table: "ProductionSchedules",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionSchedules_Orders_OrderId",
                table: "ProductionSchedules");

            migrationBuilder.DropColumn(
                name: "ReconfigType",
                table: "ProductionSchedules");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ProductionSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionSchedules_Orders_OrderId",
                table: "ProductionSchedules",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
