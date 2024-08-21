using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lms.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "account",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 19, 21, 33, 41, 921, DateTimeKind.Utc).AddTicks(9515), new DateTime(2024, 8, 19, 21, 33, 41, 921, DateTimeKind.Utc).AddTicks(9521) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 19, 21, 33, 41, 921, DateTimeKind.Utc).AddTicks(9529), new DateTime(2024, 8, 19, 21, 33, 41, 921, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 19, 21, 33, 41, 921, DateTimeKind.Utc).AddTicks(9531), new DateTime(2024, 8, 19, 21, 33, 41, 921, DateTimeKind.Utc).AddTicks(9532) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 19, 21, 33, 41, 921, DateTimeKind.Utc).AddTicks(9534), new DateTime(2024, 8, 19, 21, 33, 41, 921, DateTimeKind.Utc).AddTicks(9534) });

            migrationBuilder.UpdateData(
                schema: "account",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 19, 21, 33, 41, 915, DateTimeKind.Utc).AddTicks(9521), new DateTime(2024, 8, 19, 21, 33, 41, 915, DateTimeKind.Utc).AddTicks(9527) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "account",
                table: "Users",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 19, 18, 0, 3, 752, DateTimeKind.Utc).AddTicks(8387), new DateTime(2024, 8, 19, 18, 0, 3, 752, DateTimeKind.Utc).AddTicks(8390) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 19, 18, 0, 3, 752, DateTimeKind.Utc).AddTicks(8393), new DateTime(2024, 8, 19, 18, 0, 3, 752, DateTimeKind.Utc).AddTicks(8394) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 19, 18, 0, 3, 752, DateTimeKind.Utc).AddTicks(8396), new DateTime(2024, 8, 19, 18, 0, 3, 752, DateTimeKind.Utc).AddTicks(8397) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 19, 18, 0, 3, 752, DateTimeKind.Utc).AddTicks(8398), new DateTime(2024, 8, 19, 18, 0, 3, 752, DateTimeKind.Utc).AddTicks(8399) });

            migrationBuilder.UpdateData(
                schema: "account",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 19, 18, 0, 3, 747, DateTimeKind.Utc).AddTicks(8508), new DateTime(2024, 8, 19, 18, 0, 3, 747, DateTimeKind.Utc).AddTicks(8511) });
        }
    }
}
