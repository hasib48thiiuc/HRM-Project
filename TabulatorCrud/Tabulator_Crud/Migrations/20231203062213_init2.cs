using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabulator_Crud.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ComId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Basic = table.Column<int>(type: "int", nullable: false),
                    HRent = table.Column<int>(type: "int", nullable: false),
                    medical = table.Column<int>(type: "int", nullable: false),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ComId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                    table.ForeignKey(
                        name: "FK_Departments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "ComId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesigId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesigName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesigId);
                    table.ForeignKey(
                        name: "FK_Designations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "ComId",
                        onDelete: ReferentialAction.NoAction );
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shiftName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shiftIn = table.Column<TimeSpan>(type: "time", nullable: false),
                    shiftOut = table.Column<TimeSpan>(type: "time", nullable: false),
                    shiftLate = table.Column<TimeSpan>(type: "time", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "ComId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    DesigId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gross = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Basic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Medical = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Others = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DtJoin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_ComId",
                        column: x => x.ComId,
                        principalTable: "Companies",
                        principalColumn: "ComId",
                        onDelete: ReferentialAction.NoAction );
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Employees_Designations_DesigId",
                        column: x => x.DesigId,
                        principalTable: "Designations",
                        principalColumn: "DesigId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Employees_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    ComId = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    DtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OutTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => new { x.ComId, x.EmpId, x.DtDate });
                    table.ForeignKey(
                        name: "FK_Attendances_Companies_ComId",
                        column: x => x.ComId,
                        principalTable: "Companies",
                        principalColumn: "ComId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Attendances_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceSummaries",
                columns: table => new
                {
                    ComId = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    DtYear = table.Column<int>(type: "int", nullable: false),
                    DtMonth = table.Column<int>(type: "int", nullable: false),
                    Present = table.Column<int>(type: "int", nullable: false),
                    Late = table.Column<int>(type: "int", nullable: false),
                    Absent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceSummaries", x => new { x.ComId, x.EmpId, x.DtYear, x.DtMonth });
                    table.ForeignKey(
                        name: "FK_AttendanceSummaries_Companies_ComId",
                        column: x => x.ComId,
                        principalTable: "Companies",
                        principalColumn: "ComId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AttendanceSummaries_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.NoAction        );
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmpId",
                table: "Attendances",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceSummaries_EmpId",
                table: "AttendanceSummaries",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyId",
                table: "Departments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_CompanyId",
                table: "Designations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ComId",
                table: "Employees",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeptId",
                table: "Employees",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesigId",
                table: "Employees",
                column: "DesigId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ShiftId",
                table: "Employees",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_CompanyId",
                table: "Shifts",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "AttendanceSummaries");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
