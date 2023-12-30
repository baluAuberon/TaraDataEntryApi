using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARA.DATAENTRY.API.Migrations
{
    /// <inheritdoc />
    public partial class modelupdate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Subjects_SubjectId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Classes_ClassId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Lessons_LessonID",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1289922-2b3a-4fa2-9e93-4d1bfd42a4e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3fc7610-fe33-4bb5-9189-3f1f44dfc20c");

            migrationBuilder.RenameTable(
                name: "Topics",
                newName: "Topic");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "Lessons",
                newName: "Lesson");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "Class");

            migrationBuilder.RenameIndex(
                name: "IX_Topics_LessonID",
                table: "Topic",
                newName: "IX_Topic_LessonID");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_ClassId",
                table: "Subject",
                newName: "IX_Subject_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_SubjectId",
                table: "Lesson",
                newName: "IX_Lesson_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topic",
                table: "Topic",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class",
                table: "Class",
                column: "Id");

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

            migrationBuilder.CreateTable(
                name: "QuestionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SkillName = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionCapturing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    TopicId = table.Column<int>(type: "integer", nullable: false),
                    QuestionTypeId = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false),
                    QuestionImageId = table.Column<int>(type: "integer", nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionCapturing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionCapturing_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionCapturing_QuestionType_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionCapturing_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionCapturing_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionCapturing_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    ImageTypeID = table.Column<int>(type: "integer", nullable: false),
                    QuestionCapturingId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_ImageType_ImageTypeID",
                        column: x => x.ImageTypeID,
                        principalTable: "ImageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Image_QuestionCapturing_QuestionCapturingId",
                        column: x => x.QuestionCapturingId,
                        principalTable: "QuestionCapturing",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MCQOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionName = table.Column<string>(type: "text", nullable: false),
                    QuestionCapturingId = table.Column<int>(type: "integer", nullable: false),
                    IsAnswer = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCQOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MCQOption_QuestionCapturing_QuestionCapturingId",
                        column: x => x.QuestionCapturingId,
                        principalTable: "QuestionCapturing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagName = table.Column<string>(type: "text", nullable: false),
                    QuestionCapturingId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_QuestionCapturing_QuestionCapturingId",
                        column: x => x.QuestionCapturingId,
                        principalTable: "QuestionCapturing",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    ImageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionImage_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionImage_QuestionCapturing_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuestionCapturing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "068f7c96-7185-40da-b553-cdbfb2e05cc2", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" },
                    { "5ee78554-19a1-4cbe-a2a6-f9674e00a7f7", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ImageTypeID",
                table: "Image",
                column: "ImageTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_QuestionCapturingId",
                table: "Image",
                column: "QuestionCapturingId");

            migrationBuilder.CreateIndex(
                name: "IX_MCQOption_QuestionCapturingId",
                table: "MCQOption",
                column: "QuestionCapturingId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionCapturing_ClassId",
                table: "QuestionCapturing",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionCapturing_QuestionTypeId",
                table: "QuestionCapturing",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionCapturing_SkillId",
                table: "QuestionCapturing",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionCapturing_SubjectId",
                table: "QuestionCapturing",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionCapturing_TopicId",
                table: "QuestionCapturing",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionImage_ImageId",
                table: "QuestionImage",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionImage_QuestionId",
                table: "QuestionImage",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_QuestionCapturingId",
                table: "Tag",
                column: "QuestionCapturingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Subject_SubjectId",
                table: "Lesson",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Class_ClassId",
                table: "Subject",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Lesson_LessonID",
                table: "Topic",
                column: "LessonID",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Subject_SubjectId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Class_ClassId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Lesson_LessonID",
                table: "Topic");

            migrationBuilder.DropTable(
                name: "MCQOption");

            migrationBuilder.DropTable(
                name: "QuestionImage");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "ImageType");

            migrationBuilder.DropTable(
                name: "QuestionCapturing");

            migrationBuilder.DropTable(
                name: "QuestionType");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topic",
                table: "Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class",
                table: "Class");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "068f7c96-7185-40da-b553-cdbfb2e05cc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ee78554-19a1-4cbe-a2a6-f9674e00a7f7");

            migrationBuilder.RenameTable(
                name: "Topic",
                newName: "Topics");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "Lesson",
                newName: "Lessons");

            migrationBuilder.RenameTable(
                name: "Class",
                newName: "Classes");

            migrationBuilder.RenameIndex(
                name: "IX_Topic_LessonID",
                table: "Topics",
                newName: "IX_Topics_LessonID");

            migrationBuilder.RenameIndex(
                name: "IX_Subject_ClassId",
                table: "Subjects",
                newName: "IX_Subjects_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_SubjectId",
                table: "Lessons",
                newName: "IX_Lessons_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b1289922-2b3a-4fa2-9e93-4d1bfd42a4e1", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" },
                    { "d3fc7610-fe33-4bb5-9189-3f1f44dfc20c", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Subjects_SubjectId",
                table: "Lessons",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Classes_ClassId",
                table: "Subjects",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Lessons_LessonID",
                table: "Topics",
                column: "LessonID",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
