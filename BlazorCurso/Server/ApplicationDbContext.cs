using BlazorCurso.Shared.Entidades;
using BlazorCurso.Shared.Entidades.Somec;
using BlazorCurso.Shared.Entidades.Presupuesto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                    : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneroPelicula>().HasKey(x => new { x.GeneroId, x.PeliculaId });
            modelBuilder.Entity<PeliculaActor>().HasKey(x => new { x.PersonaId, x.PeliculaId });
            modelBuilder.Entity<Registro>().HasKey(x => new { x.SubcategoriaId, x.ConceptoId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<GeneroPelicula> GenerosPeliculas { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<PeliculaActor> PeliculasActores { get; set; }

        //Dbset para Somec
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Problema> Problemas { get; set; }
        public DbSet<Prueba> Pruebas { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<Shared.Entidades.Somec.Tipo> Tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Shared.Entidades.Somec.Valor> Valores { get; set; }

    }
}
