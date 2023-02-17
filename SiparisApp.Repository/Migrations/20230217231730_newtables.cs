using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SiparisApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class newtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuss_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderStatuss",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "OrderStatuss",
                newName: "ord_sta_musteri_no");

            migrationBuilder.RenameColumn(
                name: "sip_varis_adres",
                table: "Orders",
                newName: "ord_varis_adres");

            migrationBuilder.RenameColumn(
                name: "sip_not",
                table: "Orders",
                newName: "ord_not");

            migrationBuilder.RenameColumn(
                name: "sip_musteri_no",
                table: "Orders",
                newName: "ord_musteri_no");

            migrationBuilder.RenameColumn(
                name: "sip_miktar_birim",
                table: "Orders",
                newName: "ord_miktar_birim");

            migrationBuilder.RenameColumn(
                name: "sip_miktar",
                table: "Orders",
                newName: "ord_miktar");

            migrationBuilder.RenameColumn(
                name: "sip_malzeme_kodu",
                table: "Orders",
                newName: "ord_malzeme_kodu");

            migrationBuilder.RenameColumn(
                name: "sip_malzeme_adi",
                table: "Orders",
                newName: "ord_malzeme_adi");

            migrationBuilder.RenameColumn(
                name: "sip_cikis_adres",
                table: "Orders",
                newName: "ord_durum");

            migrationBuilder.RenameColumn(
                name: "sip_agirlik_birim",
                table: "Orders",
                newName: "ord_cikis_adres");

            migrationBuilder.RenameColumn(
                name: "sip_agirlik",
                table: "Orders",
                newName: "ord_agirlik");

            migrationBuilder.AddColumn<DateTime>(
                name: "ord_sta_degisim_tarihi",
                table: "OrderStatuss",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ord_sta_durum",
                table: "OrderStatuss",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ord_agirlik_birim",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ord_degisim_tarihi",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ord_sta_degisim_tarihi",
                table: "OrderStatuss");

            migrationBuilder.DropColumn(
                name: "ord_sta_durum",
                table: "OrderStatuss");

            migrationBuilder.DropColumn(
                name: "ord_agirlik_birim",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ord_degisim_tarihi",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ord_sta_musteri_no",
                table: "OrderStatuss",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ord_varis_adres",
                table: "Orders",
                newName: "sip_varis_adres");

            migrationBuilder.RenameColumn(
                name: "ord_not",
                table: "Orders",
                newName: "sip_not");

            migrationBuilder.RenameColumn(
                name: "ord_musteri_no",
                table: "Orders",
                newName: "sip_musteri_no");

            migrationBuilder.RenameColumn(
                name: "ord_miktar_birim",
                table: "Orders",
                newName: "sip_miktar_birim");

            migrationBuilder.RenameColumn(
                name: "ord_miktar",
                table: "Orders",
                newName: "sip_miktar");

            migrationBuilder.RenameColumn(
                name: "ord_malzeme_kodu",
                table: "Orders",
                newName: "sip_malzeme_kodu");

            migrationBuilder.RenameColumn(
                name: "ord_malzeme_adi",
                table: "Orders",
                newName: "sip_malzeme_adi");

            migrationBuilder.RenameColumn(
                name: "ord_durum",
                table: "Orders",
                newName: "sip_cikis_adres");

            migrationBuilder.RenameColumn(
                name: "ord_cikis_adres",
                table: "Orders",
                newName: "sip_agirlik_birim");

            migrationBuilder.RenameColumn(
                name: "ord_agirlik",
                table: "Orders",
                newName: "sip_agirlik");

            migrationBuilder.AddColumn<int>(
                name: "OrderStatusId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "OrderStatuss",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 14, 1, 16, 39, 219, DateTimeKind.Local).AddTicks(6227), "Sipariş Alındı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 2, 14, 1, 16, 39, 219, DateTimeKind.Local).AddTicks(6257), "Yola Çıktı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 2, 14, 1, 16, 39, 219, DateTimeKind.Local).AddTicks(6264), "Dağıtım Merkezinde", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 2, 14, 1, 16, 39, 219, DateTimeKind.Local).AddTicks(6271), "Teslim Edildi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 2, 14, 1, 16, 39, 219, DateTimeKind.Local).AddTicks(6277), "Teslim Edilemedi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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
    }
}
