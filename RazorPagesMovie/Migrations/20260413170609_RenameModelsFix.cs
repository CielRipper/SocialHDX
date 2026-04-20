using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesMovie.Migrations
{
    /// <inheritdoc />
    public partial class RenameModelsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCaseNote_StudentCase_StudentCaseId",
                table: "StudentCaseNote");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_CampusEvent_CampusEventId",
                table: "Prescription");

            migrationBuilder.DropTable(
                name: "StudentCase");

            migrationBuilder.DropTable(
                name: "CampusEvent");

            migrationBuilder.RenameColumn(
                name: "CampusEventId",
                table: "Prescription",
                newName: "CampusEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_CampusEventId",
                table: "Prescription",
                newName: "IX_Prescription_CampusEventId");

            migrationBuilder.RenameColumn(
                name: "StudentCaseId",
                table: "StudentCaseNote",
                newName: "StudentCaseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCaseNote_StudentCaseId",
                table: "StudentCaseNote",
                newName: "IX_StudentCaseNote_StudentCaseId");

            migrationBuilder.CreateTable(
                name: "CampusEvent",
                columns: table => new
                {
                    CampusEventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CampusEventDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CampusEventTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SourceLink = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampusEvent", x => x.CampusEventId);
                });

            migrationBuilder.CreateTable(
                name: "StudentCase",
                columns: table => new
                {
                    StudentCaseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrescriberId = table.Column<int>(type: "INTEGER", nullable: false),
                    OpenedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StudentCaseReason = table.Column<string>(type: "TEXT", nullable: false),
                    StudentCaseStatus = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCase", x => x.StudentCaseId);
                    table.ForeignKey(
                        name: "FK_StudentCase_Prescriber_PrescriberId",
                        column: x => x.PrescriberId,
                        principalTable: "Prescriber",
                        principalColumn: "PrescriberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCase_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCase_PrescriberId",
                table: "StudentCase",
                column: "PrescriberId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCase_StudentId",
                table: "StudentCase",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCaseNote_StudentCase_StudentCaseId",
                table: "StudentCaseNote",
                column: "StudentCaseId",
                principalTable: "StudentCase",
                principalColumn: "StudentCaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_CampusEvent_CampusEventId",
                table: "Prescription",
                column: "CampusEventId",
                principalTable: "CampusEvent",
                principalColumn: "CampusEventId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCaseNote_StudentCase_StudentCaseId",
                table: "StudentCaseNote");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_CampusEvent_CampusEventId",
                table: "Prescription");

            migrationBuilder.DropTable(
                name: "CampusEvent");

            migrationBuilder.DropTable(
                name: "StudentCase");

            migrationBuilder.RenameColumn(
                name: "CampusEventId",
                table: "Prescription",
                newName: "CampusEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_CampusEventId",
                table: "Prescription",
                newName: "IX_Prescription_CampusEventId");

            migrationBuilder.RenameColumn(
                name: "StudentCaseId",
                table: "StudentCaseNote",
                newName: "StudentCaseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCaseNote_StudentCaseId",
                table: "StudentCaseNote",
                newName: "IX_StudentCaseNote_StudentCaseId");

            migrationBuilder.CreateTable(
                name: "StudentCase",
                columns: table => new
                {
                    StudentCaseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrescriberId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentCaseReason = table.Column<string>(type: "TEXT", nullable: false),
                    StudentCaseStatus = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    OpenedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCase", x => x.StudentCaseId);
                    table.ForeignKey(
                        name: "FK_StudentCase_Prescriber_PrescriberId",
                        column: x => x.PrescriberId,
                        principalTable: "Prescriber",
                        principalColumn: "PrescriberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCase_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampusEvent",
                columns: table => new
                {
                    CampusEventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CampusEventDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CampusEventTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    SourceLink = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampusEvent", x => x.CampusEventId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCase_PrescriberId",
                table: "StudentCase",
                column: "PrescriberId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCase_StudentId",
                table: "StudentCase",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCaseNote_StudentCase_StudentCaseId",
                table: "StudentCaseNote",
                column: "StudentCaseId",
                principalTable: "StudentCase",
                principalColumn: "StudentCaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_CampusEvent_CampusEventId",
                table: "Prescription",
                column: "CampusEventId",
                principalTable: "CampusEvent",
                principalColumn: "CampusEventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
