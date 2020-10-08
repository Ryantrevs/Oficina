using Microsoft.EntityFrameworkCore;
using OficinaTcc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaTcc.Models
{
    public class ContextRepository<T> where T : class
    {
        protected readonly OficinaContext context;
        protected readonly DbSet<T> DbSet;

        public ContextRepository(OficinaContext context)
        {
            this.context = context;
            DbSet = context.Set<T>();
        }
    }
}
