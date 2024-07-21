using RB.TBC.FinalProject.Domain.Data;

namespace RB.TBC.FinalProject.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected virtual TbcDbContext Context { get; set; }

        protected BaseRepository(TbcDbContext Context)
        {
            this.Context = Context;
        }
    }
}
