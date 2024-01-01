using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MagicVilla_VillaApi.Migrations
{
    /// <inheritdoc />
    public partial class addRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    JwtTokenId = table.Column<string>(type: "text", nullable: false),
                    Refresh_Token = table.Column<string>(type: "text", nullable: false),
                    IsValid = table.Column<bool>(type: "boolean", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 20, 43, 16, 784, DateTimeKind.Utc).AddTicks(1389), new DateTime(2024, 1, 1, 20, 43, 16, 784, DateTimeKind.Utc).AddTicks(1379) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 20, 43, 16, 784, DateTimeKind.Utc).AddTicks(1411), new DateTime(2024, 1, 1, 20, 43, 16, 784, DateTimeKind.Utc).AddTicks(1408) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 20, 43, 16, 784, DateTimeKind.Utc).AddTicks(1414), new DateTime(2024, 1, 1, 20, 43, 16, 784, DateTimeKind.Utc).AddTicks(1412) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 20, 43, 16, 784, DateTimeKind.Utc).AddTicks(1418), new DateTime(2024, 1, 1, 20, 43, 16, 784, DateTimeKind.Utc).AddTicks(1416) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 20, 43, 16, 784, DateTimeKind.Utc).AddTicks(1421), new DateTime(2024, 1, 1, 20, 43, 16, 784, DateTimeKind.Utc).AddTicks(1419) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9446), new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9427) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9483), new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9477) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9492), new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9487) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9500), new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9495) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9508), new DateTime(2024, 1, 1, 14, 30, 11, 490, DateTimeKind.Utc).AddTicks(9503) });
        }
    }
}
