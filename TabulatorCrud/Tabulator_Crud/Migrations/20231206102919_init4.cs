using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabulator_Crud.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OutTime",
                table: "Attendances",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "InTime",
                table: "Attendances",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OutTime",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InTime",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }
    }
}
