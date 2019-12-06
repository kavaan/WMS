using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataAccess.MSSQL.Context;
using WMS.DataAccess.Repositories;
using WMS.Domain;

namespace WMS.DataAccess.MSSQL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly WmsDbContext dbContext;
        protected readonly DbSet<TEntity> set;
        public BaseRepository(WmsDbContext dbContext)
        {
            this.dbContext = dbContext;
            set = dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            return set.Add(entity);
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await set.ToListAsync();
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await set.FindAsync(id);
        }

        public async Task Remove(Guid id)
        {
            var entity = await Get(id);
            set.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
