using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SysMyPets.EntidadesDeNegocio;

namespace SysMyPets.AccesoADatos
{
    public class BDContexto : DbContext
    {

        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Mascota> Mascota { get; set; }
        public DbSet<Cita> Cita{ get; set; }
        public DbSet<Detalle> Detalle { get; set; }
        public DbSet<Servicio> Servicio { get; set; }

        public DbSet<Veterinario>veterinario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"workstation id=BDejemplo1706.mssql.somee.com;packet size=4096;user id=Jacquel17_SQLLogin_1;pwd=uxrexfxlak;data source=BDejemplo1706.mssql.somee.com;persist security info=False;initial catalog=BDejemplo1706");
        }
    }
}
