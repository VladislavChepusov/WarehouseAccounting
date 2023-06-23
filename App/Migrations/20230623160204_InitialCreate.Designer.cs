﻿// <auto-generated />
using System;
using App.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230623160204_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("App.DAL.Entities.Box", b =>
                {
                    b.Property<Guid>("BoxID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("BoxDepth")
                        .HasColumnType("double precision");

                    b.Property<DateOnly>("BoxExpirationDate")
                        .HasColumnType("date");

                    b.Property<double>("BoxHeight")
                        .HasColumnType("double precision");

                    b.Property<DateOnly>("BoxProductionDate")
                        .HasColumnType("date");

                    b.Property<double>("BoxVolume")
                        .HasColumnType("double precision");

                    b.Property<double>("BoxWeight")
                        .HasColumnType("double precision");

                    b.Property<double>("BoxWidth")
                        .HasColumnType("double precision");

                    b.Property<Guid>("PalletID")
                        .HasColumnType("uuid");

                    b.HasKey("BoxID");

                    b.HasIndex("PalletID");

                    b.ToTable("Boxes");
                });

            modelBuilder.Entity("App.DAL.Entities.Pallet", b =>
                {
                    b.Property<Guid>("PalletID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("PalletDepth")
                        .HasColumnType("double precision");

                    b.Property<DateOnly>("PalletExpirationDate")
                        .HasColumnType("date");

                    b.Property<double>("PalletHeight")
                        .HasColumnType("double precision");

                    b.Property<double>("PalletVolume")
                        .HasColumnType("double precision");

                    b.Property<double>("PalletWeight")
                        .HasColumnType("double precision");

                    b.Property<double>("PalletWidth")
                        .HasColumnType("double precision");

                    b.HasKey("PalletID");

                    b.ToTable("Pallets");
                });

            modelBuilder.Entity("App.DAL.Entities.Box", b =>
                {
                    b.HasOne("App.DAL.Entities.Pallet", null)
                        .WithMany("Boxes")
                        .HasForeignKey("PalletID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.DAL.Entities.Pallet", b =>
                {
                    b.Navigation("Boxes");
                });
#pragma warning restore 612, 618
        }
    }
}