using System.ComponentModel.DataAnnotations;

namespace APPTareasPendientes.Models
{
    public class TareaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        public DateTime FechaVencimiento { get; set; }

        public bool Completada { get; set; }
    }

}
