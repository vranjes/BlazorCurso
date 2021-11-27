using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCurso.Shared.Entidades.Presupuesto
{
    public class Registro
    {
        public int SubcategoriaId { get; set; }
        public int ConceptoId { get; set; }

        public Subcategoria Subcategoria { get; set; }
        public Concepto Concepto { get; set; }

        public List<Movimiento> Movimientos { get; set; }
    }
}
