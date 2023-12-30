using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARA.DATAENTRY.API.Migrations
{
    /// <inheritdoc />
    public partial class addmissingfield1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7818b8a7-7a79-4b6c-9c62-26564335b1ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2db9a97-05b6-48b8-9768-6bf055773ad5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "704cd07d-bbbb-4a40-adf7-c07949af0b06", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "8a51e0e7-7e55-4241-b15f-9bcc8d9dc2df", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "704cd07d-bbbb-4a40-adf7-c07949af0b06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a51e0e7-7e55-4241-b15f-9bcc8d9dc2df");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7818b8a7-7a79-4b6c-9c62-26564335b1ba", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "b2db9a97-05b6-48b8-9768-6bf055773ad5", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });
        }
    }
}
