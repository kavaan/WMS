using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataAccess.Repositories;

namespace WMS.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        Task Commit();
    }
}
