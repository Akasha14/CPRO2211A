﻿// <auto-generated />
using System;
using Assignment2_ContactManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment2_ContactManager.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241028195231_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment2_ContactManager.Models.Category", b =>
                {
                    b.Property<int>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("categoryId"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            categoryId = 1,
                            name = "Family"
                        },
                        new
                        {
                            categoryId = 2,
                            name = "Friend"
                        },
                        new
                        {
                            categoryId = 3,
                            name = "Work"
                        });
                });

            modelBuilder.Entity("Assignment2_ContactManager.Models.Contact", b =>
                {
                    b.Property<int>("contactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("contactId"));

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("contactId");

                    b.HasIndex("categoryId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            contactId = 1,
                            categoryId = 1,
                            dateAdded = new DateTime(2024, 10, 28, 13, 52, 30, 903, DateTimeKind.Local).AddTicks(3113),
                            email = "johnDoe@gmail.com",
                            firstName = "John",
                            lastName = "Doe",
                            organization = "Tech Inc.",
                            phoneNumber = "123-456-7890"
                        },
                        new
                        {
                            contactId = 2,
                            categoryId = 2,
                            dateAdded = new DateTime(2024, 10, 28, 13, 52, 30, 903, DateTimeKind.Local).AddTicks(3150),
                            email = "alexM@outlook.com",
                            firstName = "Alex",
                            lastName = "Meyer",
                            phoneNumber = "345-678-9012"
                        });
                });

            modelBuilder.Entity("Assignment2_ContactManager.Models.Contact", b =>
                {
                    b.HasOne("Assignment2_ContactManager.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}