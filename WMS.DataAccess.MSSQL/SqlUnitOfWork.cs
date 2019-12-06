using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataAccess.MSSQL.Context;
using WMS.DataAccess.MSSQL.Repositories;
using WMS.DataAccess.Repositories;

namespace WMS.DataAccess.MSSQL
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly WmsDbContext dbContext;
        private IOrderRepository orderRepository;
        private IProductRepository productRepository;

        public SqlUnitOfWork(WmsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }

        public IOrderRepository OrderRepository => orderRepository ??
                                                   (orderRepository = new OrderRepository(dbContext));

        public IProductRepository ProductRepository => productRepository ??
                                                       (productRepository = new ProductRepository(dbContext));

        public async Task Commit()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
