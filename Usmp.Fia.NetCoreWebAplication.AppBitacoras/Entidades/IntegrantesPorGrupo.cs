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
        [Key, Column(Order = 0)]
        public int idestudiante { get; set; }
        [Key, Column(Order = 1)]
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
