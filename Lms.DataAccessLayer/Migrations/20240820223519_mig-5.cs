using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lms.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfirmCode",
                schema: "account",
                table: "UserDetails",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 22, 35, 18, 285, DateTimeKind.Utc).AddTicks(6940), new DateTime(2024, 8, 20, 22, 35, 18, 285, DateTimeKind.Utc).AddTicks(6944) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 22, 35, 18, 285, DateTimeKind.Utc).AddTicks(6948), new DateTime(2024, 8, 20, 22, 35, 18, 285, DateTimeKind.Utc).AddTicks(6949) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 22, 35, 18, 285, DateTimeKind.Utc).AddTicks(6950), new DateTime(2024, 8, 20, 22, 35, 18, 285, DateTimeKind.Utc).AddTicks(6951) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 22, 35, 18, 285, DateTimeKind.Utc).AddTicks(6952), new DateTime(2024, 8, 20, 22, 35, 18, 285, DateTimeKind.Utc).AddTicks(6953) });

            migrationBuilder.UpdateData(
                schema: "account",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 22, 35, 18, 280, DateTimeKind.Utc).AddTicks(4037), new DateTime(2024, 8, 20, 22, 35, 18, 280, DateTimeKind.Utc).AddTicks(4039) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmCode",
                schema: "account",
                table: "UserDetails");

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
    }
}
