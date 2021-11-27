using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCurso.Shared.Entidades.Somec
{
    public class Valor
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }
        public ICollection<Problema> Problemas { get; set; }
        public ICollection<Documento> Documentos { get; set; }
        public ICollection<Prueba> Pruebas { get; set; }
    }
}
