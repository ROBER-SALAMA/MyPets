using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysMyPets.EntidadesDeNegocio
{
    public class Cita
    {
        [Key]
        public int Id  { get; set; }
        [Required(ErrorMessage = "Fecha es obligatoria")]

        [ForeignKey("Mascota")]
        [Display(Name = "Mascota")]
        public int IdMascota { get; set; }
        public string? Fecha { get; set; }
        public string? Diagnostico { get; set; }
        [Required(ErrorMessage = "Direccion es obligatoria")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage="Campo requerido")]
        public string? Propietario { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string? TipoCita { get; set; }
	
		[NotMapped]
		public int Top_Aux { get; set; }
       
		public virtual Mascota? Mascota { get; set; }

		
	}
}
