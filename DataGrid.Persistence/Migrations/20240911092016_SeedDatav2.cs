using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataGrid.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatav2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2003, 11, 1), new DateTime(2003, 11, 1, 5, 50, 16, 438, DateTimeKind.Local).AddTicks(6468), new TimeOnly(5, 50, 16, 438).Add(TimeSpan.FromTicks(6496)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2003, 12, 2), new DateTime(1993, 12, 2, 7, 5, 16, 438, DateTimeKind.Local).AddTicks(6507), new TimeOnly(7, 5, 16, 438).Add(TimeSpan.FromTicks(6509)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2003, 1, 3), new DateTime(2014, 1, 3, 7, 35, 16, 438, DateTimeKind.Local).AddTicks(6511), new TimeOnly(7, 35, 16, 438).Add(TimeSpan.FromTicks(6514)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2003, 2, 4), new DateTime(1999, 2, 4, 8, 50, 16, 438, DateTimeKind.Local).AddTicks(6515), new TimeOnly(8, 50, 16, 438).Add(TimeSpan.FromTicks(6517)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2003, 3, 5), new DateTime(2004, 3, 5, 10, 5, 16, 438, DateTimeKind.Local).AddTicks(6519), new TimeOnly(10, 5, 16, 438).Add(TimeSpan.FromTicks(6521)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(1997, 4, 6), new DateTime(1984, 4, 5, 20, 35, 16, 438, DateTimeKind.Local).AddTicks(6523), new TimeOnly(20, 35, 16, 438).Add(TimeSpan.FromTicks(6525)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(1995, 5, 7), new DateTime(2004, 5, 7, 0, 35, 16, 438, DateTimeKind.Local).AddTicks(6527), new TimeOnly(17, 35, 16, 438).Add(TimeSpan.FromTicks(6529)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2003, 6, 8), new DateTime(2004, 5, 6, 18, 50, 16, 438, DateTimeKind.Local).AddTicks(6531), new TimeOnly(18, 50, 16, 438).Add(TimeSpan.FromTicks(6533)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2003, 5, 9), new DateTime(1997, 7, 3, 20, 20, 16, 438, DateTimeKind.Local).AddTicks(6535), new TimeOnly(20, 20, 16, 438).Add(TimeSpan.FromTicks(6537)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2004, 8, 10), new DateTime(2000, 8, 4, 23, 50, 16, 438, DateTimeKind.Local).AddTicks(6539), new TimeOnly(23, 50, 16, 438).Add(TimeSpan.FromTicks(6541)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(1995, 9, 10), new DateTime(2003, 8, 6, 2, 5, 16, 438, DateTimeKind.Local).AddTicks(6543), new TimeOnly(2, 5, 16, 438).Add(TimeSpan.FromTicks(6545)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2002, 7, 9), new DateTime(1999, 8, 9, 23, 20, 16, 438, DateTimeKind.Local).AddTicks(6546), new TimeOnly(23, 20, 16, 438).Add(TimeSpan.FromTicks(6548)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2003, 8, 8), new DateTime(2004, 8, 6, 20, 35, 16, 438, DateTimeKind.Local).AddTicks(6550), new TimeOnly(20, 35, 16, 438).Add(TimeSpan.FromTicks(6552)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2023, 9, 1), new DateTime(2023, 9, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), new TimeOnly(10, 30, 0) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2023, 9, 2), new DateTime(2023, 9, 2, 11, 45, 0, 0, DateTimeKind.Unspecified), new TimeOnly(11, 45, 0) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2023, 9, 3), new DateTime(2023, 9, 3, 12, 15, 0, 0, DateTimeKind.Unspecified), new TimeOnly(12, 15, 0) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2023, 9, 4), new DateTime(2023, 9, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeOnly(13, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2023, 9, 5), new DateTime(2023, 9, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), new TimeOnly(9, 30, 0) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2023, 9, 6), new DateTime(2023, 9, 6, 14, 15, 0, 0, DateTimeKind.Unspecified), new TimeOnly(14, 15, 0) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2023, 9, 7), new DateTime(2023, 9, 7, 10, 45, 0, 0, DateTimeKind.Unspecified), new TimeOnly(10, 45, 0) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2023, 9, 8), new DateTime(2023, 9, 8, 16, 30, 0, 0, DateTimeKind.Unspecified), new TimeOnly(16, 30, 0) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2023, 9, 9), new DateTime(2023, 9, 9, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeOnly(15, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2023, 9, 10), new DateTime(2023, 9, 10, 11, 30, 0, 0, DateTimeKind.Unspecified), new TimeOnly(11, 30, 0) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2023, 9, 11), new DateTime(2023, 9, 11, 13, 15, 0, 0, DateTimeKind.Unspecified), new TimeOnly(13, 15, 0) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2023, 9, 12), new DateTime(2023, 9, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeOnly(12, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AddedData", "AddedOn", "AddedTime" },
                values: new object[] { new DateOnly(2023, 9, 13), new DateTime(2023, 9, 13, 14, 45, 0, 0, DateTimeKind.Unspecified), new TimeOnly(14, 45, 0) });
        }
    }
}
