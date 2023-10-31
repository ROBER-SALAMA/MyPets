using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysMyPets.EntidadesDeNegocio
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Veterinario")]
        [Display(Name ="Veterinario")]
        public int IdVeterinario { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? TipoDeServicio { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Detalle>? Detalle { get; set; }
        
        public virtual Veterinario? Veterinario { get; set; }
    }
}
