﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using todolist.Data;

#nullable disable

namespace todolist.Data.Migrations
{
    [DbContext(typeof(TodolistContext))]
    [Migration("20250218183105_OmegaCipher")]
    partial class OmegaCipher
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("todolist.Models.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("IntelReport")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OperationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OperationWindow")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("todolist.Models.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codename")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("todolist.Models.Mission", b =>
                {
                    b.HasOne("todolist.Models.Operation", "Operation")
                        .WithMany("Missions")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("todolist.Models.Operation", b =>
                {
                    b.Navigation("Missions");
                });
#pragma warning restore 612, 618
        }
    }
}
