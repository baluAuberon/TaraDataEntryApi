using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARA.DATAENTRY.API.Migrations
{
    /// <inheritdoc />
    public partial class updatequestioncapteringmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_QuestionCapturing_QuestionCapturingId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionCapturing_QuestionType_QuestionTypeId",
                table: "QuestionCapturing");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionCapturing_Skill_SkillId",
                table: "QuestionCapturing");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionImage_QuestionCapturing_QuestionId",
                table: "QuestionImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_QuestionCapturing_QuestionCapturingId",
                table: "Tag");

            migrationBuilder.DropTable(
                name: "QuestionType");

            migrationBuilder.DropIndex(
                name: "IX_Tag_QuestionCapturingId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_QuestionImage_QuestionId",
                table: "QuestionImage");

            migrationBuilder.DropIndex(
                name: "IX_QuestionCapturing_QuestionTypeId",
                table: "QuestionCapturing");

            migrationBuilder.DropIndex(
                name: "IX_QuestionCapturing_SkillId",
                table: "QuestionCapturing");

            migrationBuilder.DropIndex(
                name: "IX_Image_QuestionCapturingId",
                table: "Image");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71bc3bd2-ad94-4646-8272-c7aff7a9543d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "728d518d-52b9-4c98-a55a-9210a277668e");

            migrationBuilder.DropColumn(
                name: "QuestionCapturingId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "QuestionCapturing");

            migrationBuilder.DropColumn(
                name: "QuestionImageId",
                table: "QuestionCapturing");

            migrationBuilder.DropColumn(
                name: "ImageType",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "QuestionCapturingId",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "QuestionImage",
                newName: "QuestionCapturingId");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "QuestionCapturing",
                newName: "QuestionType");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "QuestionCapturing",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0e0caf1-f61c-4346-b60a-5067c6e4d6eb", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "dd09016d-2fd0-44a2-9601-9b58d7aa24f4", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionImage_QuestionCapturingId",
                table: "QuestionImage",
                column: "QuestionCapturingId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionCapturing_LessonId",
                table: "QuestionCapturing",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionCapturing_Lesson_LessonId",
                table: "QuestionCapturing",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionImage_QuestionCapturing_QuestionCapturingId",
                table: "QuestionImage",
                column: "QuestionCapturingId",
                principalTable: "QuestionCapturing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionCapturing_Lesson_LessonId",
                table: "QuestionCapturing");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionImage_QuestionCapturing_QuestionCapturingId",
                table: "QuestionImage");

            migrationBuilder.DropIndex(
                name: "IX_QuestionImage_QuestionCapturingId",
                table: "QuestionImage");

            migrationBuilder.DropIndex(
                name: "IX_QuestionCapturing_LessonId",
                table: "QuestionCapturing");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0e0caf1-f61c-4346-b60a-5067c6e4d6eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd09016d-2fd0-44a2-9601-9b58d7aa24f4");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "QuestionCapturing");

            migrationBuilder.RenameColumn(
                name: "QuestionCapturingId",
                table: "QuestionImage",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "QuestionType",
                table: "QuestionCapturing",
                newName: "SkillId");

            migrationBuilder.AddColumn<int>(
                name: "QuestionCapturingId",
                table: "Tag",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "QuestionCapturing",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QuestionImageId",
                table: "QuestionCapturing",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageType",
                table: "Image",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionCapturingId",
                table: "Image",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuestionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TypeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "71bc3bd2-ad94-4646-8272-c7aff7a9543d", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" },
                    { "728d518d-52b9-4c98-a55a-9210a277668e", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_QuestionCapturingId",
                table: "Tag",
                column: "QuestionCapturingId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionImage_QuestionId",
                table: "QuestionImage",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionCapturing_QuestionTypeId",
                table: "QuestionCapturing",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionCapturing_SkillId",
                table: "QuestionCapturing",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_QuestionCapturingId",
                table: "Image",
                column: "QuestionCapturingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_QuestionCapturing_QuestionCapturingId",
                table: "Image",
                column: "QuestionCapturingId",
                principalTable: "QuestionCapturing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionCapturing_QuestionType_QuestionTypeId",
                table: "QuestionCapturing",
                column: "QuestionTypeId",
                principalTable: "QuestionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionCapturing_Skill_SkillId",
                table: "QuestionCapturing",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionImage_QuestionCapturing_QuestionId",
                table: "QuestionImage",
                column: "QuestionId",
                principalTable: "QuestionCapturing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_QuestionCapturing_QuestionCapturingId",
                table: "Tag",
                column: "QuestionCapturingId",
                principalTable: "QuestionCapturing",
                principalColumn: "Id");
        }
    }
}
