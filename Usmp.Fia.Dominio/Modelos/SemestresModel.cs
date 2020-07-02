using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usmp.Fia.Data.Contratos;
using Usmp.Fia.Data.Entidades;
using Usmp.Fia.Data.Repositorios;
using Usmp.Fia.Dominio.ObjetosValor;

namespace Usmp.Fia.Dominio.Modelos
{
    public class SemestresModel
    {
        [Key]
        public int idsemestre { get; set; }
        [Required]
        public string semestre { get; set; }
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

        public EntityStates states;
        public IRepositorioSemestres repositorioDataModel;

        public SemestresModel()
        {
            repositorioDataModel = new RepositorioSemestres();
        }

        public int SaveChanges()
        {
            Semestres entity = new Semestres
            {
                estado = estado,
                user_crea = user_crea,
                fecha_crea = fecha_crea,
                fecha_modif = fecha_modif,
                idsemestre = idsemestre,
                semestre  = semestre,
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

        public List<SemestresModel> getall()
        {
            var tabla = repositorioDataModel.getall();
            List<SemestresModel> lista = new List<SemestresModel>();

            foreach (Semestres item in tabla)
            {
                lista.Add(new SemestresModel
                {
                    estado = item.estado,
                    user_crea = item.user_crea,
                    fecha_crea = item.fecha_crea,
                    fecha_modif = item.fecha_modif,
                    idsemestre = item.idsemestre,
                    semestre = item.semestre,
                    user_modif = item.user_modif
                });
            }
            return lista;

        }

        public SemestresModel getID(int id)
        {
            var tabla = repositorioDataModel.getall().Where(c => c.idsemestre == id);
            SemestresModel model = new SemestresModel();
            foreach (Semestres item in tabla)
            {
                model = new SemestresModel
                {
                    estado = item.estado,
                    user_crea = item.user_crea,
                    fecha_crea = item.fecha_crea,
                    fecha_modif = item.fecha_modif,
                    idsemestre = item.idsemestre,
                    semestre = item.semestre,
                    user_modif = item.user_modif
                };
            }
            return model;

        }


    }
}
