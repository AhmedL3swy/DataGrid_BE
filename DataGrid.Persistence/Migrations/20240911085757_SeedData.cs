using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataGrid.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "AddedData",
                table: "Products",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "AddedTime",
                table: "Products",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedData", "AddedOn", "AddedTime", "ArDescription", "ArName", "CategoryId", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 4, new DateOnly(2023, 9, 4), new DateTime(2023, 9, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeOnly(13, 0, 0), "وصف 4", "منتج 4", 1, "Description 4", "Product 4", 400m, 10 },
                    { 5, new DateOnly(2023, 9, 5), new DateTime(2023, 9, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), new TimeOnly(9, 30, 0), "وصف 5", "منتج 5", 2, "Description 5", "Product 5", 500m, 30 },
                    { 6, new DateOnly(2023, 9, 6), new DateTime(2023, 9, 6, 14, 15, 0, 0, DateTimeKind.Unspecified), new TimeOnly(14, 15, 0), "وصف 6", "منتج 6", 3, "Description 6", "Product 6", 600m, 15 },
                    { 7, new DateOnly(2023, 9, 7), new DateTime(2023, 9, 7, 10, 45, 0, 0, DateTimeKind.Unspecified), new TimeOnly(10, 45, 0), "وصف 7", "منتج 7", 1, "Description 7", "Product 7", 700m, 25 },
                    { 8, new DateOnly(2023, 9, 8), new DateTime(2023, 9, 8, 16, 30, 0, 0, DateTimeKind.Unspecified), new TimeOnly(16, 30, 0), "وصف 8", "منتج 8", 2, "Description 8", "Product 8", 800m, 20 },
                    { 9, new DateOnly(2023, 9, 9), new DateTime(2023, 9, 9, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeOnly(15, 0, 0), "وصف 9", "منتج 9", 3, "Description 9", "Product 9", 900m, 35 },
                    { 10, new DateOnly(2023, 9, 10), new DateTime(2023, 9, 10, 11, 30, 0, 0, DateTimeKind.Unspecified), new TimeOnly(11, 30, 0), "وصف 10", "منتج 10", 1, "Description 10", "Product 10", 1000m, 5 },
                    { 11, new DateOnly(2023, 9, 11), new DateTime(2023, 9, 11, 13, 15, 0, 0, DateTimeKind.Unspecified), new TimeOnly(13, 15, 0), "وصف 11", "منتج 11", 2, "Description 11", "Product 11", 1100m, 40 },
                    { 12, new DateOnly(2023, 9, 12), new DateTime(2023, 9, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeOnly(12, 0, 0), "وصف 12", "منتج 12", 3, "Description 12", "Product 12", 1200m, 10 },
                    { 13, new DateOnly(2023, 9, 13), new DateTime(2023, 9, 13, 14, 45, 0, 0, DateTimeKind.Unspecified), new TimeOnly(14, 45, 0), "وصف 13", "منتج 13", 1, "Description 13", "Product 13", 1300m, 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DropColumn(
                name: "AddedData",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AddedTime",
                table: "Products");
        }
    }
}
