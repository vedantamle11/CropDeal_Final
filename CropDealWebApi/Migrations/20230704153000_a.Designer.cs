﻿// <auto-generated />
using System;
using CropDealWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CropDealWebAPI.Migrations
{
    [DbContext(typeof(CropDealContext))]
    [Migration("20230704153000_a")]
    partial class a
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CropDealWebAPI.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AdminID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"), 1L, 1);

                    b.Property<string>("AdminEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("AdminId");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("CropDealWebAPI.Models.Crop", b =>
                {
                    b.Property<int>("CropId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CropID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CropId"), 1L, 1);

                    b.Property<string>("CropImage")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("CropName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("CropId");

                    b.ToTable("Crops");
                });

            modelBuilder.Entity("CropDealWebAPI.Models.CropOnSale", b =>
                {
                    b.Property<int>("CropAdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CropAdID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CropAdId"), 1L, 1);

                    b.Property<int>("CropId")
                        .HasColumnType("int");

                    b.Property<string>("CropName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("CropPrice")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("CropQty")
                        .HasColumnType("int");

                    b.Property<string>("CropType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("FarmerId")
                        .HasColumnType("int")
                        .HasColumnName("FarmerID");

                    b.HasKey("CropAdId");

                    b.HasIndex("CropId");

                    b.HasIndex("FarmerId");

                    b.ToTable("CropOnSale", (string)null);
                });

            modelBuilder.Entity("CropDealWebAPI.Models.ExceptionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Data")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("ErrorDescription")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("StackTrace")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExceptionLog", (string)null);
                });

            modelBuilder.Entity("CropDealWebAPI.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("InvoiceID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"), 1L, 1);

                    b.Property<string>("CropName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CropQty")
                        .HasColumnType("int");

                    b.Property<string>("CropType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("DealerAccNumber")
                        .HasColumnType("int");

                    b.Property<int>("FarmerAccNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("InvoiceId");

                    b.HasIndex("DealerAccNumber");

                    b.HasIndex("FarmerAccNumber");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("CropDealWebAPI.Models.UserProfile", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int>("UserAccnumber")
                        .HasColumnType("int");

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("UserBankName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserIfsc")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UserIFSC");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<byte[]>("UserPasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("UserPasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserPhnumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UserStatus")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasDefaultValueSql("('ACTIVE')");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("UserId")
                        .HasName("PK_UserProfile_1");

                    b.HasIndex(new[] { "UserAccnumber" }, "IX_UserProfile")
                        .IsUnique();

                    b.ToTable("UserProfile", (string)null);
                });

            modelBuilder.Entity("CropDealWebAPI.Models.CropOnSale", b =>
                {
                    b.HasOne("CropDealWebAPI.Models.Crop", "Crop")
                        .WithMany("CropOnSales")
                        .HasForeignKey("CropId")
                        .IsRequired()
                        .HasConstraintName("FK_CropOnSale_CropId");

                    b.HasOne("CropDealWebAPI.Models.UserProfile", "Farmer")
                        .WithMany("CropOnSales")
                        .HasForeignKey("FarmerId")
                        .IsRequired()
                        .HasConstraintName("FK_CropOnSale_CropOnSale");

                    b.Navigation("Crop");

                    b.Navigation("Farmer");
                });

            modelBuilder.Entity("CropDealWebAPI.Models.Invoice", b =>
                {
                    b.HasOne("CropDealWebAPI.Models.UserProfile", "DealerAccNumberNavigation")
                        .WithMany("InvoiceDealerAccNumberNavigations")
                        .HasForeignKey("DealerAccNumber")
                        .HasPrincipalKey("UserAccnumber")
                        .IsRequired()
                        .HasConstraintName("FK_Invoices_UserProfile");

                    b.HasOne("CropDealWebAPI.Models.UserProfile", "FarmerAccNumberNavigation")
                        .WithMany("InvoiceFarmerAccNumberNavigations")
                        .HasForeignKey("FarmerAccNumber")
                        .HasPrincipalKey("UserAccnumber")
                        .IsRequired()
                        .HasConstraintName("FK_Invoices_Farmer");

                    b.Navigation("DealerAccNumberNavigation");

                    b.Navigation("FarmerAccNumberNavigation");
                });

            modelBuilder.Entity("CropDealWebAPI.Models.Crop", b =>
                {
                    b.Navigation("CropOnSales");
                });

            modelBuilder.Entity("CropDealWebAPI.Models.UserProfile", b =>
                {
                    b.Navigation("CropOnSales");

                    b.Navigation("InvoiceDealerAccNumberNavigations");

                    b.Navigation("InvoiceFarmerAccNumberNavigations");
                });
#pragma warning restore 612, 618
        }
    }
}
