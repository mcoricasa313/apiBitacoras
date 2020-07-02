using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usmp.Fia.Data.Contratos;
using Usmp.Fia.Data.DbContext;
using Usmp.Fia.Data.Entidades;

namespace Usmp.Fia.Data.Repositorios
{
    public class RepositorioGrupo : IRepositorioGrupo
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int Add(Grupo entity)
        {
            try
            {
                using (var db = new BitacorasContexto())
                {
                    db.Grupos.Add(entity);
                    return db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                log.Error(DateTime.Now + " " + e);
                return 0;
            }
        }

        public int Delete(Grupo entity)
        {
            try
            {
                using (var db = new BitacorasContexto())
                {
                    db.Grupos.Remove(entity);
                    return db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                log.Error(DateTime.Now + " " + e);
                return 0;
            }
        }

        public int Edit(Grupo entity)
        {
            try
            {
                using (var db = new BitacorasContexto())
                {
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                log.Error(DateTime.Now + " " + e);
                return 0;
            }
        }

        public IEnumerable<Grupo> getall()
        {
            try
            {
                using (var db = new BitacorasContexto())
                {
                    return db.Grupos.ToList();
                }
            }
            catch (Exception e)
            {
                log.Error(DateTime.Now + " " + e);
                return null;
            }
        }
    }
}
