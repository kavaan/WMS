using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataAccess.MSSQL.Context;
using WMS.DataAccess.Repositories;
using WMS.Domain;

namespace WMS.DataAccess.MSSQL.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(WmsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
