using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WMS.DataAccess.MSSQL.Context
{
    public class WmsDbContextFactory : IDbContextFactory<WmsDbContext>
    {

        public WmsDbContext Create()
        {
            return new WmsDbContext("Data Source=.;Initial Catalog=TestWmsDb;" +
                                     "Integrated Security=True;MultipleActiveResultSets=True");
        }
    }
}
