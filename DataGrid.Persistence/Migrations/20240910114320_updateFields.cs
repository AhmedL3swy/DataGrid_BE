using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataGrid.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ar_Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ar_Name",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "stock",
                table: "Products",
                newName: "Stock");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ArDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArDescription", "ArName" },
                values: new object[] { "وصف 1", "منتج 1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArDescription", "ArName" },
                values: new object[] { "وصف 2", "منتج 2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArDescription", "ArName" },
                values: new object[] { "وصف 3", "منتج 3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ArName",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Products",
                newName: "stock");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ar_Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ar_Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ar_Description", "ar_Name" },
                values: new object[] { "وصف 1", "منتج 1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ar_Description", "ar_Name" },
                values: new object[] { "وصف 2", "منتج 2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ar_Description", "ar_Name" },
                values: new object[] { "وصف 3", "منتج 3" });
        }
    }
}
