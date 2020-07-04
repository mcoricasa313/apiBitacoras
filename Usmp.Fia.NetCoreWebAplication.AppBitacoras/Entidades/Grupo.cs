using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Usmp.Fia.NetCoreWebAplication.AppBitacoras.Entidades
{
    [Table("Grupos")]
    public class Grupo
    {
        [Key]
        public int idgrupo { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public int idasesor { get; set; }
        [Required]
        public string tema { get; set; }
        public string observacion { get; set; }
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