using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SysMyPets.EntidadesDeNegocio
{
    public class Mascota 
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Sexo { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Edad { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Raza { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? SenialesParticulares  { get; set;}


        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Especie { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Propietario { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public Usuario? Usuario { get; set; }









    }
}