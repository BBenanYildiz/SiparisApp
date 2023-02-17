using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SiparisApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class databasecreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    matkodu = table.Column<string>(name: "mat_kodu", type: "nvarchar(max)", nullable: false),
                    matadi = table.Column<string>(name: "mat_adi", type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sipmusterino = table.Column<string>(name: "sip_musteri_no", type: "nvarchar(max)", nullable: false),
                    sipcikisadres = table.Column<string>(name: "sip_cikis_adres", type: "nvarchar(max)", nullable: false),
                    sipvarisadres = table.Column<string>(name: "sip_varis_adres", type: "nvarchar(max)", nullable: false),
                    sipmiktar = table.Column<double>(name: "sip_miktar", type: "float", nullable: false),
                    sipmiktarbirim = table.Column<string>(name: "sip_miktar_birim", type: "nvarchar(max)", nullable: false),
                    sipagirlik = table.Column<double>(name: "sip_agirlik", type: "float", nullable: false),
                    sipagirlikbirim = table.Column<string>(name: "sip_agirlik_birim", type: "nvarchar(max)", nullable: false),
                    sipmalzemekodu = table.Column<string>(name: "sip_malzeme_kodu", type: "nvarchar(max)", nullable: false),
                    sipmalzemeadi = table.Column<string>(name: "sip_malzeme_adi", type: "nvarchar(max)", nullable: false),
                    sipnot = table.Column<string>(name: "sip_not", type: "nvarchar(max)", nullable: false),
                    sipdurum = table.Column<int>(name: "sip_durum", type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuss", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OrderStatuss",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5536), "Sipariş Alındı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5583), "Yola Çıktı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5592), "Dağıtım Merkezinde", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5599), "Teslim Edildi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5605), "Teslim Edilemedi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderStatuss");
        }
    }
}
