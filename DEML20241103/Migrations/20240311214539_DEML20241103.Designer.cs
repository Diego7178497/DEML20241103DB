﻿// <auto-generated />
using System;
using DEML20241103.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DEML20241103.Migrations
{
    [DbContext(typeof(DEML20241103Context))]
    [Migration("20240311214539_DEML20241103")]
    partial class DEML20241103
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DEML20241103.Models.DetProyecto", b =>
                {
                    b.Property<int>("DetProyectoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetProyectoId"), 1L, 1);

                    b.Property<DateTime>("FechaInicial")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Orden")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<string>("Tarea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DetProyectoId");

                    b.HasIndex("ProyectoId");

                    b.ToTable("DetProyectos");
                });

            modelBuilder.Entity("DEML20241103.Models.Proyecto", b =>
                {
                    b.Property<int>("ProyectoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProyectoId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaInicial")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProyectoId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("DEML20241103.Models.DetProyecto", b =>
                {
                    b.HasOne("DEML20241103.Models.Proyecto", "Proyecto")
                        .WithMany("DetProyectos")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("DEML20241103.Models.Proyecto", b =>
                {
                    b.Navigation("DetProyectos");
                });
#pragma warning restore 612, 618
        }
    }
}