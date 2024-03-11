using CA.RoadReady.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Infrastructure.Repositories
{
    internal abstract class Repository<T>
        where T : Entity
    {
        protected readonly ApplicationDbContext _DbContext;

        protected Repository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }


        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _DbContext.Set<T>()
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public void Add(T entity)
        {
            _DbContext.Add(entity);
        }



    }
}
