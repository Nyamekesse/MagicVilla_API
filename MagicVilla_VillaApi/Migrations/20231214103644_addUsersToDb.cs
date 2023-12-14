using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MagicVilla_VillaApi.Migrations
{
    /// <inheritdoc />
    public partial class addUsersToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 13, 11, 19, 13, 197, DateTimeKind.Utc).AddTicks(2168), new DateTime(2023, 12, 13, 11, 19, 13, 197, DateTimeKind.Utc).AddTicks(2156) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 13, 11, 19, 13, 197, DateTimeKind.Utc).AddTicks(2192), new DateTime(2023, 12, 13, 11, 19, 13, 197, DateTimeKind.Utc).AddTicks(2189) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 13, 11, 19, 13, 197, DateTimeKind.Utc).AddTicks(2197), new DateTime(2023, 12, 13, 11, 19, 13, 197, DateTimeKind.Utc).AddTicks(2194) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 13, 11, 19, 13, 197, DateTimeKind.Utc).AddTicks(2202), new DateTime(2023, 12, 13, 11, 19, 13, 197, DateTimeKind.Utc).AddTicks(2199) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 13, 11, 19, 13, 197, DateTimeKind.Utc).AddTicks(2207), new DateTime(2023, 12, 13, 11, 19, 13, 197, DateTimeKind.Utc).AddTicks(2204) });
        }
    }
}
