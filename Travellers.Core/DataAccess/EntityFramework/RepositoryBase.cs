using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Core.DataAccess.EntityFramework
{
    public class RepositoryBase<T> : IRepository<T> where T : class, IEntity, new()
    {
        public DbContext _context { get; set; }
        public DbSet<T> _set { get; set; }

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _set=_context.Set<T>();
        }
    }
}
