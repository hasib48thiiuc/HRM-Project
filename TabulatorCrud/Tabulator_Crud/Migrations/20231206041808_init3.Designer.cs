﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tabulator_Crud.Models;

#nullable disable

namespace Tabulator_Crud.Migrations
{
    [DbContext(typeof(TabulatorDbContext))]
    [Migration("20231206041808_init3")]
    partial class init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Attendance", b =>
                {
                    b.Property<int>("ComId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("EmpId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("DtDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(3);

                    b.Property<string>("AttStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OutTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ComId", "EmpId", "DtDate");

                    b.HasIndex("EmpId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.AttendanceSummary", b =>
                {
                    b.Property<int>("ComId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("EmpId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("DtYear")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<int>("DtMonth")
                        .HasColumnType("int")
                        .HasColumnOrder(4);

                    b.Property<int>("Absent")
                        .HasColumnType("int");

                    b.Property<int>("Late")
                        .HasColumnType("int");

                    b.Property<int>("Present")
                        .HasColumnType("int");

                    b.HasKey("ComId", "EmpId", "DtYear", "DtMonth");

                    b.HasIndex("EmpId");

                    b.ToTable("AttendanceSummaries");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Company", b =>
                {
                    b.Property<int>("ComId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComId"), 1L, 1);

                    b.Property<int>("Basic")
                        .HasColumnType("int");

                    b.Property<string>("ComName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HRent")
                        .HasColumnType("int");

                    b.Property<bool>("IsInactive")
                        .HasColumnType("bit");

                    b.Property<int>("medical")
                        .HasColumnType("int");

                    b.HasKey("ComId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeptId"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeptId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Designation", b =>
                {
                    b.Property<int>("DesigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DesigId"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("DesigName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DesigId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"), 1L, 1);

                    b.Property<decimal>("Basic")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ComId")
                        .HasColumnType("int");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<int>("DesigId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtJoin")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmpCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Gross")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HRent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Medical")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Others")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.HasKey("EmpId");

                    b.HasIndex("ComId");

                    b.HasIndex("DeptId");

                    b.HasIndex("DesigId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("shiftIn")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("shiftLate")
                        .HasColumnType("time");

                    b.Property<string>("shiftName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("shiftOut")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Attendance", b =>
                {
                    b.HasOne("Tabulator_Crud.Models.Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tabulator_Crud.Models.Domain.Employee", "Employee")
                        .WithMany("Attendances")
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.AttendanceSummary", b =>
                {
                    b.HasOne("Tabulator_Crud.Models.Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tabulator_Crud.Models.Domain.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Department", b =>
                {
                    b.HasOne("Tabulator_Crud.Models.Domain.Company", "Company")
                        .WithMany("Departments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Designation", b =>
                {
                    b.HasOne("Tabulator_Crud.Models.Domain.Company", "Company")
                        .WithMany("DesignationList")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Employee", b =>
                {
                    b.HasOne("Tabulator_Crud.Models.Domain.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tabulator_Crud.Models.Domain.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Tabulator_Crud.Models.Domain.Designation", "Designation")
                        .WithMany("Employees")
                        .HasForeignKey("DesigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tabulator_Crud.Models.Domain.Shift", "Shift")
                        .WithMany("Employees")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Department");

                    b.Navigation("Designation");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Shift", b =>
                {
                    b.HasOne("Tabulator_Crud.Models.Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Company", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("DesignationList");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Designation", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Employee", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("Tabulator_Crud.Models.Domain.Shift", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
