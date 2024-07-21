using RB.TBC.FinalProjectAPI.Data;

namespace RB.TBC.FinalProjectAPI.Repositories
{
    public abstract class BaseRepository
    {
        protected virtual TbcDbContext Context { get; set; }

        protected BaseRepository()
        {
            Context = new TbcDbContext();
        }
    }
}
