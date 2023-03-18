﻿// <auto-generated />
using System;
using DAL.GF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.GF.Migrations
{
    [DbContext(typeof(GFDbContext))]
    [Migration("20230318151413_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.GF.Entities.BranchOffices", b =>
                {
                    b.Property<string>("BranchOfficeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BranchOfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BranchOfficeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("BranchOfficeCode");

                    b.ToTable("BranchOffices","GF");
                });

            modelBuilder.Entity("DAL.GF.Entities.Items", b =>
                {
                    b.Property<string>("ItemCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("ItemCode");

                    b.ToTable("Items","GF");
                });

            modelBuilder.Entity("DAL.GF.Entities.Remissions", b =>
                {
                    b.Property<int>("RemissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RemissionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RemissionQuantity")
                        .HasColumnType("int");

                    b.Property<string>("TechnicalCode")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RemissionId");

                    b.HasIndex("ItemCode");

                    b.HasIndex("TechnicalCode");

                    b.ToTable("Remissions","GF");
                });

            modelBuilder.Entity("DAL.GF.Entities.Technicals", b =>
                {
                    b.Property<string>("TechnicalCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BranchOfficeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TechnicalFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("TechnicalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("TechnicalSalary")
                        .HasColumnType("float");

                    b.HasKey("TechnicalCode");

                    b.HasIndex("BranchOfficeCode");

                    b.ToTable("Technicals","GF");
                });

            modelBuilder.Entity("DAL.GF.Entities.Remissions", b =>
                {
                    b.HasOne("DAL.GF.Entities.Items", "Items")
                        .WithMany()
                        .HasForeignKey("ItemCode");

                    b.HasOne("DAL.GF.Entities.Technicals", "Technicals")
                        .WithMany()
                        .HasForeignKey("TechnicalCode");
                });

            modelBuilder.Entity("DAL.GF.Entities.Technicals", b =>
                {
                    b.HasOne("DAL.GF.Entities.BranchOffices", "BranchOffices")
                        .WithMany()
                        .HasForeignKey("BranchOfficeCode");
                });
#pragma warning restore 612, 618
        }
    }
}
