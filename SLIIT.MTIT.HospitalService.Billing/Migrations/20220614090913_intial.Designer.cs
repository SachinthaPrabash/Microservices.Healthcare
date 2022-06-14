﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SLIIT.MTIT.HospitalService.Billing.Database;

namespace SLIIT.MTIT.HospitalService.Billing.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220614090913_intial")]
    partial class intial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SLIIT.MTIT.HospitalService.Billing.Database.BillingInfo", b =>
                {
                    b.Property<int>("BillingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discount")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Total")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("BillingId");

                    b.ToTable("billings");
                });
#pragma warning restore 612, 618
        }
    }
}
