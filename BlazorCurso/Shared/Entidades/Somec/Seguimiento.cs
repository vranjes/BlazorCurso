using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCurso.Shared.Entidades.Somec
{
    public class Seguimiento
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
        public ICollection<Prueba> Pruebas { get; set; }
        public ICollection<Problema> Problemas { get; set; }
    }
}
