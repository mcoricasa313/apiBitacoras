using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usmp.Fia.NetCoreWebAplication.AppBitacoras.Entidades
{
    [Table("Estudiantes")]
    public class Estudiantes
    {
        [Key]
        public int idestudiante { get; set; }
        [Required]
        public string nombrecompleto { get; set; }
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
        [Required]
        public string usuario { get; set; }
        [Required]
        public string clave { get; set; }
        public string token { get; set; }

    }
}
