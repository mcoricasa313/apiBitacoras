using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usmp.Fia.NetCoreWebAplication.AppBitacoras.Entidades
{
    [Table("IntegrantesPorGrupos")]
    public class IntegrantesPorGrupo
    {
        [Key]
        public int IdIntegrantesPorGrupos { get; set; }
        [Required]
        public int idestudiante { get; set; }
        [Required]
        public int idgrupo { get; set; }
        [Required]
        public DateTime fecha_creacion { get; set; }
        [Required]
        public DateTime fecha_modificacion { get; set; }
        [Required]
        public string user_crea { get; set; }
        [Required]
        public string user_modif { get; set; }
        [Required]
        public int estado { get; set; }

     

    }
}
