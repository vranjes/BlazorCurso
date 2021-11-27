using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCurso.Shared.Entidades.Presupuesto
{
    public class Movimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        public int RegsitroId { get; set; }
        public Registro Registro { get; set; }
    }
}
