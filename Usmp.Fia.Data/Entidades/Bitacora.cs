using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usmp.Fia.Data.Entidades
{
    [Table("Bitacoras")]
    public class Bitacora
    {
        [Key]
        public int idbitacora { get; set; }
        [Required]
        public int idsemestre { get; set; }
        [Required]
        public DateTime fecha_entrega { get; set; }
        [Required]
        public int idgrupo { get; set; }
        [Required]
        public int idasesor { get; set; }
        [Required]
        public string tema { get; set; }
        public string observacion { get; set; }
        [Required]
        public DateTime fecha_crea { get; set; }
        [Required]
        public DateTime fecha_modif { get; set; }
        [Required]
        public string user_crea { get; set; }
        [Required]
        public string user_modif { get; set; }


    }
}
