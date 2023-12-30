using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARA.DATAENTRY.API.Migrations
{
    /// <inheritdoc />
    public partial class MasterDataModeladdgenericfielsds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57a55308-5840-42c6-b67d-85d29afaacc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cb9e1bc-ce72-4b45-ab34-fb671d4cb3b5");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Topics",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Topics",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Topics",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Topics",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Topics",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Subjects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Subjects",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Subjects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Subjects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Subjects",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SubjectLessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SubjectLessons",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SubjectLessons",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "SubjectLessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "SubjectLessons",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Lessons",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Lessons",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Lessons",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Classes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Classes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Classes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Classes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Classes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ClassSubjects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ClassSubjects",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ClassSubjects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ClassSubjects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ClassSubjects",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "026013ee-e4cd-43d5-9046-1dba50c3b4e4", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "7b75b0a4-b22f-4be8-a4a3-e6f7654b003a", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "026013ee-e4cd-43d5-9046-1dba50c3b4e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b75b0a4-b22f-4be8-a4a3-e6f7654b003a");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SubjectLessons");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SubjectLessons");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SubjectLessons");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SubjectLessons");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SubjectLessons");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ClassSubjects");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ClassSubjects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ClassSubjects");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ClassSubjects");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ClassSubjects");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57a55308-5840-42c6-b67d-85d29afaacc2", "6649899a-3c06-4774-9e31-f5c98c5641c2", "Writer", "WRITER" },
                    { "9cb9e1bc-ce72-4b45-ab34-fb671d4cb3b5", "95e3cab0-feb5-4bfa-ab00-700f9176ea1b", "Reader", "READER" }
                });
        }
    }
}
