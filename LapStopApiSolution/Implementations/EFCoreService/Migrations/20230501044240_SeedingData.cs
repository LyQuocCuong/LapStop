using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreService.Migrations
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
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), false, false, "Admin", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), false, false, "Manager", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), false, false, "Staff", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeStatuses",
                columns: new[] { "Id", "CreatedDate", "IsEnable", "IsRemoved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000101"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), false, false, "On", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000102"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), false, false, "Off", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000103"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), false, false, "Leaving", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "InvoiceStatus",
                columns: new[] { "Id", "CreatedDate", "Description", "IsEnable", "IsRemoved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000201"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), null, false, false, "Processing", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000202"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), null, false, false, "Completed", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000203"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), null, false, false, "Blocked", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "ProductStatus",
                columns: new[] { "Id", "CreatedDate", "Description", "IsEnable", "IsRemoved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000301"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), null, false, false, "In_Stock", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000302"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), null, false, false, "Out_Of_Stock", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000303"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), null, false, false, "Sold_Out", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "SalesOrderStatus",
                columns: new[] { "Id", "CreatedDate", "Description", "IsEnable", "IsRemoved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000401"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), null, false, false, "Waiting", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000402"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), null, false, false, "Processing", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000403"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), null, false, false, "Completed", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("00000000-0000-0000-0000-000000000404"), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), null, false, false, "Blocked", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "EmployeeStatuses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"));

            migrationBuilder.DeleteData(
                table: "EmployeeStatuses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"));

            migrationBuilder.DeleteData(
                table: "EmployeeStatuses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"));

            migrationBuilder.DeleteData(
                table: "InvoiceStatus",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"));

            migrationBuilder.DeleteData(
                table: "InvoiceStatus",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"));

            migrationBuilder.DeleteData(
                table: "InvoiceStatus",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"));

            migrationBuilder.DeleteData(
                table: "ProductStatus",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000301"));

            migrationBuilder.DeleteData(
                table: "ProductStatus",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000302"));

            migrationBuilder.DeleteData(
                table: "ProductStatus",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000303"));

            migrationBuilder.DeleteData(
                table: "SalesOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000401"));

            migrationBuilder.DeleteData(
                table: "SalesOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000402"));

            migrationBuilder.DeleteData(
                table: "SalesOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000403"));

            migrationBuilder.DeleteData(
                table: "SalesOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000404"));
        }
    }
}
