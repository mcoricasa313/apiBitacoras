using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usmp.Fia.Data.Contratos
{
    public interface IRepositorioGenerico<Entity> where Entity:class
    {
        IEnumerable<Entity> getall();
        int Add(Entity entity);
        int Edit(Entity entity);
        int Delete(Entity entity);

    }
}
