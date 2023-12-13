using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApiConsumoTaller.Models
{
    // Clase que representa la entidad "Mecanico" en el modelo del taller mecánico
    public class Mecanico
    {
        // Identificador único del mecánico
        [Key]
        [DisplayName("Id")]
        public int idMecanico { get; set; }
        // Nombre del mecánico, con restricción de longitud máxima de 50 caracteres
        [StringLength(50)]
        [DisplayName("Nombre")]
        public string nombre { get; set; } = string.Empty;
        // Edad del mecánico
        [DisplayName("Edad")]
        public int edad { get; set; }
        // Domicilio del mecánico, con restricción de longitud máxima de 100 caracteres
        [StringLength(100)]
        [DisplayName("Domicilio")]
        public string domicilio { get; set; } = string.Empty;
        // Título del mecánico, con restricción de longitud máxima de 100 caracteres
        [StringLength(100)]
        [DisplayName("Titulo")]
        
        public string titulo { get; set; } = string.Empty;
        // Especialidad del mecánico, con restricción de longitud máxima de 100 caracteres
        [StringLength(100)]
        [DisplayName("Especialidad")]
        public string especialidad { get; set; } = string.Empty;
        // Sueldo base del mecánico
        [DisplayName("Sueldo Base")]
        public int sueldoBase { get; set; }
        // Gratificación por título del mecánico
        [DisplayName("Grat Titulo")]
        public int gratTitulo { get; set; }
        // Sueldo total del mecánico
        [DisplayName("Sueldo Total")]
        public int sueldoTotal { get; set; }
    }

}
