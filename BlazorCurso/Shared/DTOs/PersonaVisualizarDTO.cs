using BlazorCurso.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCurso.Shared.DTOs
{
    public class PersonaVisualizarDTO
    {
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Biografia { get; set; }
        public string Foto { get; set; }
        public List<Pelicula> Peliculas{ get; set; }
    }
}
