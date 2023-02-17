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
    [Migration("20230212220626_database_create")]
    partial class databasecreate
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

                    b.Property<double>("sip_agirlik")
                        .HasColumnType("float");

                    b.Property<string>("sip_agirlik_birim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sip_cikis_adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sip_durum")
                        .HasColumnType("int");

                    b.Property<string>("sip_malzeme_adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sip_malzeme_kodu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("sip_miktar")
                        .HasColumnType("float");

                    b.Property<string>("sip_miktar_birim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sip_musteri_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sip_not")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sip_varis_adres")
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuss");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5536),
                            Name = "Sipariş Alındı",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5583),
                            Name = "Yola Çıktı",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5592),
                            Name = "Dağıtım Merkezinde",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5599),
                            Name = "Teslim Edildi",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CreateDate = new DateTime(2023, 2, 13, 1, 6, 25, 972, DateTimeKind.Local).AddTicks(5605),
                            Name = "Teslim Edilemedi",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}