﻿// <auto-generated />
using System;
using MealBox.Models.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MealBox.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241229133452_userLocation")]
    partial class userLocation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MealBox.Models.Classes.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar");

                    b.HasKey("CategoryID");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("MealBox.Models.Classes.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<string>("Brand")
                        .HasMaxLength(30)
                        .HasColumnType("Varchar");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("District")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar");

                    b.Property<string>("Image")
                        .HasMaxLength(250)
                        .HasColumnType("Varchar");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(30)
                        .HasColumnType("Varchar");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar");

                    b.Property<string>("Province")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar");

                    b.Property<string>("Solded")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Town")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("skt")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("Varchar");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MealBox.Models.Classes.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MealBox.Models.Classes.Product", b =>
                {
                    b.HasOne("MealBox.Models.Classes.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MealBox.Models.Classes.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealBox.Models.Classes.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MealBox.Models.Classes.User", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
