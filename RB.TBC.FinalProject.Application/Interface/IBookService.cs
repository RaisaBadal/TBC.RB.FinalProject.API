using RB.TBC.FinalProject.Application.Models;

namespace RB.TBC.FinalProject.Application.Interface
{
    public interface IBookService
    {
        Task<string> AddAsync(BookModel entity);
        Task<bool> RemoveAsync(string id);
        Task<bool> UpdateAsync(string id, BookModel entity);
        Task<IEnumerable<BookModel>> GetAllAsync();
        Task<BookModel> GetByIdAsync(string id);
    }
}
