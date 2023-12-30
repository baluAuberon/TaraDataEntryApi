using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARA.DATAENTRY.API.Migrations
{
    /// <inheritdoc />
    public partial class modelupdate7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "068f7c96-7185-40da-b553-cdbfb2e05cc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ee78554-19a1-4cbe-a2a6-f9674e00a7f7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ca53e27a-925f-47c1-ab68-9277685edb6a", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "eac51674-d51a-419c-8d27-2faa09cfaf14", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca53e27a-925f-47c1-ab68-9277685edb6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eac51674-d51a-419c-8d27-2faa09cfaf14");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "068f7c96-7185-40da-b553-cdbfb2e05cc2", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" },
                    { "5ee78554-19a1-4cbe-a2a6-f9674e00a7f7", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" }
                });
        }
    }
}
