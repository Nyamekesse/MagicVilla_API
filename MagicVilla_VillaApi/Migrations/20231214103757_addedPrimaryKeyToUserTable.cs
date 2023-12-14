using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaApi.Migrations
{
    /// <inheritdoc />
    public partial class addedPrimaryKeyToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 14, 10, 37, 56, 687, DateTimeKind.Utc).AddTicks(7994), new DateTime(2023, 12, 14, 10, 37, 56, 687, DateTimeKind.Utc).AddTicks(7985) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 14, 10, 37, 56, 687, DateTimeKind.Utc).AddTicks(8015), new DateTime(2023, 12, 14, 10, 37, 56, 687, DateTimeKind.Utc).AddTicks(8013) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 14, 10, 37, 56, 687, DateTimeKind.Utc).AddTicks(8019), new DateTime(2023, 12, 14, 10, 37, 56, 687, DateTimeKind.Utc).AddTicks(8017) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 14, 10, 37, 56, 687, DateTimeKind.Utc).AddTicks(8023), new DateTime(2023, 12, 14, 10, 37, 56, 687, DateTimeKind.Utc).AddTicks(8021) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 14, 10, 37, 56, 687, DateTimeKind.Utc).AddTicks(8026), new DateTime(2023, 12, 14, 10, 37, 56, 687, DateTimeKind.Utc).AddTicks(8024) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 14, 10, 36, 37, 159, DateTimeKind.Utc).AddTicks(5171), new DateTime(2023, 12, 14, 10, 36, 37, 159, DateTimeKind.Utc).AddTicks(5163) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 14, 10, 36, 37, 159, DateTimeKind.Utc).AddTicks(5194), new DateTime(2023, 12, 14, 10, 36, 37, 159, DateTimeKind.Utc).AddTicks(5189) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 14, 10, 36, 37, 159, DateTimeKind.Utc).AddTicks(5203), new DateTime(2023, 12, 14, 10, 36, 37, 159, DateTimeKind.Utc).AddTicks(5199) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 14, 10, 36, 37, 159, DateTimeKind.Utc).AddTicks(5211), new DateTime(2023, 12, 14, 10, 36, 37, 159, DateTimeKind.Utc).AddTicks(5208) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 14, 10, 36, 37, 159, DateTimeKind.Utc).AddTicks(5220), new DateTime(2023, 12, 14, 10, 36, 37, 159, DateTimeKind.Utc).AddTicks(5216) });
        }
    }
}
