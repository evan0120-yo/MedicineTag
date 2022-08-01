﻿// <auto-generated />
using System;
using MedicineTag.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicineTag.Migrations
{
    [DbContext(typeof(MedicineContext))]
    [Migration("20220729075920_updateClassType")]
    partial class updateClassType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MedicineTag.AppMedicineClass.MedicineClass", b =>
                {
                    b.Property<Guid>("MedicineClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("MedicineClassName")
                        .HasColumnType("longtext");

                    b.Property<string>("MedicineClassTpye")
                        .HasColumnType("longtext");

                    b.HasKey("MedicineClassId");

                    b.ToTable("medicineClass");
                });

            modelBuilder.Entity("MedicineTag.AppMedicineInfo.MedicineInfo", b =>
                {
                    b.Property<Guid>("MedicineInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MedicineInfoName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("MedicineInfoId");

                    b.ToTable("medicineInfos");
                });

            modelBuilder.Entity("MedicineTag.AppMedicineInfoClass.MedicineInfoClass", b =>
                {
                    b.Property<Guid>("MedicineInfoClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MedicineClassId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MedicineInfoId")
                        .HasColumnType("char(36)");

                    b.HasKey("MedicineInfoClassId");

                    b.ToTable("medicineInfoClass");
                });
#pragma warning restore 612, 618
        }
    }
}