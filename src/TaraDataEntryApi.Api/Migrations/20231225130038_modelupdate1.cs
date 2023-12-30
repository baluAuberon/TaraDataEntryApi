using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARA.DATAENTRY.API.Migrations
{
    /// <inheritdoc />
    public partial class modelupdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44a45dab-5742-410a-ba3f-8ecfbbf0d639");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55a81906-f492-4549-b42d-90b83cb449ff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0791b0c1-5e39-4b0b-8baf-2d2cd2cc0e1e", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "40563883-1171-493c-ac11-0ce137b5e824", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0791b0c1-5e39-4b0b-8baf-2d2cd2cc0e1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40563883-1171-493c-ac11-0ce137b5e824");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44a45dab-5742-410a-ba3f-8ecfbbf0d639", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "55a81906-f492-4549-b42d-90b83cb449ff", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });
        }
    }
}
