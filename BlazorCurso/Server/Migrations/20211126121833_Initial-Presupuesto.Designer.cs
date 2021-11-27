﻿// <auto-generated />
using System;
using BlazorCurso.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorCurso.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211126121833_Initial-Presupuesto")]
    partial class InitialPresupuesto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.GeneroPelicula", b =>
                {
                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.HasKey("GeneroId", "PeliculaId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("GenerosPeliculas");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EnCartelera")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Lanzamiento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Poster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resumen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.PeliculaActor", b =>
                {
                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<string>("Personaje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonaId", "PeliculaId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("PeliculasActores");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biografía")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaNacimiento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Presupuesto.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Presupuesto.Concepto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Concepto");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Presupuesto.Movimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RegistroConceptoId")
                        .HasColumnType("int");

                    b.Property<int?>("RegistroSubcategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("RegsitroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegistroSubcategoriaId", "RegistroConceptoId");

                    b.ToTable("Movimiento");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Presupuesto.Registro", b =>
                {
                    b.Property<int>("SubcategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("ConceptoId")
                        .HasColumnType("int");

                    b.HasKey("SubcategoriaId", "ConceptoId");

                    b.HasIndex("ConceptoId");

                    b.ToTable("Registro");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Presupuesto.Subcategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Subcategoria");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Motivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeguimientoId")
                        .HasColumnType("int");

                    b.Property<string>("Tratamiento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SeguimientoId");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PruebaId")
                        .HasColumnType("int");

                    b.Property<string>("Ruta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PruebaId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Problema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SeguimientoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoProblemaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeguimientoId");

                    b.HasIndex("TipoProblemaId");

                    b.ToTable("Problemas");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Prueba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resultado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeguimientoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoPruebaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeguimientoId");

                    b.HasIndex("TipoPruebaId");

                    b.ToTable("Pruebas");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Seguimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Seguimientos");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Tipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tipos");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlergiasMedicamentosas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AntecedentesPersonales")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("HistoriaClinica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroIdentificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Valor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoId");

                    b.ToTable("Valores");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.GeneroPelicula", b =>
                {
                    b.HasOne("BlazorCurso.Shared.Entidades.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorCurso.Shared.Entidades.Pelicula", "Pelicula")
                        .WithMany("GenerosPelicula")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.PeliculaActor", b =>
                {
                    b.HasOne("BlazorCurso.Shared.Entidades.Pelicula", "Pelicula")
                        .WithMany("PeliculaActor")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorCurso.Shared.Entidades.Persona", "Persona")
                        .WithMany("PeliculaActor")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelicula");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Presupuesto.Movimiento", b =>
                {
                    b.HasOne("BlazorCurso.Shared.Entidades.Presupuesto.Registro", "Registro")
                        .WithMany("Movimientos")
                        .HasForeignKey("RegistroSubcategoriaId", "RegistroConceptoId");

                    b.Navigation("Registro");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Presupuesto.Registro", b =>
                {
                    b.HasOne("BlazorCurso.Shared.Entidades.Presupuesto.Concepto", "Concepto")
                        .WithMany("SubcategoriaConceptos")
                        .HasForeignKey("ConceptoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorCurso.Shared.Entidades.Presupuesto.Subcategoria", "Subcategoria")
                        .WithMany("SubcategoriaConceptos")
                        .HasForeignKey("SubcategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concepto");

                    b.Navigation("Subcategoria");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Presupuesto.Subcategoria", b =>
                {
                    b.HasOne("BlazorCurso.Shared.Entidades.Presupuesto.Categoria", "Categoria")
                        .WithMany("Subcategorias")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Consulta", b =>
                {
                    b.HasOne("BlazorCurso.Shared.Entidades.Somec.Seguimiento", "Seguimiento")
                        .WithMany("Consultas")
                        .HasForeignKey("SeguimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seguimiento");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Documento", b =>
                {
                    b.HasOne("BlazorCurso.Shared.Entidades.Somec.Prueba", "Prueba")
                        .WithMany("Documentos")
                        .HasForeignKey("PruebaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorCurso.Shared.Entidades.Somec.Valor", "TipoDocumento")
                        .WithMany("Documentos")
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prueba");

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Problema", b =>
                {
                    b.HasOne("BlazorCurso.Shared.Entidades.Somec.Seguimiento", "Seguimiento")
                        .WithMany("Problemas")
                        .HasForeignKey("SeguimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorCurso.Shared.Entidades.Somec.Valor", "TipoProblema")
                        .WithMany("Problemas")
                        .HasForeignKey("TipoProblemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seguimiento");

                    b.Navigation("TipoProblema");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Prueba", b =>
                {
                    b.HasOne("BlazorCurso.Shared.Entidades.Somec.Seguimiento", "Seguimiento")
                        .WithMany("Pruebas")
                        .HasForeignKey("SeguimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorCurso.Shared.Entidades.Somec.Valor", "TipoPrueba")
                        .WithMany("Pruebas")
                        .HasForeignKey("TipoPruebaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seguimiento");

                    b.Navigation("TipoPrueba");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Seguimiento", b =>
                {
                    b.HasOne("BlazorCurso.Shared.Entidades.Somec.Usuario", "Usuario")
                        .WithMany("Seguimientos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Valor", b =>
                {
                    b.HasOne("BlazorCurso.Shared.Entidades.Somec.Tipo", "Tipo")
                        .WithMany("Valores")
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Pelicula", b =>
                {
                    b.Navigation("GenerosPelicula");

                    b.Navigation("PeliculaActor");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Persona", b =>
                {
                    b.Navigation("PeliculaActor");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Presupuesto.Categoria", b =>
                {
                    b.Navigation("Subcategorias");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Presupuesto.Concepto", b =>
                {
                    b.Navigation("SubcategoriaConceptos");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Presupuesto.Registro", b =>
                {
                    b.Navigation("Movimientos");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Presupuesto.Subcategoria", b =>
                {
                    b.Navigation("SubcategoriaConceptos");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Prueba", b =>
                {
                    b.Navigation("Documentos");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Seguimiento", b =>
                {
                    b.Navigation("Consultas");

                    b.Navigation("Problemas");

                    b.Navigation("Pruebas");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Tipo", b =>
                {
                    b.Navigation("Valores");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Usuario", b =>
                {
                    b.Navigation("Seguimientos");
                });

            modelBuilder.Entity("BlazorCurso.Shared.Entidades.Somec.Valor", b =>
                {
                    b.Navigation("Documentos");

                    b.Navigation("Problemas");

                    b.Navigation("Pruebas");
                });
#pragma warning restore 612, 618
        }
    }
}
