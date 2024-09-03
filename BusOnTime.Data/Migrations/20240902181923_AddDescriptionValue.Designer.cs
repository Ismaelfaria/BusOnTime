﻿// <auto-generated />
using System;
using BusOnTime.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusOnTime.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240902181923_AddDescriptionValue")]
    partial class AddDescriptionValue
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusOnTime.Data.Entities.Equipment", b =>
                {
                    b.Property<Guid>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EquipmentModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EquipmentId");

                    b.HasIndex("EquipmentModelId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("BusOnTime.Data.Entities.EquipmentModel", b =>
                {
                    b.Property<Guid>("EquipmentModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EquipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EquipmentModelId");

                    b.ToTable("EquipmentModel");
                });

            modelBuilder.Entity("BusOnTime.Data.Entities.EquipmentModelStateHourlyEarnings", b =>
                {
                    b.Property<Guid>("EquipmentModelStateHourlyEarningsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EquipmentModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EquipmentStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Value")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EquipmentModelStateHourlyEarningsId");

                    b.HasIndex("EquipmentModelId");

                    b.HasIndex("EquipmentStateId");

                    b.ToTable("EquipmentModelStateHourlyEarnings");
                });

            modelBuilder.Entity("BusOnTime.Data.Entities.EquipmentPositionHistory", b =>
                {
                    b.Property<Guid>("EquipmentPositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EquipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Lat")
                        .HasColumnType("int");

                    b.Property<int>("Lon")
                        .HasColumnType("int");

                    b.HasKey("EquipmentPositionId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("EquipmentPositionHistory");
                });

            modelBuilder.Entity("BusOnTime.Data.Entities.EquipmentState", b =>
                {
                    b.Property<Guid>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StateId");

                    b.ToTable("EquipmentState");
                });

            modelBuilder.Entity("BusOnTime.Data.Entities.EquipmentStateHistory", b =>
                {
                    b.Property<Guid>("EquipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EquipmentStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("EquipmentId", "Date");

                    b.HasIndex("EquipmentStateId");

                    b.ToTable("EquipmentStateHistory");
                });

            modelBuilder.Entity("BusOnTime.Data.Entities.Equipment", b =>
                {
                    b.HasOne("BusOnTime.Data.Entities.EquipmentModel", "EquipmentModel")
                        .WithMany("Equipment")
                        .HasForeignKey("EquipmentModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EquipmentModel");
                });

            modelBuilder.Entity("BusOnTime.Data.Entities.EquipmentModelStateHourlyEarnings", b =>
                {
                    b.HasOne("BusOnTime.Data.Entities.EquipmentModel", "EquipmentModel")
                        .WithMany("EquipmentModelStateHourlyEarnings")
                        .HasForeignKey("EquipmentModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusOnTime.Data.Entities.EquipmentState", "EquipmentState")
                        .WithMany("EquipmentModelStateHourlyEarnings")
                        .HasForeignKey("EquipmentStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentModel");

                    b.Navigation("EquipmentState");
                });

            modelBuilder.Entity("BusOnTime.Data.Entities.EquipmentPositionHistory", b =>
                {
                    b.HasOne("BusOnTime.Data.Entities.Equipment", "Equipment")
                        .WithMany("EquipmentPositionHistories")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("BusOnTime.Data.Entities.EquipmentStateHistory", b =>
                {
                    b.HasOne("BusOnTime.Data.Entities.Equipment", "Equipment")
                        .WithMany("EquipmentStateHistories")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusOnTime.Data.Entities.EquipmentState", "EquipmentState")
                        .WithMany("EquipmentStateHistories")
                        .HasForeignKey("EquipmentStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("EquipmentState");
                });

            modelBuilder.Entity("BusOnTime.Data.Entities.Equipment", b =>
                {
                    b.Navigation("EquipmentPositionHistories");

                    b.Navigation("EquipmentStateHistories");
                });

            modelBuilder.Entity("BusOnTime.Data.Entities.EquipmentModel", b =>
                {
                    b.Navigation("Equipment");

                    b.Navigation("EquipmentModelStateHourlyEarnings");
                });

            modelBuilder.Entity("BusOnTime.Data.Entities.EquipmentState", b =>
                {
                    b.Navigation("EquipmentModelStateHourlyEarnings");

                    b.Navigation("EquipmentStateHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
