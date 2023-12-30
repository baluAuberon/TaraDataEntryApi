using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARA.DATAENTRY.API.Migrations
{
    /// <inheritdoc />
    public partial class MasterDataModeladdmoregenericfielsds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "026013ee-e4cd-43d5-9046-1dba50c3b4e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b75b0a4-b22f-4be8-a4a3-e6f7654b003a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "615bd53c-5924-4126-a06b-1e96446b86c6", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "7e5a38d5-e3b7-4c45-b2ea-faaf77df2614", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "615bd53c-5924-4126-a06b-1e96446b86c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e5a38d5-e3b7-4c45-b2ea-faaf77df2614");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "026013ee-e4cd-43d5-9046-1dba50c3b4e4", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "7b75b0a4-b22f-4be8-a4a3-e6f7654b003a", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });
        }
    }
}
