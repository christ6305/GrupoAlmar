namespace APITareasPendientes.Models
{
    public class TareaModel
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Completada { get; set; }
    }
}
