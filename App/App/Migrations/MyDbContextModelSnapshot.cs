﻿// <auto-generated />
using System;
using App.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("App.DAL.Entities.Box", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Depth")
                        .HasColumnType("double precision");

                    b.Property<DateOnly>("ExpirationDate")
                        .HasColumnType("date");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("PalletID")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("ProductionDate")
                        .HasColumnType("date");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.Property<double>("Width")
                        .HasColumnType("double precision");

                    b.HasKey("ID");

                    b.HasIndex("PalletID");

                    b.ToTable("Boxes");
                });

            modelBuilder.Entity("App.DAL.Entities.Pallet", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Depth")
                        .HasColumnType("double precision");

                    b.Property<DateOnly>("ExpirationDate")
                        .HasColumnType("date");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.Property<double>("Width")
                        .HasColumnType("double precision");

                    b.HasKey("ID");

                    b.ToTable("Pallets");
                });

            modelBuilder.Entity("App.DAL.Entities.Box", b =>
                {
                    b.HasOne("App.DAL.Entities.Pallet", null)
                        .WithMany("Boxes")
                        .HasForeignKey("PalletID");
                });

            modelBuilder.Entity("App.DAL.Entities.Pallet", b =>
                {
                    b.Navigation("Boxes");
                });
#pragma warning restore 612, 618
        }
    }
}
