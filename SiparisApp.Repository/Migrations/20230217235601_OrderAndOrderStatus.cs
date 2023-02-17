using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiparisApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class OrderAndOrderStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderStatuss",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatuss_OrderId",
                table: "OrderStatuss",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatuss_Orders_OrderId",
                table: "OrderStatuss",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatuss_Orders_OrderId",
                table: "OrderStatuss");

            migrationBuilder.DropIndex(
                name: "IX_OrderStatuss_OrderId",
                table: "OrderStatuss");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderStatuss");
        }
    }
}
