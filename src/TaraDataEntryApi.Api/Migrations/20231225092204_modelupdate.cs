using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARA.DATAENTRY.API.Migrations
{
    /// <inheritdoc />
    public partial class modelupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e5311e7-ffe0-488f-b554-ec0388a5cc20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae674cab-5202-4e0a-9e9e-e27522522466");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44a45dab-5742-410a-ba3f-8ecfbbf0d639", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "55a81906-f492-4549-b42d-90b83cb449ff", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "5e5311e7-ffe0-488f-b554-ec0388a5cc20", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" },
                    { "ae674cab-5202-4e0a-9e9e-e27522522466", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" }
                });
        }
    }
}
