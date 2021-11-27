using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCurso.Shared.Entidades.Somec
{
    public class Consulta
    {
        public int Id { get; set; }
        public string Motivo { get; set; }
        public string Tratamiento { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public int SeguimientoId { get; set; }
        public Seguimiento Seguimiento { get; set; }
    }
}
