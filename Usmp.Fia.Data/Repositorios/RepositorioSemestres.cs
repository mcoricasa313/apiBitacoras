using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usmp.Fia.Data.Contratos;
using Usmp.Fia.Data.DbContext;
using Usmp.Fia.Data.Entidades;

namespace Usmp.Fia.Data.Repositorios
{
    public class RepositorioSemestres : IRepositorioSemestres
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int Add(Semestres entity)
        {
            //throw new NotImplementedException();
            try
            {
                using (var db = new BitacorasContexto())
                {
                    db.Semestres.Add(entity);
                    return db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                log.Error(DateTime.Now + " " + e);
                return 0;
            }
        }

        public int Delete(Semestres entity)
        {
            try
            {
                using (var db = new BitacorasContexto())
                {
                    db.Semestres.Remove(entity);
                    return db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                log.Error(DateTime.Now + " " + e);
                return 0;
            }
        }

        public int Edit(Semestres entity)
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

        public IEnumerable<Semestres> getall()
        {
            try
            {
                using (var db = new BitacorasContexto())
                {
                    return db.Semestres.ToList();
                }
            }
            catch (Exception e)
            {
                log.Error(DateTime.Now + " " + e);
                return null;
            }
        }

        public Task<List<Semestres>> getallAsync() 
        {
            try
            {
                using (var db = new BitacorasContexto())
                {
                    return db.Semestres.ToListAsync();
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
