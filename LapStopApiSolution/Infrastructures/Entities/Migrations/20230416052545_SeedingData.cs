using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "Id", "CreatedDate", "IsEnable", "IsRemoved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("e6d15a40-d1e1-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(5938), true, false, "Admin", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(5948) },
                    { new Guid("e6d15a41-d1e1-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(5951), true, false, "Manager", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(5952) },
                    { new Guid("e6d15a42-d1e1-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(5955), true, false, "Staff", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(5955) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeStatuses",
                columns: new[] { "Id", "CreatedDate", "IsEnable", "IsRemoved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("b3d637e0-d20a-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6158), true, false, "On", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6159) },
                    { new Guid("b3d637e1-d20a-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6161), true, false, "Off", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6162) },
                    { new Guid("b3d637e2-d20a-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6164), true, false, "Leaving", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6165) }
                });

            migrationBuilder.InsertData(
                table: "InvoiceStatus",
                columns: new[] { "Id", "CreatedDate", "Description", "IsEnable", "IsRemoved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("7187a500-d213-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6244), null, true, false, "Admin", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6245) },
                    { new Guid("7187a501-d213-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6248), null, true, false, "Manager", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6248) },
                    { new Guid("7187a502-d213-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6250), null, true, false, "Manager", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6251) }
                });

            migrationBuilder.InsertData(
                table: "ProductStatus",
                columns: new[] { "Id", "CreatedDate", "Description", "IsEnable", "IsRemoved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("b7ee5e90-d212-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6329), null, true, false, "In Stock", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6329) },
                    { new Guid("b7ee5e91-d212-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6334), null, true, false, "Out Of Stock", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6334) },
                    { new Guid("b7ee5e92-d212-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6336), null, true, false, "Sold Out", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6337) }
                });

            migrationBuilder.InsertData(
                table: "SalesOrderStatus",
                columns: new[] { "Id", "CreatedDate", "Description", "IsEnable", "IsRemoved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("feb2d310-d212-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6478), null, true, false, "Waiting", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6480) },
                    { new Guid("feb2d311-d212-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6483), null, true, false, "Processing", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6483) },
                    { new Guid("feb2d312-d212-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6486), null, true, false, "Completed", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6486) },
                    { new Guid("feb2d313-d212-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6489), null, true, false, "Blocked", new DateTime(2023, 4, 16, 12, 25, 44, 823, DateTimeKind.Local).AddTicks(6489) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: new Guid("e6d15a40-d1e1-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: new Guid("e6d15a41-d1e1-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: new Guid("e6d15a42-d1e1-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "EmployeeStatuses",
                keyColumn: "Id",
                keyValue: new Guid("b3d637e0-d20a-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "EmployeeStatuses",
                keyColumn: "Id",
                keyValue: new Guid("b3d637e1-d20a-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "EmployeeStatuses",
                keyColumn: "Id",
                keyValue: new Guid("b3d637e2-d20a-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "InvoiceStatus",
                keyColumn: "Id",
                keyValue: new Guid("7187a500-d213-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "InvoiceStatus",
                keyColumn: "Id",
                keyValue: new Guid("7187a501-d213-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "InvoiceStatus",
                keyColumn: "Id",
                keyValue: new Guid("7187a502-d213-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "ProductStatus",
                keyColumn: "Id",
                keyValue: new Guid("b7ee5e90-d212-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "ProductStatus",
                keyColumn: "Id",
                keyValue: new Guid("b7ee5e91-d212-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "ProductStatus",
                keyColumn: "Id",
                keyValue: new Guid("b7ee5e92-d212-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "SalesOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("feb2d310-d212-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "SalesOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("feb2d311-d212-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "SalesOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("feb2d312-d212-11ed-92cb-1903471dbe5a"));

            migrationBuilder.DeleteData(
                table: "SalesOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("feb2d313-d212-11ed-92cb-1903471dbe5a"));
        }
    }
}
