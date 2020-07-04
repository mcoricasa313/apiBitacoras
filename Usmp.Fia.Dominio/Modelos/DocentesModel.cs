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
    public class DocentesModel
    {
        [Key]
        public int iddocente { get; set; }
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
        public IRepositorioDocentes repositorioDataModel;

        public DocentesModel()
        {
            repositorioDataModel = new RepositorioDocentes();
        }


        public int SaveChanges()
        {
            Docentes entity = new Docentes
            {
               estado = estado,
               fecha_crea = fecha_crea,
               fecha_modif =fecha_modif,
               user_modif = user_modif,
               user_crea = user_crea,
               iddocente = iddocente,
               nombrecompleto = nombrecompleto,
               clave= clave,
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

        public List<DocentesModel> getall()
        {
            var tabla = repositorioDataModel.getall();
            List<DocentesModel> lista = new List<DocentesModel>();

            foreach (Docentes item in tabla)
            {
                lista.Add(new DocentesModel
                {
                    estado = item.estado,
                    fecha_crea = item.fecha_crea,
                    fecha_modif = item.fecha_modif,
                    user_modif = item.user_modif,
                    user_crea = item.user_crea,
                    iddocente = item.iddocente,
                    nombrecompleto = item.nombrecompleto,
                    usuario = item.usuario,
                    clave = item.clave
                });
            }
            return lista;

        }

        public DocentesModel getID(int id)
        {
            var tabla = repositorioDataModel.getall().Where(c => c.iddocente == id);
            DocentesModel model = new DocentesModel();
            foreach (Docentes item in tabla)
            {
                model = new DocentesModel
                {
                    estado = item.estado,
                    fecha_crea = item.fecha_crea,
                    fecha_modif = item.fecha_modif,
                    user_modif = item.user_modif,
                    user_crea = item.user_crea,
                    iddocente = item.iddocente,
                    nombrecompleto = item.nombrecompleto,
                    usuario = item.usuario,
                    clave = item.clave

                };
            }
            return model;

        }

        public DocentesModel getPorUsuariClave(string usuario,string clave)
        {
            var tabla = repositorioDataModel.getall().Where(c => c.usuario.ToUpper().Equals(usuario.ToUpper()) && c.clave.ToUpper().Equals(clave.ToUpper()));
            DocentesModel model = new DocentesModel();
            foreach (Docentes item in tabla)
            {
                model = new DocentesModel
                {
                    estado = item.estado,
                    fecha_crea = item.fecha_crea,
                    fecha_modif = item.fecha_modif,
                    user_modif = item.user_modif,
                    user_crea = item.user_crea,
                    iddocente = item.iddocente,
                    nombrecompleto = item.nombrecompleto,
                    usuario = item.usuario,
                    clave = item.clave

                };
            }
            return model;

        }

    }
}
