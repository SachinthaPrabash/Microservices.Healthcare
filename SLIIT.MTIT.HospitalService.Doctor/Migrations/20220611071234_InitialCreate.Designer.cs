﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SLIIT.MTIT.HospitalService.Doctor.Database;

namespace SLIIT.MTIT.HospitalService.Doctor.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220611071234_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SLIIT.MTIT.HospitalService.Doctor.Database.doctorInfo", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DoctorLastName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DoctorfirstName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("registercode")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("specialization")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DoctorId");

                    b.ToTable("doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
