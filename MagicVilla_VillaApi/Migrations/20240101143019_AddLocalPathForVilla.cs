using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalPathForVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Villas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "ImageLocalPath",
                table: "Villas",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageLocalPath", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9446), null, new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9427) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageLocalPath", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9483), null, new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9477) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageLocalPath", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9492), null, new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9487) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageLocalPath", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9500), null, new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9495) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageLocalPath", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9508), null, new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9503) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLocalPath",
                table: "Villas");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Villas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 23, 23, 14, 7, 641, DateTimeKind.Utc).AddTicks(1073), new DateTime(2023, 12, 23, 23, 14, 7, 641, DateTimeKind.Utc).AddTicks(1061) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 23, 23, 14, 7, 641, DateTimeKind.Utc).AddTicks(1096), new DateTime(2023, 12, 23, 23, 14, 7, 641, DateTimeKind.Utc).AddTicks(1092) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 23, 23, 14, 7, 641, DateTimeKind.Utc).AddTicks(1102), new DateTime(2023, 12, 23, 23, 14, 7, 641, DateTimeKind.Utc).AddTicks(1099) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 23, 23, 14, 7, 641, DateTimeKind.Utc).AddTicks(1107), new DateTime(2023, 12, 23, 23, 14, 7, 641, DateTimeKind.Utc).AddTicks(1104) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 23, 23, 14, 7, 641, DateTimeKind.Utc).AddTicks(1112), new DateTime(2023, 12, 23, 23, 14, 7, 641, DateTimeKind.Utc).AddTicks(1110) });
        }
    }
}
