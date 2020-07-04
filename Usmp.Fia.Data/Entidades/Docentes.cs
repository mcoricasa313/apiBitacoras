using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usmp.Fia.Data.Entidades
{
    [Table("Docentes")]
    public class Docentes
    {
        [Key]
        public int iddocente { get; set; }
        [Required]
        public string nombrecompleto { get; set; }
        [Required]
        public string usuario { get; set; }
        [Required]
        public string clave { get; set; }
        [Required]
        public int estado { get; set; }
        [Required]
        public DateTime fecha_crea { get; set; }
        [Required]
        public DateTime fecha_modif { get; set; }
        [Required]
        public string user_crea { get; set; }
        [Required]
        public string user_modif { get; set; }
        public string token { get; set; }

    }
}
