using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Usmp.Fia.Data.Contratos;
using Usmp.Fia.Data.Entidades;
using Usmp.Fia.Data.Repositorios;
using Usmp.Fia.Dominio.ObjetosValor;

namespace Usmp.Fia.Dominio.Modelos
{
    public class ActividadesPorGrupoModel
    {
        [Key]
        public int idactividad { get; set; }
        [Required]
        public string actividades { get; set; }
        [Required]
        public int idgrupo { get; set; }
        [Required]
        public DateTime fecha_crea { get; set; }
        [Required]
        public DateTime fecha_modif { get; set; }
        [Required]
        public string user_crea { get; set; }
        [Required]
        public string user_modif { get; set; }
        public EntityStates states;
        public IRepositorioActividadesPorGrupo repositorioactividadesporgrupomodel;
        public ActividadesPorGrupoModel() 
        {
            repositorioactividadesporgrupomodel = new RepositorioActividadesPorGrupo();
        }

        public int SaveChanges() 
        {
            ActividadesPorGrupo entity = new ActividadesPorGrupo { 
                actividades =actividades,
                fecha_crea = fecha_crea,
                fecha_modif = fecha_modif,
                idactividad = idactividad,
                idgrupo = idgrupo,
                user_crea = user_crea,
                user_modif = user_modif
            };
            
            int salida = 0;
            switch (states)
            {
                case EntityStates.Add:
                    salida = repositorioactividadesporgrupomodel.Add(entity);
                    break;
                case EntityStates.Delete:
                    salida = repositorioactividadesporgrupomodel.Delete(entity);
                    break;
                case EntityStates.Update:
                    salida = repositorioactividadesporgrupomodel.Edit(entity);
                    break;
                default:
                    break;
            }
            return salida;

        }

        public List<ActividadesPorGrupoModel> getallActividadesPorGrupo() 
        {
            var tabla = repositorioactividadesporgrupomodel.getall();
            List<ActividadesPorGrupoModel> lista = new List<ActividadesPorGrupoModel>();

            foreach (ActividadesPorGrupo item in tabla)
            {
                lista.Add(new ActividadesPorGrupoModel { 
                    actividades = item.actividades,
                    fecha_crea = item.fecha_crea,
                    fecha_modif = item.fecha_modif,
                    idactividad = item.idactividad,
                    idgrupo = item.idgrupo,
                    user_crea = item.user_crea,
                    user_modif = item.user_modif

                });
            }
            return lista;

        }

        public ActividadesPorGrupoModel getActividadesPorGrupoID(int id) 
        {
            var tabla = repositorioactividadesporgrupomodel.getall().Where(c => c.idactividad == id);
            ActividadesPorGrupoModel model = new ActividadesPorGrupoModel();
            foreach (ActividadesPorGrupo item in tabla)
            {
                model = new ActividadesPorGrupoModel
                {
                    actividades = item.actividades,
                    fecha_crea = item.fecha_crea,
                    fecha_modif = item.fecha_modif,
                    idactividad = item.idactividad,
                    idgrupo = item.idgrupo,
                    user_crea = item.user_crea,
                    user_modif = item.user_modif

                };
            }
            return model;

        }

    }
}
