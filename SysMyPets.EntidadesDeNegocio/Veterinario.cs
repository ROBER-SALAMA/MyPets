using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysMyPets.EntidadesDeNegocio
{
    public class Veterinario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [StringLength(15, ErrorMessage = "Maximo 15 caracteres")]
        public string? Nombre { get; set; }


        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [StringLength(15, ErrorMessage = "Maximo 15 caracteres")]
        public string? Apellido { get; set; }


        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string? Dui { get; set; }

        [NotMapped]
         

        public int Top_Aux { get; set; }

        public List<Servicio>? Servicios { get; set; }   
    }
}
