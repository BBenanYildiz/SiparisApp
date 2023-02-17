using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiparisApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class updatetable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 16, 39, 219, DateTimeKind.Local).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 16, 39, 219, DateTimeKind.Local).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 16, 39, 219, DateTimeKind.Local).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 16, 39, 219, DateTimeKind.Local).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 1, 16, 39, 219, DateTimeKind.Local).AddTicks(6277));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
