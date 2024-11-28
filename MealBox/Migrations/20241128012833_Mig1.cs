﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealBox.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    Province = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    City = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "Varchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    Gender = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    DateOfBirth = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    Authority = table.Column<string>(type: "Char(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    ProductDescription = table.Column<string>(type: "Varchar(300)", maxLength: 300, nullable: true),
                    Brand = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    Image = table.Column<string>(type: "Varchar(250)", maxLength: 250, nullable: true),
                    Province = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Town = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<string>(type: "Varchar(30)", nullable: false),
                    Solded = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AdminId",
                table: "Products",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
