using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCurso.Shared.Entidades.Somec
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NumeroIdentificacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string AntecedentesPersonales { get; set; }
        public string AlergiasMedicamentosas { get; set; }
        public string HistoriaClinica { get; set; }
        public string Observaciones { get; set; }
        public ICollection<Seguimiento> Seguimientos { get; set; }
    }
}
