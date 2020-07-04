using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usmp.Fia.NetCoreWebAplication.AppBitacoras.Entidades;

namespace Usmp.Fia.NetCoreWebAplication.AppBitacoras.Data
{
    public class BitacorasContexto: DbContext
    {
       


        public BitacorasContexto(DbContextOptions<BitacorasContexto> options)
            : base(options)
        {
        }


        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
        public DbSet<ActividadesPorGrupo> ActividadesPorGrupo { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Docentes> Docentes { get; set; }
        public DbSet<IntegrantesPorGrupo> IntegrantesPorGrupo { get; set; }
        public DbSet<Semestres> Semestres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IntegrantesPorGrupo>()
                .HasKey(c => new { c.idestudiante, c.idgrupo });
        }
    }
}
