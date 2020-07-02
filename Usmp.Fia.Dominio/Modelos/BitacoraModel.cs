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
    public class BitacoraModel
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

        public EntityStates states;
        public IRepositorioBitacora repositorioDataModel;

        public BitacoraModel() 
        {
            repositorioDataModel = new RepositorioBitacora();
        }

        public int SaveChanges()
        {
            Bitacora entity = new Bitacora
            {
                fecha_crea = fecha_crea,
                fecha_entrega = fecha_entrega,
                fecha_modif = fecha_modif,
                idasesor = idasesor,
                idbitacora = idbitacora,
                idgrupo = idgrupo,
                idsemestre = idsemestre,
                observacion = observacion,
                tema = tema,
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

        public List<BitacoraModel> getall()
        {
            var tabla = repositorioDataModel.getall();
            List<BitacoraModel> lista = new List<BitacoraModel>();

            foreach (Bitacora item in tabla)
            {
                lista.Add(new BitacoraModel
                {
                    fecha_crea = item.fecha_crea,
                    fecha_entrega = item.fecha_entrega,
                    fecha_modif = item.fecha_modif,
                    idasesor = item.idasesor,
                    idbitacora = item.idbitacora,
                    idgrupo = item.idgrupo,
                    idsemestre = item.idsemestre,
                    observacion = item.observacion,
                    tema = item.tema,
                    user_crea = item.user_crea,
                    user_modif = item.user_modif

                });
            }
            return lista;

        }

        public BitacoraModel getID(int id)
        {
            var tabla = repositorioDataModel.getall().Where(c => c.idbitacora == id);
            BitacoraModel model = new BitacoraModel();
            foreach (Bitacora item in tabla)
            {
                model = new BitacoraModel
                {
                    fecha_crea = item.fecha_crea,
                    fecha_entrega = item.fecha_entrega,
                    fecha_modif = item.fecha_modif,
                    idasesor = item.idasesor,
                    idbitacora = item.idbitacora,
                    idgrupo = item.idgrupo,
                    idsemestre = item.idsemestre,
                    observacion = item.observacion,
                    tema = item.tema,
                    user_crea = item.user_crea,
                    user_modif = item.user_modif

                };
            }
            return model;

        }

    }
}
