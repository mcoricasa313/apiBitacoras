using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usmp.Fia.Data.Contratos;
using Usmp.Fia.Data.Entidades;
using Usmp.Fia.Data.Repositorios;
using Usmp.Fia.Dominio.ObjetosValor;

namespace Usmp.Fia.Dominio.Modelos
{
    public class EstudiantesModel
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

        public EntityStates states;
        public IRepositorioEstudiantes repositorioDataModel;

        public EstudiantesModel()
        {
            repositorioDataModel = new RepositorioEstudiantes();
        }

        public int SaveChanges()
        {
            Estudiantes entity = new Estudiantes
            {
                estado = estado,
                fecha_crea = fecha_crea,
                fecha_modif = fecha_modif,
                user_modif = user_modif,
                user_crea = user_crea,
                idestudiante = idestudiante,
                nombrecompleto = nombrecompleto,
                clave = clave,
                usuario = usuario,
                token = token

            };

            int salida = 0;
            switch (states)
            {
                case EntityStates.Add:
                    salida = repositorioDataModel.Add(entity);
                    break;
                case EntityStates.Delete:
                    salida = repositorioDataModel.Delete(entity);
                    break;
                case EntityStates.Update:
                    salida = repositorioDataModel.Edit(entity);
                    break;
                default:
                    break;
            }
            return salida;

        }

        public List<EstudiantesModel> getall()
        {
            var tabla = repositorioDataModel.getall();
            List<EstudiantesModel> lista = new List<EstudiantesModel>();

            foreach (Estudiantes item in tabla)
            {
                lista.Add(new EstudiantesModel
                {
                    estado = item.estado,
                    fecha_crea = item.fecha_crea,
                    fecha_modif = item.fecha_modif,
                    user_modif = item.user_modif,
                    user_crea = item.user_crea,
                    idestudiante = item.idestudiante,
                    nombrecompleto = item.nombrecompleto,
                    usuario = item.usuario,
                    clave = item.clave
                });
            }
            return lista;

        }

        public EstudiantesModel getID(int id)
        {
            var tabla = repositorioDataModel.getall().Where(c => c.idestudiante == id);
            EstudiantesModel model = new EstudiantesModel();
            foreach (Estudiantes item in tabla)
            {
                model = new EstudiantesModel
                {
                    estado = item.estado,
                    fecha_crea = item.fecha_crea,
                    fecha_modif = item.fecha_modif,
                    user_modif = item.user_modif,
                    user_crea = item.user_crea,
                    idestudiante = item.idestudiante,
                    nombrecompleto = item.nombrecompleto,
                         usuario = item.usuario,
                    clave = item.clave
                };
            }
            return model;

        }

        public EstudiantesModel getPorUsuariClave(string usuario, string clave)
        {
            var tabla = repositorioDataModel.getall().Where(c => c.usuario.ToUpper().Equals(usuario.ToUpper()) && c.clave.ToUpper().Equals(clave.ToUpper()));
            EstudiantesModel model = new EstudiantesModel();
            foreach (Estudiantes item in tabla)
            {
                model = new EstudiantesModel
                {
                    estado = item.estado,
                    fecha_crea = item.fecha_crea,
                    fecha_modif = item.fecha_modif,
                    user_modif = item.user_modif,
                    user_crea = item.user_crea,
                    idestudiante = item.idestudiante,
                    nombrecompleto = item.nombrecompleto,
                    usuario = item.usuario,
                    clave = item.clave

                };
            }
            return model;

        }

    }
}
