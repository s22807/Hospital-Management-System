﻿// <auto-generated />
using System;
using HospitalManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240623185210_trzynasta")]
    partial class trzynasta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Department.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Department", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6bdea6a1-57c8-4a47-b074-04fe165d74de"),
                            Name = "Childcare"
                        },
                        new
                        {
                            Id = new Guid("10461b59-2e75-4487-9376-d839ffde35ab"),
                            Name = "Dentistry"
                        });
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Department.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid?>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("TagId");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Department.Room+Key", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("RentedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomKey", (string)null);
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Department.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tag", (string)null);
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Department.Visit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VisitStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BillId")
                        .IsUnique()
                        .HasFilter("[BillId] IS NOT NULL");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("RoomId");

                    b.HasIndex("TagId");

                    b.ToTable("Visit", (string)null);
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Payments.Bill", b =>
                {
                    b.Property<Guid>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<double>("PaidAmount")
                        .HasColumnType("float");

                    b.Property<Guid?>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VisitId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BillId");

                    b.HasIndex("PatientId");

                    b.ToTable("Bill", (string)null);
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Payments.Payment", b =>
                {
                    b.Property<Guid>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid>("BillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PaymentId");

                    b.HasIndex("BillId");

                    b.HasIndex("PatientId");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.People.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HoursWorked")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LoggedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.Property<Guid?>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VacationDays")
                        .HasColumnType("int");

                    b.Property<int?>("VisitTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("TagId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.People.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FathersName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Insured")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LoggedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("MothersName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patient", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("00843cea-7059-447f-93a7-bf465461c692"),
                            BirthDate = new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2024, 6, 23, 20, 52, 10, 43, DateTimeKind.Local).AddTicks(5387),
                            FirstName = "John",
                            Insured = true,
                            LastName = "Doe",
                            Pesel = "12345678901",
                            Sex = true
                        },
                        new
                        {
                            Id = new Guid("8f307f67-09e7-4305-92b3-cc54724b95d7"),
                            BirthDate = new DateTime(1990, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2024, 6, 23, 20, 52, 10, 43, DateTimeKind.Local).AddTicks(5454),
                            FirstName = "Jane",
                            Insured = true,
                            LastName = "Doe",
                            Pesel = "10987654321",
                            Sex = false
                        });
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Department.Room", b =>
                {
                    b.HasOne("HospitalManagementSystem.Domain.Models.Department.Department", "Department")
                        .WithMany("Rooms")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("HospitalManagementSystem.Domain.Models.Department.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Department");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Department.Room+Key", b =>
                {
                    b.HasOne("HospitalManagementSystem.Domain.Models.People.Employee", "Employee")
                        .WithMany("RentedKeys")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("HospitalManagementSystem.Domain.Models.Department.Room", "Room")
                        .WithMany("Keys")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Department.Visit", b =>
                {
                    b.HasOne("HospitalManagementSystem.Domain.Models.Payments.Bill", "Bill")
                        .WithOne("Visit")
                        .HasForeignKey("HospitalManagementSystem.Domain.Models.Department.Visit", "BillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HospitalManagementSystem.Domain.Models.People.Employee", "Doctor")
                        .WithMany("Visits")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystem.Domain.Models.People.Patient", "Patient")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystem.Domain.Models.Department.Room", "Room")
                        .WithMany("Visits")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystem.Domain.Models.Department.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Bill");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Room");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Payments.Bill", b =>
                {
                    b.HasOne("HospitalManagementSystem.Domain.Models.People.Patient", "Patient")
                        .WithMany("Bills")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Payments.Payment", b =>
                {
                    b.HasOne("HospitalManagementSystem.Domain.Models.Payments.Bill", "Bill")
                        .WithMany("Payments")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystem.Domain.Models.People.Patient", "Patient")
                        .WithMany("Payments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.People.Employee", b =>
                {
                    b.HasOne("HospitalManagementSystem.Domain.Models.Department.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("HospitalManagementSystem.Domain.Models.Department.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.Navigation("Department");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Department.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Department.Room", b =>
                {
                    b.Navigation("Keys");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.Payments.Bill", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Visit")
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.People.Employee", b =>
                {
                    b.Navigation("RentedKeys");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("HospitalManagementSystem.Domain.Models.People.Patient", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Payments");

                    b.Navigation("Visits");
                });
#pragma warning restore 612, 618
        }
    }
}
