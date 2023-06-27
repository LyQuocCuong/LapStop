using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreService.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalEmployeeFieldsForRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "IdentEmployee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "IdentEmployee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "IdentEmployee");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "IdentEmployee");
        }
    }
}
