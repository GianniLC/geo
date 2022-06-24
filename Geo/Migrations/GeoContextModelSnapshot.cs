﻿// <auto-generated />
using System;
using Geo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Geo.Migrations
{
    [DbContext(typeof(GeoContext))]
    partial class GeoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Geo.Models.Absence", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("AbsenceTypesid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("dateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dateStart")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("AbsenceTypesid");

                    b.ToTable("Absence");
                });

            modelBuilder.Entity("Geo.Models.AbsenceTypes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AbsenceTypes");
                });

            modelBuilder.Entity("Geo.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("daysLeft")
                        .HasColumnType("int");

                    b.Property<int>("daysPersonal")
                        .HasColumnType("int");

                    b.Property<int>("daysSick")
                        .HasColumnType("int");

                    b.Property<int>("daysVacation")
                        .HasColumnType("int");

                    b.Property<string>("fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Geo.Models.Absence", b =>
                {
                    b.HasOne("Geo.Models.AbsenceTypes", "AbsenceTypes")
                        .WithMany()
                        .HasForeignKey("AbsenceTypesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AbsenceTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
