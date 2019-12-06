using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain;

namespace WMS.DataAccess.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> Get(Guid id);
        Task Remove(Guid id);
        TEntity Update(TEntity entity);
    }
}
