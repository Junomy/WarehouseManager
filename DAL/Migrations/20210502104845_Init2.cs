using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarehouseOrders");

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WarehouseId",
                table: "Orders",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Warehouses_WarehouseId",
                table: "Orders",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Orders_Warehouses_WarehouseId",
            //    table: "Orders");

            //migrationBuilder.DropIndex(
            //    name: "IX_Orders_WarehouseId",
            //    table: "Orders");

            //migrationBuilder.DropColumn(
            //    name: "WarehouseId",
            //    table: "Orders");

            //migrationBuilder.CreateTable(
            //    name: "WarehouseOrders",
            //    columns: table => new
            //    {
            //        OrdersId = table.Column<int>(type: "int", nullable: false),
            //        WarehousesId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_WarehouseOrders", x => new { x.OrdersId, x.WarehousesId });
            //        table.ForeignKey(
            //            name: "FK_WarehouseOrders_Orders_OrdersId",
            //            column: x => x.OrdersId,
            //            principalTable: "Orders",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_WarehouseOrders_Warehouses_WarehousesId",
            //            column: x => x.WarehousesId,
            //            principalTable: "Warehouses",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_WarehouseOrders_WarehousesId",
            //    table: "WarehouseOrders",
            //    column: "WarehousesId");
        }
    }
}
