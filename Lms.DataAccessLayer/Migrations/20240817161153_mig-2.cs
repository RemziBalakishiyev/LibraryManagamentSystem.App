using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lms.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmPassword",
                schema: "account",
                table: "UserDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                schema: "account",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RegisterStatuses",
                schema: "library",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "For Registered Statuses"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterStatuses", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_StatusId",
                schema: "account",
                table: "UserDetails",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_RegisterStatuses_StatusId",
                schema: "account",
                table: "UserDetails",
                column: "StatusId",
                principalSchema: "library",
                principalTable: "RegisterStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                name: "IsConfirmPassword",
                schema: "account",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "account",
                table: "UserDetails");

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
