using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiparisApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class removeorderdegisimtarihi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatuss_Orders_OrderId",
                table: "OrderStatuss");

            migrationBuilder.DropColumn(
                name: "ord_degisim_tarihi",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderStatuss",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatuss_Orders_OrderId",
                table: "OrderStatuss",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatuss_Orders_OrderId",
                table: "OrderStatuss");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderStatuss",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ord_degisim_tarihi",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatuss_Orders_OrderId",
                table: "OrderStatuss",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
