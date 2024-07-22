using AutoMapper;
using Microsoft.Extensions.Logging;
using RB.TBC.FinalProject.Application.Interface;
using RB.TBC.FinalProject.Application.Models;
using RB.TBC.FinalProject.Domain.Entitites;
using RB.TBC.FinalProject.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.TBC.FinalProject.Application.Services
{
    public class BookService : AbstractService<BookService>, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IMapper mapper, ILogger<BookService> logger, IBookRepository bookRepository) : base(mapper, logger)
        {
            _bookRepository = bookRepository;
        }

        #region AddAsync
        public async Task<string> AddAsync(BookModel entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            var mapped = mapper.Map<Book>(entity);
            if (mapped is not null)
            {
                mapped.BookId = Guid.NewGuid().ToString();
                return await _bookRepository.AddAsync(mapped);
            }
            throw new ArgumentNullException("Internal server error");
        }
        #endregion

        #region GetAllAsync
        public async Task<IEnumerable<BookModel>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            if (books.Any())
            {
                var mapped = mapper.Map<IEnumerable<BookModel>>(books);
                return mapped;
            }
            throw new ArgumentNullException("No books found");
        }
        #endregion

        #region GetByIdAsync
        public async Task<BookModel> GetByIdAsync(string id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book is not null)
            {
                var mapped = mapper.Map<BookModel>(book);
                return mapped;
            }
            throw new ArgumentNullException("Book not found");
        }
        #endregion

        #region RemoveAsync
        public async Task<bool> RemoveAsync(string id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book is not null)
            {
                return await _bookRepository.RemoveAsync(book);
            }
            throw new ArgumentNullException("Book not found");
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(string id, BookModel entity)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book is not null)
            {
                var mapped = mapper.Map(entity, book);
                return await _bookRepository.UpdateAsync(id, mapped);
            }
            throw new ArgumentNullException("Book not found");
        }
        #endregion
    }
}
