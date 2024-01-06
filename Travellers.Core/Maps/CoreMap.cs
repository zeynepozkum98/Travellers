using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Core.Maps
{
    public class CoreMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class, IEntity, new()
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            
        }
    }
}
