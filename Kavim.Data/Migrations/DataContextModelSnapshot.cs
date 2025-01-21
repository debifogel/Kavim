﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kavim.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kavim.Core.classes.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BusName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Company")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("buses");
                });

            modelBuilder.Entity("Kavim.Core.classes.Schdule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("TimeEnd")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("TimeStart")
                        .HasColumnType("time");

                    b.Property<int>("frenquecy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.ToTable("Schdule");
                });

            modelBuilder.Entity("Kavim.Core.classes.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InStreetId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("StationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InStreetId");

                    b.ToTable("stations");
                });

            modelBuilder.Entity("Kavim.Core.classes.StationAndi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StopId")
                        .HasColumnType("int");

                    b.Property<int>("_BusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StopId");

                    b.HasIndex("_BusId");

                    b.ToTable("StationAndi");
                });

            modelBuilder.Entity("Kavim.Core.classes.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("streets");
                });

            modelBuilder.Entity("Kavim.Core.classes.Schdule", b =>
                {
                    b.HasOne("Kavim.Core.classes.Bus", null)
                        .WithMany("Timings")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kavim.Core.classes.Station", b =>
                {
                    b.HasOne("Kavim.Core.classes.Street", "InStreet")
                        .WithMany("ListOfStation")
                        .HasForeignKey("InStreetId");

                    b.Navigation("InStreet");
                });

            modelBuilder.Entity("Kavim.Core.classes.StationAndi", b =>
                {
                    b.HasOne("Kavim.Core.classes.Station", "Stop")
                        .WithMany("BusInStation")
                        .HasForeignKey("StopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kavim.Core.classes.Bus", "_Bus")
                        .WithMany("Listofstation")
                        .HasForeignKey("_BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stop");

                    b.Navigation("_Bus");
                });

            modelBuilder.Entity("Kavim.Core.classes.Bus", b =>
                {
                    b.Navigation("Listofstation");

                    b.Navigation("Timings");
                });

            modelBuilder.Entity("Kavim.Core.classes.Station", b =>
                {
                    b.Navigation("BusInStation");
                });

            modelBuilder.Entity("Kavim.Core.classes.Street", b =>
                {
                    b.Navigation("ListOfStation");
                });
#pragma warning restore 612, 618
        }
    }
}
