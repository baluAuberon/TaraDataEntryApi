using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARA.DATAENTRY.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_ImageType_ImageTypeID",
                table: "Image");

            migrationBuilder.DropTable(
                name: "ImageType");

            migrationBuilder.DropIndex(
                name: "IX_Image_ImageTypeID",
                table: "Image");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca53e27a-925f-47c1-ab68-9277685edb6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eac51674-d51a-419c-8d27-2faa09cfaf14");

            migrationBuilder.AddColumn<Guid>(
                name: "TagId",
                table: "Tag",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageType",
                table: "Image",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "71bc3bd2-ad94-4646-8272-c7aff7a9543d", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" },
                    { "728d518d-52b9-4c98-a55a-9210a277668e", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71bc3bd2-ad94-4646-8272-c7aff7a9543d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "728d518d-52b9-4c98-a55a-9210a277668e");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "ImageType",
                table: "Image");

            migrationBuilder.CreateTable(
                name: "ImageType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ca53e27a-925f-47c1-ab68-9277685edb6a", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "eac51674-d51a-419c-8d27-2faa09cfaf14", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ImageTypeID",
                table: "Image",
                column: "ImageTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_ImageType_ImageTypeID",
                table: "Image",
                column: "ImageTypeID",
                principalTable: "ImageType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
