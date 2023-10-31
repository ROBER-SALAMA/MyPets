using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysMyPets.EntidadesDeNegocio
{
    public class Detalle
    {
        [Key]
        public int IdDetalle { get; set; }
        [Required(ErrorMessage = "Nombre es bligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public float Precio { get; set; }

        [NotMapped]
        public Servicio? Servicio { get; set; }
    }
}
