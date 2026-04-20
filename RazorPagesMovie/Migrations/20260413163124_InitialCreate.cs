using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesMovie.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Prescriber",
                columns: table => new
                {
                    PrescriberId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Department = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TrainedStatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriber", x => x.PrescriberId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    StudentNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
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

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrescriberId = table.Column<int>(type: "INTEGER", nullable: false),
                    CampusEventId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateAssigned = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    AttendanceConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    ReminderSent = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_Prescription_CampusEvent_CampusEventId",
                        column: x => x.CampusEventId,
                        principalTable: "CampusEvent",
                        principalColumn: "CampusEventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Prescriber_PrescriberId",
                        column: x => x.PrescriberId,
                        principalTable: "Prescriber",
                        principalColumn: "PrescriberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCaseNote",
                columns: table => new
                {
                    StudentCaseNoteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentCaseId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrescriberId = table.Column<int>(type: "INTEGER", nullable: false),
                    NoteText = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCaseNote", x => x.StudentCaseNoteId);
                    table.ForeignKey(
                        name: "FK_StudentCaseNote_StudentCase_StudentCaseId",
                        column: x => x.StudentCaseId,
                        principalTable: "StudentCase",
                        principalColumn: "StudentCaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCaseNote_Prescriber_PrescriberId",
                        column: x => x.PrescriberId,
                        principalTable: "Prescriber",
                        principalColumn: "PrescriberId",
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

            migrationBuilder.CreateIndex(
                name: "IX_StudentCaseNote_StudentCaseId",
                table: "StudentCaseNote",
                column: "StudentCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCaseNote_PrescriberId",
                table: "StudentCaseNote",
                column: "PrescriberId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_CampusEventId",
                table: "Prescription",
                column: "CampusEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PrescriberId",
                table: "Prescription",
                column: "PrescriberId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_StudentId",
                table: "Prescription",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCaseNote");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "StudentCase");

            migrationBuilder.DropTable(
                name: "CampusEvent");

            migrationBuilder.DropTable(
                name: "Prescriber");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
