using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Usmp.Fia.Data.Contratos;
using Usmp.Fia.Data.Entidades;
using Usmp.Fia.Data.Repositorios;
using Usmp.Fia.Dominio.ObjetosValor;

namespace Usmp.Fia.Dominio.Modelos
{
    public class GrupoModel
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

        public EntityStates states;
        public IRepositorioGrupo repositorioDataModel;

        public GrupoModel()
        {
            repositorioDataModel = new RepositorioGrupo();
        }

        public int SaveChanges()
        {
            Grupo entity = new Grupo
            {
               estado = estado,
               user_crea = user_crea,
               descripcion = descripcion,
               fecha_creacion = fecha_creacion,
               fecha_modificacion = fecha_modificacion,
               idasesor = idasesor,
               idgrupo = idgrupo,
               user_modif = user_modif,
               observacion = observacion,
               tema = tema


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

        public List<GrupoModel> getall()
        {
            var tabla = repositorioDataModel.getall();
            List<GrupoModel> lista = new List<GrupoModel>();

            foreach (Grupo item in tabla)
            {
                lista.Add(new GrupoModel
                {
                    estado = item.estado,
                    user_crea = item.user_crea,
                    descripcion = item.descripcion,
                    fecha_creacion = item.fecha_creacion,
                    fecha_modificacion = item.fecha_modificacion,
                    idasesor = item.idasesor,
                    idgrupo = item.idgrupo,
                    user_modif = item.user_modif,
                    observacion = item.observacion,
                    tema = item.tema
                });
            }
            return lista;

        }

        public GrupoModel getID(int id)
        {
            var tabla = repositorioDataModel.getall().Where(c => c.idgrupo == id);
            GrupoModel model = new GrupoModel();
            foreach (Grupo item in tabla)
            {
                model = new GrupoModel
                {
                    estado = item.estado,
                    user_crea = item.user_crea,
                    descripcion = item.descripcion,
                    fecha_creacion = item.fecha_creacion,
                    fecha_modificacion = item.fecha_modificacion,
                    idasesor = item.idasesor,
                    idgrupo = item.idgrupo,
                    user_modif = item.user_modif,
                    observacion = item.observacion,
                    tema = item.tema

                };
            }
            return model;

        }

    }
}
