using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataGrid.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "EnName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "EnDescription");

            migrationBuilder.RenameColumn(
                name: "AddedData",
                table: "Products",
                newName: "AddedDate");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "EnName");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedDate", "AddedOn", "AddedTime", "EnDescription" },
                values: new object[] { new DateOnly(2003, 11, 2), new DateTime(2003, 11, 2, 3, 34, 0, 778, DateTimeKind.Local).AddTicks(6496), new TimeOnly(3, 34, 0, 778).Add(TimeSpan.FromTicks(6521)), "EnDescription 1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedDate", "AddedOn", "AddedTime", "EnDescription" },
                values: new object[] { new DateOnly(2003, 12, 3), new DateTime(1993, 12, 3, 4, 49, 0, 778, DateTimeKind.Local).AddTicks(6528), new TimeOnly(4, 49, 0, 778).Add(TimeSpan.FromTicks(6530)), "EnDescription 2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedDate", "AddedOn", "AddedTime", "EnDescription" },
                values: new object[] { new DateOnly(2003, 1, 4), new DateTime(2014, 1, 4, 5, 19, 0, 778, DateTimeKind.Local).AddTicks(6532), new TimeOnly(5, 19, 0, 778).Add(TimeSpan.FromTicks(6534)), "EnDescription 3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedDate", "AddedOn", "AddedTime", "EnDescription" },
                values: new object[] { new DateOnly(2003, 2, 5), new DateTime(1999, 2, 5, 6, 34, 0, 778, DateTimeKind.Local).AddTicks(6536), new TimeOnly(6, 34, 0, 778).Add(TimeSpan.FromTicks(6538)), "EnDescription 4" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedDate", "AddedOn", "AddedTime", "EnDescription" },
                values: new object[] { new DateOnly(2003, 3, 6), new DateTime(2004, 3, 6, 7, 49, 0, 778, DateTimeKind.Local).AddTicks(6539), new TimeOnly(7, 49, 0, 778).Add(TimeSpan.FromTicks(6541)), "EnDescription 5" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedDate", "AddedOn", "AddedTime", "EnDescription" },
                values: new object[] { new DateOnly(1997, 4, 7), new DateTime(1984, 4, 6, 18, 19, 0, 778, DateTimeKind.Local).AddTicks(6543), new TimeOnly(18, 19, 0, 778).Add(TimeSpan.FromTicks(6545)), "EnDescription 6" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedDate", "AddedOn", "AddedTime", "EnDescription" },
                values: new object[] { new DateOnly(1995, 5, 8), new DateTime(2004, 5, 7, 22, 19, 0, 778, DateTimeKind.Local).AddTicks(6547), new TimeOnly(15, 19, 0, 778).Add(TimeSpan.FromTicks(6549)), "EnDescription 7" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedDate", "AddedOn", "AddedTime", "EnDescription" },
                values: new object[] { new DateOnly(2003, 6, 9), new DateTime(2004, 5, 7, 16, 34, 0, 778, DateTimeKind.Local).AddTicks(6551), new TimeOnly(16, 34, 0, 778).Add(TimeSpan.FromTicks(6553)), "EnDescription 8" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedDate", "AddedOn", "AddedTime", "EnDescription" },
                values: new object[] { new DateOnly(2003, 5, 10), new DateTime(1997, 7, 4, 18, 4, 0, 778, DateTimeKind.Local).AddTicks(6555), new TimeOnly(18, 4, 0, 778).Add(TimeSpan.FromTicks(6559)), "EnDescription 9" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedDate", "AddedOn", "AddedTime", "EnDescription" },
                values: new object[] { new DateOnly(2004, 8, 11), new DateTime(2000, 8, 5, 21, 34, 0, 778, DateTimeKind.Local).AddTicks(6561), new TimeOnly(21, 34, 0, 778).Add(TimeSpan.FromTicks(6563)), "EnDescription 10" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedDate", "AddedOn", "AddedTime", "EnDescription" },
                values: new object[] { new DateOnly(1995, 9, 11), new DateTime(2003, 8, 6, 23, 49, 0, 778, DateTimeKind.Local).AddTicks(6564), new TimeOnly(23, 49, 0, 778).Add(TimeSpan.FromTicks(6566)), "EnDescription 11" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedDate", "AddedOn", "AddedTime", "EnDescription" },
                values: new object[] { new DateOnly(2002, 7, 10), new DateTime(1999, 8, 10, 21, 4, 0, 778, DateTimeKind.Local).AddTicks(6568), new TimeOnly(21, 4, 0, 778).Add(TimeSpan.FromTicks(6570)), "EnDescription 12" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AddedDate", "AddedOn", "AddedTime", "EnDescription" },
                values: new object[] { new DateOnly(2003, 8, 9), new DateTime(2004, 8, 7, 18, 19, 0, 778, DateTimeKind.Local).AddTicks(6571), new TimeOnly(18, 19, 0, 778).Add(TimeSpan.FromTicks(6573)), "EnDescription 13" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnName",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EnDescription",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "AddedDate",
                table: "Products",
                newName: "AddedData");

            migrationBuilder.RenameColumn(
                name: "EnName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedData", "AddedOn", "AddedTime", "Description" },
                values: new object[] { new DateOnly(2003, 11, 1), new DateTime(2003, 11, 1, 5, 50, 16, 438, DateTimeKind.Local).AddTicks(6468), new TimeOnly(5, 50, 16, 438).Add(TimeSpan.FromTicks(6496)), "Description 1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedData", "AddedOn", "AddedTime", "Description" },
                values: new object[] { new DateOnly(2003, 12, 2), new DateTime(1993, 12, 2, 7, 5, 16, 438, DateTimeKind.Local).AddTicks(6507), new TimeOnly(7, 5, 16, 438).Add(TimeSpan.FromTicks(6509)), "Description 2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedData", "AddedOn", "AddedTime", "Description" },
                values: new object[] { new DateOnly(2003, 1, 3), new DateTime(2014, 1, 3, 7, 35, 16, 438, DateTimeKind.Local).AddTicks(6511), new TimeOnly(7, 35, 16, 438).Add(TimeSpan.FromTicks(6514)), "Description 3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedData", "AddedOn", "AddedTime", "Description" },
                values: new object[] { new DateOnly(2003, 2, 4), new DateTime(1999, 2, 4, 8, 50, 16, 438, DateTimeKind.Local).AddTicks(6515), new TimeOnly(8, 50, 16, 438).Add(TimeSpan.FromTicks(6517)), "Description 4" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedData", "AddedOn", "AddedTime", "Description" },
                values: new object[] { new DateOnly(2003, 3, 5), new DateTime(2004, 3, 5, 10, 5, 16, 438, DateTimeKind.Local).AddTicks(6519), new TimeOnly(10, 5, 16, 438).Add(TimeSpan.FromTicks(6521)), "Description 5" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedData", "AddedOn", "AddedTime", "Description" },
                values: new object[] { new DateOnly(1997, 4, 6), new DateTime(1984, 4, 5, 20, 35, 16, 438, DateTimeKind.Local).AddTicks(6523), new TimeOnly(20, 35, 16, 438).Add(TimeSpan.FromTicks(6525)), "Description 6" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedData", "AddedOn", "AddedTime", "Description" },
                values: new object[] { new DateOnly(1995, 5, 7), new DateTime(2004, 5, 7, 0, 35, 16, 438, DateTimeKind.Local).AddTicks(6527), new TimeOnly(17, 35, 16, 438).Add(TimeSpan.FromTicks(6529)), "Description 7" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedData", "AddedOn", "AddedTime", "Description" },
                values: new object[] { new DateOnly(2003, 6, 8), new DateTime(2004, 5, 6, 18, 50, 16, 438, DateTimeKind.Local).AddTicks(6531), new TimeOnly(18, 50, 16, 438).Add(TimeSpan.FromTicks(6533)), "Description 8" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedData", "AddedOn", "AddedTime", "Description" },
                values: new object[] { new DateOnly(2003, 5, 9), new DateTime(1997, 7, 3, 20, 20, 16, 438, DateTimeKind.Local).AddTicks(6535), new TimeOnly(20, 20, 16, 438).Add(TimeSpan.FromTicks(6537)), "Description 9" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedData", "AddedOn", "AddedTime", "Description" },
                values: new object[] { new DateOnly(2004, 8, 10), new DateTime(2000, 8, 4, 23, 50, 16, 438, DateTimeKind.Local).AddTicks(6539), new TimeOnly(23, 50, 16, 438).Add(TimeSpan.FromTicks(6541)), "Description 10" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedData", "AddedOn", "AddedTime", "Description" },
                values: new object[] { new DateOnly(1995, 9, 10), new DateTime(2003, 8, 6, 2, 5, 16, 438, DateTimeKind.Local).AddTicks(6543), new TimeOnly(2, 5, 16, 438).Add(TimeSpan.FromTicks(6545)), "Description 11" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedData", "AddedOn", "AddedTime", "Description" },
                values: new object[] { new DateOnly(2002, 7, 9), new DateTime(1999, 8, 9, 23, 20, 16, 438, DateTimeKind.Local).AddTicks(6546), new TimeOnly(23, 20, 16, 438).Add(TimeSpan.FromTicks(6548)), "Description 12" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AddedData", "AddedOn", "AddedTime", "Description" },
                values: new object[] { new DateOnly(2003, 8, 8), new DateTime(2004, 8, 6, 20, 35, 16, 438, DateTimeKind.Local).AddTicks(6550), new TimeOnly(20, 35, 16, 438).Add(TimeSpan.FromTicks(6552)), "Description 13" });
        }
    }
}
