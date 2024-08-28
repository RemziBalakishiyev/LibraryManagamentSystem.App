using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lms.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           


            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "libraries",
                table: "UploadedFiles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                schema: "libraries",
                table: "UploadedFiles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_RegisterStatuses_StatusId",
                schema: "account",
                table: "UserDetails");

            migrationBuilder.DropTable(
                name: "RegisterStatuses",
                schema: "library");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_StatusId",
                schema: "account",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                schema: "account",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConfirmCode",
                schema: "account",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "IsConfirmPassword",
                schema: "account",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "account",
                table: "UserDetails");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "libraries",
                table: "UploadedFiles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                schema: "libraries",
                table: "UploadedFiles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 8, 18, 10, 15, 103, DateTimeKind.Utc).AddTicks(9149), new DateTime(2024, 8, 8, 18, 10, 15, 103, DateTimeKind.Utc).AddTicks(9151) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 8, 18, 10, 15, 103, DateTimeKind.Utc).AddTicks(9155), new DateTime(2024, 8, 8, 18, 10, 15, 103, DateTimeKind.Utc).AddTicks(9156) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 8, 18, 10, 15, 103, DateTimeKind.Utc).AddTicks(9158), new DateTime(2024, 8, 8, 18, 10, 15, 103, DateTimeKind.Utc).AddTicks(9158) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 8, 18, 10, 15, 103, DateTimeKind.Utc).AddTicks(9160), new DateTime(2024, 8, 8, 18, 10, 15, 103, DateTimeKind.Utc).AddTicks(9160) });

            migrationBuilder.UpdateData(
                schema: "account",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 8, 18, 10, 15, 99, DateTimeKind.Utc).AddTicks(554), new DateTime(2024, 8, 8, 18, 10, 15, 99, DateTimeKind.Utc).AddTicks(557) });
        }
    }
}
