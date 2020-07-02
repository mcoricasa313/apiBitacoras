using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usmp.Fia.Data.Contratos;
using Usmp.Fia.Data.Entidades;
using Usmp.Fia.Data.Repositorios;
using Usmp.Fia.Dominio.ObjetosValor;

namespace Usmp.Fia.Dominio.Modelos
{
    public class IntegrantesPorGrupoModel
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
        public EntityStates states;
        public IRepositorioIntegrantesPorGrupo repositorioDataModel;

        public IntegrantesPorGrupoModel()
        {
            repositorioDataModel = new RepositorioIntegrantesPorGrupo();
        }


        public int SaveChanges()
        {
            IntegrantesPorGrupo entity = new IntegrantesPorGrupo
            {
               estado= estado,
               fecha_creacion = fecha_creacion,
               fecha_modificacion = fecha_modificacion,
               idestudiante= idestudiante,
               idgrupo = idgrupo,
               user_crea = user_crea,
               user_modif = user_modif
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

        public List<IntegrantesPorGrupoModel> getall()
        {
            var tabla = repositorioDataModel.getall();
            List<IntegrantesPorGrupoModel> lista = new List<IntegrantesPorGrupoModel>();

            foreach (IntegrantesPorGrupo item in tabla)
            {
                lista.Add(new IntegrantesPorGrupoModel
                {
                    estado = item.estado,
                    fecha_creacion = item.fecha_creacion,
                    fecha_modificacion = item.fecha_modificacion,
                    idestudiante = item.idestudiante,
                    idgrupo = item.idgrupo,
                    user_crea = item.user_crea,
                    user_modif = item.user_modif
                });
            }
            return lista;

        }

        public IntegrantesPorGrupoModel getID(int idgrupo, int idestudiante)
        {
            var tabla = repositorioDataModel.getall().Where(c => c.idgrupo == idgrupo && c.idestudiante== idestudiante);
            IntegrantesPorGrupoModel model = new IntegrantesPorGrupoModel();
            foreach (IntegrantesPorGrupo item in tabla)
            {
                model = new IntegrantesPorGrupoModel
                {
                    estado = item.estado,
                    fecha_creacion = item.fecha_creacion,
                    fecha_modificacion = item.fecha_modificacion,
                    idestudiante = item.idestudiante,
                    idgrupo = item.idgrupo,
                    user_crea = item.user_crea,
                    user_modif = item.user_modif

                };
            }
            return model;

        }


    }
}
