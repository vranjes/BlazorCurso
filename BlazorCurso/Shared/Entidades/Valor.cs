namespace BlazorCurso.Shared.Entidades
{
    public class Valor
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }
    }
}
