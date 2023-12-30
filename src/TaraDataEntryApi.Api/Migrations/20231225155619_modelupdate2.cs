using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARA.DATAENTRY.API.Migrations
{
    /// <inheritdoc />
    public partial class modelupdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Lessons_LessonId",
                table: "Topics");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0791b0c1-5e39-4b0b-8baf-2d2cd2cc0e1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40563883-1171-493c-ac11-0ce137b5e824");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "Topics",
                newName: "LessonID");

            migrationBuilder.RenameIndex(
                name: "IX_Topics_LessonId",
                table: "Topics",
                newName: "IX_Topics_LessonID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "78e6c187-ee3d-449e-a44f-5aa65c3f586d", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "e77ffcb9-5754-49e2-92fb-f692b3d68f0f", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Lessons_LessonID",
                table: "Topics",
                column: "LessonID",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Lessons_LessonID",
                table: "Topics");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78e6c187-ee3d-449e-a44f-5aa65c3f586d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77ffcb9-5754-49e2-92fb-f692b3d68f0f");

            migrationBuilder.RenameColumn(
                name: "LessonID",
                table: "Topics",
                newName: "LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Topics_LessonID",
                table: "Topics",
                newName: "IX_Topics_LessonId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0791b0c1-5e39-4b0b-8baf-2d2cd2cc0e1e", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "40563883-1171-493c-ac11-0ce137b5e824", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Lessons_LessonId",
                table: "Topics",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
