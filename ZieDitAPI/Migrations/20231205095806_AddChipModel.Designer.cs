﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZieDitAPI.Data;

#nullable disable

namespace ZieDitAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231205095806_AddChipModel")]
    partial class AddChipModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ZieDitAPI.Models.Chip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChipId")
                        .HasColumnType("int");

                    b.Property<int>("PosterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PosterId");

                    b.ToTable("Chips");
                });

            modelBuilder.Entity("ZieDitAPI.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ZieDitAPI.Models.Poster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("PosterImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReceivedCredits")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Posters");
                });

            modelBuilder.Entity("ZieDitAPI.Models.Presenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PostersId")
                        .HasColumnType("int");

                    b.Property<string>("PresenterEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PresenterFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PresenterLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PostersId");

                    b.ToTable("Presenters");
                });

            modelBuilder.Entity("ZieDitAPI.Models.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("VisitorCreditAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("ZieDitAPI.Models.Chip", b =>
                {
                    b.HasOne("ZieDitAPI.Models.Poster", "Poster")
                        .WithMany()
                        .HasForeignKey("PosterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poster");
                });

            modelBuilder.Entity("ZieDitAPI.Models.Poster", b =>
                {
                    b.HasOne("ZieDitAPI.Models.Event", "Event")
                        .WithMany("Posters")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("ZieDitAPI.Models.Presenter", b =>
                {
                    b.HasOne("ZieDitAPI.Models.Poster", "Posters")
                        .WithMany("Presenters")
                        .HasForeignKey("PostersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Posters");
                });

            modelBuilder.Entity("ZieDitAPI.Models.Visitor", b =>
                {
                    b.HasOne("ZieDitAPI.Models.Event", "Event")
                        .WithMany("Visitors")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("ZieDitAPI.Models.Event", b =>
                {
                    b.Navigation("Posters");

                    b.Navigation("Visitors");
                });

            modelBuilder.Entity("ZieDitAPI.Models.Poster", b =>
                {
                    b.Navigation("Presenters");
                });
#pragma warning restore 612, 618
        }
    }
}
