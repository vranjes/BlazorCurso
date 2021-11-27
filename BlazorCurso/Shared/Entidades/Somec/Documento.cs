using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCurso.Shared.Entidades.Somec
{
    public class Documento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ruta { get; set; }
        public int TipoDocumentoId { get; set; }
        public Valor TipoDocumento { get; set; }
        public int PruebaId { get; set; }
        public Prueba Prueba { get; set; }
    }
}
