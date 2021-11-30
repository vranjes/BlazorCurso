using BlazorCurso.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCurso.Shared.DTOs
{
    public class EditarPeliculaDTO
    {
        public Pelicula Pelicula { get; set; }
        public List<Genero> GenerosSeleccionados { get; set; }
        public List<Genero> GenerosNoSeleccionados { get; set; }
        public List<Persona> ActoresSeleccionados { get; set; }
    }
}
