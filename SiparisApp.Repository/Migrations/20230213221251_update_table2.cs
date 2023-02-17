using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiparisApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class updatetable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sip_durum",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 12, 50, 638, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 12, 50, 638, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 12, 50, 638, DateTimeKind.Local).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 12, 50, 638, DateTimeKind.Local).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 12, 50, 638, DateTimeKind.Local).AddTicks(4498));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sip_durum",
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
        }
    }
}
