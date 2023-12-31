﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication___Week_5.Migrations
{
    /// <inheritdoc />
    public partial class addedProductAndOrderModelswithGary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "ProductName",
                value: "Gary's Peaches");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "ProductName",
                value: "Pat's Peaches");
        }
    }
}
