using Microsoft.EntityFrameworkCore;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartWork.Data.Repositories
{
    public class EFCoreRepository<TEntity> : IEntityRepository<TEntity>
           where TEntity : Entity
    {
        protected readonly ApplicationContext context;
        protected readonly DbSet<TEntity> entities;

        public EFCoreRepository(ApplicationContext context)
        {
            this.context = context;
            this.entities = this.context.Set<TEntity>();
        }

        public virtual Task AddAsync(TEntity entity)
        {
            return this.entities.AddAsync(entity).AsTask();
        }

        public virtual Task AddAsync(IEnumerable<TEntity> entities)
        {
            return this.entities.AddRangeAsync(entities);
        }

        public virtual Task<TEntity> FindAsync(int id)
        {
            return this.entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return this.entities.FirstOrDefaultAsync(expression);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await this.entities.Where(expression).ToListAsync();
        }

        public virtual Task RemoveAsync(TEntity entities)
        {
            this.entities.Remove(entities);
            return Task.CompletedTask;
        }

        public virtual Task RemoveAsync(IEnumerable<TEntity> entities)
        {
            this.entities.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            this.entities.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(IEnumerable<TEntity> entities)
        {
            this.entities.UpdateRange(entities);
            return Task.CompletedTask;
        }

        public virtual Task SaveChangesAsync()
        {            
            return this.context.SaveChangesAsync();
        }
    }
}
