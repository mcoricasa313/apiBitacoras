using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Usmp.Fia.Data.Entidades;

namespace Usmp.Fia.Data.DbContext
{
    public class BitacorasContexto: System.Data.Entity.DbContext
    {
        public BitacorasContexto(): base("DB_A630DE_bitacorasEntities")
        {

        }
     


        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
        public DbSet<ActividadesPorGrupo> ActividadesPorGrupo { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Docentes> Docentes { get; set; }
        public DbSet<IntegrantesPorGrupo> IntegrantesPorGrupo { get; set; }         
        public DbSet<Semestres> Semestres { get; set; }


    }
}
