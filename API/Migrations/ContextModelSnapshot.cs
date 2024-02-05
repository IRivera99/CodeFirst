﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Data.Avion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AutonomiaKm")
                        .HasColumnType("integer");

                    b.Property<int>("CantidadPasajeros")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdFabricante")
                        .HasColumnType("uuid");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdFabricante");

                    b.ToTable("Aviones");
                });

            modelBuilder.Entity("API.Data.Fabricante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Fabricantes");
                });

            modelBuilder.Entity("API.Data.Usuario", b =>
                {
                    b.Property<string>("NombreUsuario")
                        .HasColumnType("text");

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("NombreUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("API.Data.Avion", b =>
                {
                    b.HasOne("API.Data.Fabricante", "Fabricante")
                        .WithMany("Aviones")
                        .HasForeignKey("IdFabricante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fabricante");
                });

            modelBuilder.Entity("API.Data.Fabricante", b =>
                {
                    b.Navigation("Aviones");
                });
#pragma warning restore 612, 618
        }
    }
}
