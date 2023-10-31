using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysMyPets.EntidadesDeNegocio
{
    public class Receta
    {
        [Key]
        
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdReceta { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        public string? Nombre { get; set; }
        
        public Cita? Citas { get; set; } 
    }
}
