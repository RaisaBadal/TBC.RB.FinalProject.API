using Microsoft.EntityFrameworkCore;
using RB.TBC.FinalProject.Domain.Data;
using RB.TBC.FinalProject.Domain.Entitites;
using RB.TBC.FinalProject.Domain.Interface;

namespace RB.TBC.FinalProject.Domain.Repositories
{
    public class BookRepository :BaseRepository<Book>, IBookRepository
    {
        public BookRepository(TbcDbContext Context) : base(Context)
        {
        }

        #region AddAsync
        public async Task<string> AddAsync(Book entity)
        {
            if (!await Dbset.AnyAsync(io => io.imageLink == entity.imageLink && io.description == entity.description))
            {
                await Dbset.AddAsync(entity);
                await Context.SaveChangesAsync();
                return Dbset.Max(o => o.BookId);
            }
            throw new ArgumentNullException("such Book already exist in DB!");
        }
        #endregion

        #region GetAllAsync
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await Dbset.ToListAsync();
        }
        #endregion

        #region GetByIdAsync
        public async Task<Book> GetByIdAsync(string id)
        {
            var res = await Dbset.FindAsync(id);
            if (res is not null)
            {
                return res;
            }
            throw new ArgumentNullException(" no entity found on this ID");
        }
        #endregion

        #region RemoveAsync
        public async Task<bool> RemoveAsync(Book entity)
        {
            Dbset.Remove(entity);
            await Context.SaveChangesAsync();
            return true;
        }
        #endregion


        #region UpdateAsync
        public async Task<bool> UpdateAsync(string id, Book entity)
        {
            var res = await Dbset.FindAsync(id);
            if (res is not null)
            {
                res.title = entity.title;
                res.description = entity.description;
                res.authors = entity.authors;
                res.imageLink = entity.imageLink;
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
    }
}
