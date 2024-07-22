using Microsoft.EntityFrameworkCore;
using RB.TBC.FinalProject.Domain.Data;

namespace RB.TBC.FinalProject.Domain.Repositories
{
    public abstract class BaseRepository<T>where T:class
    {

        protected virtual DbSet<T> Dbset { get; set; }
        protected virtual TbcDbContext Context { get; set; }

        protected BaseRepository(TbcDbContext Context)
        {
            this.Context = Context;
            Dbset = Context.Set<T>();
        }
    }
}
