using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreService.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForIdentEmployeeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "IdentRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000501"), null, "Admin", "ADMIN" },
                    { new Guid("00000000-0000-0000-0000-000000000502"), null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentRole",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000501"));

            migrationBuilder.DeleteData(
                table: "IdentRole",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000502"));
        }
    }
}
