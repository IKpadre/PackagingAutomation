﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PackagingAutomation.Data;

#nullable disable

namespace PackagingAutomation.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250308152519_UpdatedPackagingMachineModel")]
    partial class UpdatedPackagingMachineModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PackagingAutomation.Models.Entities.Distributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Distributors");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.Flavor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Flavors");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.FormatTube", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormatTubes");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("DistributorId")
                        .HasColumnType("int");

                    b.Property<long>("Priority")
                        .HasColumnType("bigint");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DistributorId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.PackagingMachine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductionLineId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductionLineId");

                    b.ToTable("PackagingMachines");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FlavorId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<int>("TrademarkId")
                        .HasColumnType("int");

                    b.Property<int>("WeightId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlavorId");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("TrademarkId");

                    b.HasIndex("WeightId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.ProductionLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductionLines");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.ProductionSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ReconfigType")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.HasIndex("OrderId");

                    b.ToTable("ProductionSchedules");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.Trademark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trademarks");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.Weight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FormatTubeId")
                        .HasColumnType("int");

                    b.Property<long>("Grams")
                        .HasColumnType("bigint");

                    b.Property<long>("Performance")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FormatTubeId");

                    b.ToTable("Weights");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.Flavor", b =>
                {
                    b.HasOne("PackagingAutomation.Models.Entities.ProductType", "ProductType")
                        .WithMany("Flavors")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.Order", b =>
                {
                    b.HasOne("PackagingAutomation.Models.Entities.Distributor", "Distributor")
                        .WithMany("Orders")
                        .HasForeignKey("DistributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PackagingAutomation.Models.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Distributor");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.PackagingMachine", b =>
                {
                    b.HasOne("PackagingAutomation.Models.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("PackagingAutomation.Models.Entities.ProductionLine", "ProductionLine")
                        .WithMany("Machines")
                        .HasForeignKey("ProductionLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductionLine");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.Product", b =>
                {
                    b.HasOne("PackagingAutomation.Models.Entities.Flavor", "Flavor")
                        .WithMany("Products")
                        .HasForeignKey("FlavorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PackagingAutomation.Models.Entities.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PackagingAutomation.Models.Entities.Trademark", "Trademark")
                        .WithMany("Products")
                        .HasForeignKey("TrademarkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PackagingAutomation.Models.Entities.Weight", "Weight")
                        .WithMany("Products")
                        .HasForeignKey("WeightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flavor");

                    b.Navigation("ProductType");

                    b.Navigation("Trademark");

                    b.Navigation("Weight");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.ProductionSchedule", b =>
                {
                    b.HasOne("PackagingAutomation.Models.Entities.PackagingMachine", "Machine")
                        .WithMany("Schedules")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PackagingAutomation.Models.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.Navigation("Machine");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.Weight", b =>
                {
                    b.HasOne("PackagingAutomation.Models.Entities.FormatTube", "FormatTube")
                        .WithMany("Weights")
                        .HasForeignKey("FormatTubeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormatTube");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.Distributor", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.Flavor", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.FormatTube", b =>
                {
                    b.Navigation("Weights");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.PackagingMachine", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.ProductType", b =>
                {
                    b.Navigation("Flavors");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.ProductionLine", b =>
                {
                    b.Navigation("Machines");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.Trademark", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PackagingAutomation.Models.Entities.Weight", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
