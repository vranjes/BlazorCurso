using BlazorCurso.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCurso.Shared.DTOs
{
    public class PelicularVisualizarDTO
    {
        public Pelicula Pelicula { get; set; }
        public List<Genero> Generos { get; set; }
        public List<Persona> Actores { get; set; }
        public int VotoUsuario { get; set; }
        public double PromedioVotos { get; set; }
    }
}
