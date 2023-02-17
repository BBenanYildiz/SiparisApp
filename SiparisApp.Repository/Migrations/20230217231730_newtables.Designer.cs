﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiparisApp.Repository;

#nullable disable

namespace SiparisApp.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230217231730_newtables")]
    partial class newtables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SiparisApp.Core.Model.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("mat_adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mat_kodu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("SiparisApp.Core.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("ord_agirlik")
                        .HasColumnType("float");

                    b.Property<string>("ord_agirlik_birim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ord_cikis_adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ord_degisim_tarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("ord_durum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ord_malzeme_adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ord_malzeme_kodu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ord_miktar")
                        .HasColumnType("float");

                    b.Property<string>("ord_miktar_birim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ord_musteri_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ord_not")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ord_varis_adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SiparisApp.Core.Model.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ord_sta_degisim_tarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("ord_sta_durum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ord_sta_musteri_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuss");
                });
#pragma warning restore 612, 618
        }
    }
}
