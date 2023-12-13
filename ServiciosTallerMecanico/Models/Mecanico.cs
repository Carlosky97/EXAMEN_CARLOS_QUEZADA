using System.ComponentModel.DataAnnotations;

namespace ServiciosTallerMecanico.Models
{
    public class Mecanico
    {
        [Key]
        public int idMecanico { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        public int Edad { get; set; }
        [StringLength(100)]
        public string Domicilio { get; set; } = string.Empty;
        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;
        [StringLength(100)]
        public string Especialidad { get; set; } = string.Empty;
        
        public int SueldoBase { get; set; }
        public int GratTitulo { get; set; }
        public int SueldoTotal { get; set; }
    }
}
