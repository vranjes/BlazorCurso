using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCurso.Shared.Entidades.Somec
{
    public class Prueba
    {
        public int Id { get; set; }
        public int TipoPruebaId { get; set; }
        public Valor TipoPrueba { get; set; }
        public DateTime Fecha { get; set; }
        public string Resultado { get; set; }
        public string Observaciones { get; set; }
        public int SeguimientoId { get; set; }
        public Seguimiento Seguimiento { get; set; }
        public ICollection<Documento> Documentos { get; set; }
    }
}
