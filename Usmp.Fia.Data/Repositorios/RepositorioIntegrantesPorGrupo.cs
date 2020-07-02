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
    public class RepositorioIntegrantesPorGrupo : IRepositorioIntegrantesPorGrupo
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int Add(IntegrantesPorGrupo entity)
        {
            try
            {
                using (var db = new BitacorasContexto())
                {
                    db.IntegrantesPorGrupo.Add(entity);
                    return db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                log.Error(DateTime.Now + " " + e);
                return 0;
            }
        }

        public int Delete(IntegrantesPorGrupo entity)
        {
            try
            {
                using (var db = new BitacorasContexto())
                {
                    db.IntegrantesPorGrupo.Remove(entity);
                    return db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                log.Error(DateTime.Now + " " + e);
                return 0;
            }
        }

        public int Edit(IntegrantesPorGrupo entity)
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

        public IEnumerable<IntegrantesPorGrupo> getall()
        {
            try
            {
                using (var db = new BitacorasContexto())
                {
                    return db.IntegrantesPorGrupo.ToList();
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
