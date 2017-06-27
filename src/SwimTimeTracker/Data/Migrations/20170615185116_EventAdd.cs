using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SwimTimeTracker.Data.Migrations
{
    public partial class EventAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseID = table.Column<int>(nullable: false),
                    DistanceID = table.Column<int>(nullable: false),
                    StrokeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Events_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Distances_DistanceID",
                        column: x => x.DistanceID,
                        principalTable: "Distances",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Strokes_StrokeID",
                        column: x => x.StrokeID,
                        principalTable: "Strokes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "StrokeId",
                table: "Strokes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistanceID",
                table: "Distances",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Strokes_StrokeId",
                table: "Strokes",
                column: "StrokeId");

            migrationBuilder.CreateIndex(
                name: "IX_Distances_DistanceID",
                table: "Distances",
                column: "DistanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseId",
                table: "Courses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CourseID",
                table: "Events",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_DistanceID",
                table: "Events",
                column: "DistanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_StrokeID",
                table: "Events",
                column: "StrokeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Courses_CourseId",
                table: "Courses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Distances_Distances_DistanceID",
                table: "Distances",
                column: "DistanceID",
                principalTable: "Distances",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Strokes_Strokes_StrokeId",
                table: "Strokes",
                column: "StrokeId",
                principalTable: "Strokes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Courses_CourseId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Distances_Distances_DistanceID",
                table: "Distances");

            migrationBuilder.DropForeignKey(
                name: "FK_Strokes_Strokes_StrokeId",
                table: "Strokes");

            migrationBuilder.DropIndex(
                name: "IX_Strokes_StrokeId",
                table: "Strokes");

            migrationBuilder.DropIndex(
                name: "IX_Distances_DistanceID",
                table: "Distances");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StrokeId",
                table: "Strokes");

            migrationBuilder.DropColumn(
                name: "DistanceID",
                table: "Distances");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
