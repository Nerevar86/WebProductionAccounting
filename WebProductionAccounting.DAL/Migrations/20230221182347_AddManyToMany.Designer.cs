﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebProductionAccounting.DAL;

#nullable disable

namespace WebProductionAccounting.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230221182347_AddManyToMany")]
    partial class AddManyToMany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebProductionAccounting.Domain.Entities.CompletedWork", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateImplementation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Scope")
                        .HasColumnType("double precision");

                    b.HasKey("EmployeeId", "WorkId");

                    b.HasIndex("WorkId");

                    b.ToTable("CompletedWorks", (string)null);
                });

            modelBuilder.Entity("WebProductionAccounting.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfEmployment")
                        .HasColumnType("date");

                    b.Property<string>("Firstname")
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .HasColumnType("text");

                    b.Property<string>("Middlename")
                        .HasColumnType("text");

                    b.Property<int>("PersonnelNumber")
                        .HasColumnType("integer");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Employees", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfEmployment = new DateTime(2023, 2, 21, 23, 23, 47, 138, DateTimeKind.Local).AddTicks(1709),
                            Firstname = "Станислав",
                            Lastname = "Михайлов",
                            Middlename = "Александрович",
                            PersonnelNumber = 18011993,
                            Position = 10
                        });
                });

            modelBuilder.Entity("WebProductionAccounting.Domain.Entities.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Works", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Разработка ПО"
                        });
                });

            modelBuilder.Entity("WebProductionAccounting.Domain.Entities.CompletedWork", b =>
                {
                    b.HasOne("WebProductionAccounting.Domain.Entities.Employee", "Employee")
                        .WithMany("CompletedWorks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProductionAccounting.Domain.Entities.Work", "Work")
                        .WithMany("CompletedWorks")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("WebProductionAccounting.Domain.Entities.Employee", b =>
                {
                    b.Navigation("CompletedWorks");
                });

            modelBuilder.Entity("WebProductionAccounting.Domain.Entities.Work", b =>
                {
                    b.Navigation("CompletedWorks");
                });
#pragma warning restore 612, 618
        }
    }
}