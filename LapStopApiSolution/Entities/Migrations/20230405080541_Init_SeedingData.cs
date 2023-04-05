using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Init_SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "Id", "CreatedDate", "IsEnable", "IsRemoved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("e6d15a40-d1e1-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(100), true, false, "Admin", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(111) },
                    { new Guid("e6d15a41-d1e1-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(117), true, false, "Manager", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(118) },
                    { new Guid("e6d15a42-d1e1-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(122), true, false, "Staff", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(123) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeStatuses",
                columns: new[] { "Id", "CreatedDate", "IsEnable", "IsRemoved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("b3d637e0-d20a-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(639), true, false, "On", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(642) },
                    { new Guid("b3d637e1-d20a-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(646), true, false, "Off", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(647) },
                    { new Guid("b3d637e2-d20a-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(652), true, false, "Leaving", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(653) }
                });

            migrationBuilder.InsertData(
                table: "InvoiceStatus",
                columns: new[] { "Id", "CreatedDate", "Description", "IsEnable", "IsRemoved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("7187a500-d213-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(893), null, true, false, "Admin", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(895) },
                    { new Guid("7187a501-d213-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(902), null, true, false, "Manager", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(903) },
                    { new Guid("7187a502-d213-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(908), null, true, false, "Manager", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(909) }
                });

            migrationBuilder.InsertData(
                table: "ProductStatus",
                columns: new[] { "Id", "CreatedDate", "Description", "IsEnable", "IsRemoved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("b7ee5e90-d212-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(1186), null, true, false, "In Stock", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(1187) },
                    { new Guid("b7ee5e91-d212-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(1194), null, true, false, "Out Of Stock", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(1195) },
                    { new Guid("b7ee5e92-d212-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(1200), null, true, false, "Sold Out", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(1201) }
                });

            migrationBuilder.InsertData(
                table: "SalesOrderStatus",
                columns: new[] { "Id", "CreatedDate", "Description", "IsEnable", "IsRemoved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("feb2d310-d212-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(1412), null, true, false, "Waiting", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(1413) },
                    { new Guid("feb2d311-d212-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(1417), null, true, false, "Processing", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(1418) },
                    { new Guid("feb2d312-d212-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(1424), null, true, false, "Completed", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(1424) },
                    { new Guid("feb2d313-d212-11ed-92cb-1903471dbe5a"), new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(1427), null, true, false, "Blocked", new DateTime(2023, 4, 5, 15, 5, 41, 85, DateTimeKind.Local).AddTicks(1428) }
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
