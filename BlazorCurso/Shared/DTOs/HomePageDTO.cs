using BlazorCurso.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCurso.Shared.DTOs
{
    public class HomePageDTO
    {
        public List<Pelicula> PeliculasEnCartera { get; set; }
        public List<Pelicula> ProximosEstrenos { get; set; }
    }
}
