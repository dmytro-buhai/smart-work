using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SmartWork.Data.Repositories
{
    public class EFCoreUserRepository<TEntity> : IUserRepository<TEntity>
           where TEntity : IdentityUser
    {
        protected readonly ApplicationContext context;
        protected readonly DbSet<TEntity> entities;

        public EFCoreUserRepository(ApplicationContext context)
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

        public virtual Task<TEntity> FindAsync(string id)
        {
            return this.entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return this.entities.FirstOrDefaultAsync(expression);
        }

        public virtual Task<List<TEntity>> GetAsync(PageInfo pageInfo, Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression != null)
            {
                return this.entities.Where(expression).Take(pageInfo.CountItems).ToListAsync();
            }

            return this.entities.Take(pageInfo.CountItems).ToListAsync();
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
