using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwimTimeTracker.Data.Migrations
{
    public partial class CheckingEventDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Courses_CourseId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Strokes_Strokes_StrokeId",
                table: "Strokes");

            migrationBuilder.DropIndex(
                name: "IX_Strokes_StrokeId",
                table: "Strokes");

            migrationBuilder.DropColumn(
                name: "StrokeId",
                table: "Strokes");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Courses_CourseID",
                table: "Courses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Strokes",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CourseId",
                table: "Courses",
                newName: "IX_Courses_CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Courses_CourseID",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "StrokeId",
                table: "Strokes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Strokes_StrokeId",
                table: "Strokes",
                column: "StrokeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Courses_CourseId",
                table: "Courses",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Strokes_Strokes_StrokeId",
                table: "Strokes",
                column: "StrokeId",
                principalTable: "Strokes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Strokes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Courses",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Courses",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CourseID",
                table: "Courses",
                newName: "IX_Courses_CourseId");
        }
    }
}
