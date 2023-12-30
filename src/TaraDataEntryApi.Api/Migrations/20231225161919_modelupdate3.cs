using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARA.DATAENTRY.API.Migrations
{
    /// <inheritdoc />
    public partial class modelupdate3 : Migration
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
                keyValue: "78e6c187-ee3d-449e-a44f-5aa65c3f586d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77ffcb9-5754-49e2-92fb-f692b3d68f0f");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14719122-7dc5-47a3-91bf-d6ade0e71142", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "26c2b3a9-0d8b-4e89-bdf5-51865aee5f84", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });

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
                keyValue: "14719122-7dc5-47a3-91bf-d6ade0e71142");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26c2b3a9-0d8b-4e89-bdf5-51865aee5f84");

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
                    { "78e6c187-ee3d-449e-a44f-5aa65c3f586d", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "e77ffcb9-5754-49e2-92fb-f692b3d68f0f", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
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
