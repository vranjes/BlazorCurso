using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCurso.Shared.Entidades.Presupuesto
{
    public class Recurrente
    {
        public int Id { get; set; }
        public int PeridicidadId { get; set; }
        public Valor Periodicidad { get; set; }
        public int Dia { get; set; }
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        public int SubcategoriaConceptoId { get; set; }
        public Registro SubcategoriaConcepto { get; set; }
        public int EstadoId { get; set; }
    }
}
