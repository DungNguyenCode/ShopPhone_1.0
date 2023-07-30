﻿// <auto-generated />
using System;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppData.Migrations
{
    [DbContext(typeof(AppDataConTextDB))]
    [Migration("20230706100024_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppData.Models.ChucVu", b =>
                {
                    b.Property<Guid>("ChucVuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("ChucVuId");

                    b.ToTable("ChucVus");
                });

            modelBuilder.Entity("AppData.Models.DonHang", b =>
                {
                    b.Property<Guid>("DonHangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("KhachHangId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKhachHang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("DonHangId");

                    b.HasIndex("KhachHangId");

                    b.ToTable("DonHangs");
                });

            modelBuilder.Entity("AppData.Models.DonHangCT", b =>
                {
                    b.Property<Guid>("DonHangCtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DonHangId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SanPhamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("DonHangCtId");

                    b.HasIndex("DonHangId");

                    b.HasIndex("SanPhamId");

                    b.ToTable("DonHangCts");
                });

            modelBuilder.Entity("AppData.Models.GioHang", b =>
                {
                    b.Property<Guid>("KhachHangId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TenKhachHang")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KhachHangId");

                    b.ToTable("GioHangs");
                });

            modelBuilder.Entity("AppData.Models.GioHangCT", b =>
                {
                    b.Property<Guid>("GioHangCtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GioHangKhachHangId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("KhachHangId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SanPhamid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("GioHangCtId");

                    b.HasIndex("GioHangKhachHangId");

                    b.HasIndex("SanPhamid");

                    b.ToTable("GioHangCts");
                });

            modelBuilder.Entity("AppData.Models.KhachHang", b =>
                {
                    b.Property<Guid>("KhachHangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhDaiDien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ChucVuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDayDu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.Property<int>("VaiTro")
                        .HasColumnType("int");

                    b.HasKey("KhachHangId");

                    b.HasIndex("ChucVuId");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("AppData.Models.SanPham", b =>
                {
                    b.Property<Guid>("SanPhamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MauSac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NhaCungCap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongTon")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("SanPhamId");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("AppData.Models.DonHang", b =>
                {
                    b.HasOne("AppData.Models.KhachHang", "KhachHangs")
                        .WithMany("DonHangs")
                        .HasForeignKey("KhachHangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHangs");
                });

            modelBuilder.Entity("AppData.Models.DonHangCT", b =>
                {
                    b.HasOne("AppData.Models.DonHang", "DonHang")
                        .WithMany("DonHangCTs")
                        .HasForeignKey("DonHangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.SanPham", "SanPham")
                        .WithMany("DonHangCts")
                        .HasForeignKey("SanPhamId");

                    b.Navigation("DonHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("AppData.Models.GioHang", b =>
                {
                    b.HasOne("AppData.Models.KhachHang", "KhachHangs")
                        .WithOne("GioHangs")
                        .HasForeignKey("AppData.Models.GioHang", "KhachHangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHangs");
                });

            modelBuilder.Entity("AppData.Models.GioHangCT", b =>
                {
                    b.HasOne("AppData.Models.GioHang", "GioHang")
                        .WithMany("GioHangCTs")
                        .HasForeignKey("GioHangKhachHangId");

                    b.HasOne("AppData.Models.SanPham", "SanPham")
                        .WithMany("GioHangCt")
                        .HasForeignKey("SanPhamid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GioHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("AppData.Models.KhachHang", b =>
                {
                    b.HasOne("AppData.Models.ChucVu", "ChucVu")
                        .WithMany("KhachHangs")
                        .HasForeignKey("ChucVuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVu");
                });

            modelBuilder.Entity("AppData.Models.ChucVu", b =>
                {
                    b.Navigation("KhachHangs");
                });

            modelBuilder.Entity("AppData.Models.DonHang", b =>
                {
                    b.Navigation("DonHangCTs");
                });

            modelBuilder.Entity("AppData.Models.GioHang", b =>
                {
                    b.Navigation("GioHangCTs");
                });

            modelBuilder.Entity("AppData.Models.KhachHang", b =>
                {
                    b.Navigation("DonHangs");

                    b.Navigation("GioHangs");
                });

            modelBuilder.Entity("AppData.Models.SanPham", b =>
                {
                    b.Navigation("DonHangCts");

                    b.Navigation("GioHangCt");
                });
#pragma warning restore 612, 618
        }
    }
}
