﻿// <auto-generated />
using System;
using Backrest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backrest.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Backrest.Data.Models.Cargos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("Backrest.Data.Models.Contifico.IncrementoClass", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("contadores")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("incrementos");
                });

            modelBuilder.Entity("Backrest.Data.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnType("longtext");

                    b.Property<int?>("CargosId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("Sueldo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("edad")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CargosId");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("Backrest.Data.Models.Files.FilesClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("banco")
                        .HasColumnType("longtext");

                    b.Property<string>("codigo")
                        .HasColumnType("longtext");

                    b.Property<string>("documento")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("monto")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<string>("oficina")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("bancoscon");
                });

            modelBuilder.Entity("Backrest.Data.Models.Files.Repostressum", b =>
                {
                    b.Property<string>("Total")
                        .HasColumnType("longtext");

                    b.Property<string>("banco")
                        .HasColumnType("longtext");

                    b.Property<string>("codigo_encontrado")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<string>("total_compras")
                        .HasColumnType("longtext");

                    b.ToTable("Reporte");
                });

            modelBuilder.Entity("Backrest.Data.Models.Files.Transacciones", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Operador")
                        .HasColumnType("longtext");

                    b.Property<string>("cedula")
                        .HasColumnType("longtext");

                    b.Property<string>("cliente")
                        .HasColumnType("longtext");

                    b.Property<string>("cobrado")
                        .HasColumnType("longtext");

                    b.Property<string>("comision")
                        .HasColumnType("longtext");

                    b.Property<string>("factura")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("forma_pago")
                        .HasColumnType("longtext");

                    b.Property<string>("idtranse")
                        .HasColumnType("longtext");

                    b.Property<string>("legal")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<string>("neto")
                        .HasColumnType("longtext");

                    b.Property<string>("transacciones")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("transacion");
                });

            modelBuilder.Entity("Backrest.Data.Models.Files.Users", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("Backrest.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("cedula")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.Property<string>("repuestauno")
                        .HasColumnType("longtext");

                    b.Property<string>("respuestados")
                        .HasColumnType("longtext");

                    b.Property<string>("respuestatres")
                        .HasColumnType("longtext");

                    b.Property<string>("username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("cedula")
                        .IsUnique();

                    b.ToTable("admin");
                });

            modelBuilder.Entity("Backrest.Data.Models.Empleado", b =>
                {
                    b.HasOne("Backrest.Data.Models.Cargos", null)
                        .WithMany("Empleados")
                        .HasForeignKey("CargosId");
                });

            modelBuilder.Entity("Backrest.Data.Models.Cargos", b =>
                {
                    b.Navigation("Empleados");
                });
#pragma warning restore 612, 618
        }
    }
}
