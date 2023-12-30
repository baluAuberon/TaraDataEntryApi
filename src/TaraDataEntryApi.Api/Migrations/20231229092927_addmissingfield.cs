using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARA.DATAENTRY.API.Migrations
{
    /// <inheritdoc />
    public partial class addmissingfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "876839d2-35b5-4b83-ba26-00f188a0b5db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6bd0751-b4b5-4491-b5ee-85e307127384");

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "QuestionCapturing",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7818b8a7-7a79-4b6c-9c62-26564335b1ba", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "b2db9a97-05b6-48b8-9768-6bf055773ad5", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7818b8a7-7a79-4b6c-9c62-26564335b1ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2db9a97-05b6-48b8-9768-6bf055773ad5");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "QuestionCapturing");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "876839d2-35b5-4b83-ba26-00f188a0b5db", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "c6bd0751-b4b5-4491-b5ee-85e307127384", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });
        }
    }
}
