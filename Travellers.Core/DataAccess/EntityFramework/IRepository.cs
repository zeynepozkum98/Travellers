using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Core.DataAccess.EntityFramework
{
    public interface IRepository<T> where T:class,IEntity,new()
    {
        DbContext _context { get; set; }
        DbSet<T> _set { get; set;}
        Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return _set.Where(x=>x.IsDeleted==false).FirstOrDefaultAsync(expression);
        }

     
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>>expression=null)
        {
            return expression is null ? _set.Where(x => x.IsDeleted == false).ToListAsync() :
            _set.Where(expression).ToListAsync();
        }
        Task<int> AddAsync(T entity)
        {
            _set.Add(entity);
            return _context.SaveChangesAsync();
        }
        Task<int> UpdateAsync(T entity)
        {
            _set.Update(entity);
            return _context.SaveChangesAsync();
        }
        Task<int> DeleteAsync(T entity)
        {
            _set.Remove(entity);
            return _context.SaveChangesAsync();
        }

        Task<int> RemoveUpdate(T entity)
        {
            entity.IsDeleted = true;
            _set.Update(entity);
            return _context.SaveChangesAsync();
        }
    }
}
