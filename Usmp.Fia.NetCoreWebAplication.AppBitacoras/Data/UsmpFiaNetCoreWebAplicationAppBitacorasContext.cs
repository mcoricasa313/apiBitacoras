using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Usmp.Fia.NetCoreWebAplication.AppBitacoras.Data
{
    public class UsmpFiaNetCoreWebAplicationAppBitacorasContext : DbContext
    {
        public UsmpFiaNetCoreWebAplicationAppBitacorasContext (DbContextOptions<UsmpFiaNetCoreWebAplicationAppBitacorasContext> options)
            : base(options)
        {
        }


    }
}
