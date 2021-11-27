using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCurso.Shared.Entidades.Somec
{
    public class Problema
    {
        public int Id { get; set; }
        public int SeguimientoId { get; set; }
        public Seguimiento Seguimiento { get; set; }
        public int TipoProblemaId { get; set; }
        public Valor TipoProblema { get; set; }
    }
}
