using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lms.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                schema: "account",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                schema: "account",
                table: "Users");

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 17, 16, 11, 52, 309, DateTimeKind.Utc).AddTicks(3212), new DateTime(2024, 8, 17, 16, 11, 52, 309, DateTimeKind.Utc).AddTicks(3214) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 17, 16, 11, 52, 309, DateTimeKind.Utc).AddTicks(3219), new DateTime(2024, 8, 17, 16, 11, 52, 309, DateTimeKind.Utc).AddTicks(3219) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 17, 16, 11, 52, 309, DateTimeKind.Utc).AddTicks(3221), new DateTime(2024, 8, 17, 16, 11, 52, 309, DateTimeKind.Utc).AddTicks(3222) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 17, 16, 11, 52, 309, DateTimeKind.Utc).AddTicks(3224), new DateTime(2024, 8, 17, 16, 11, 52, 309, DateTimeKind.Utc).AddTicks(3224) });

            migrationBuilder.UpdateData(
                schema: "account",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 17, 16, 11, 52, 303, DateTimeKind.Utc).AddTicks(3350), new DateTime(2024, 8, 17, 16, 11, 52, 303, DateTimeKind.Utc).AddTicks(3357) });
        }
    }
}
