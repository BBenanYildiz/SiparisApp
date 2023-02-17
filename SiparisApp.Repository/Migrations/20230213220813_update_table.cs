using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiparisApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class updatetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatusId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 8, 12, 593, DateTimeKind.Local).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 8, 12, 593, DateTimeKind.Local).AddTicks(7014));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 8, 12, 593, DateTimeKind.Local).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 8, 12, 593, DateTimeKind.Local).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 8, 12, 593, DateTimeKind.Local).AddTicks(7027));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuss_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatuss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuss_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5536));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5592));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5599));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5605));
        }
    }
}
