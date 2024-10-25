using Application.Contracts;
using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;

namespace Infrastructure
{
    public class Reposaitores : IBookReposaitory
    {
        private readonly BookContext _context;
        private readonly DbSet<Book> _dbset;
        public Reposaitores(BookContext context)
        {

            _context = context;
            _dbset = _context.Set<Book>();
        }
        public async Task<Book> CreatAsync(Book book)
        {
            await _dbset.AddAsync(book);

          await SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteAsync(int id)
        {
            var bookDeleted = await _dbset.FirstOrDefaultAsync(b => b.Id == id);
            if (bookDeleted != null)
            {
                _dbset.Remove(bookDeleted);
                await SaveChangesAsync();
                return bookDeleted;
            }
            return null;

        }
        public Task<IQueryable<Book>> GetAllAsync()
        {
            var ReturnedBooks = _dbset.Select(b => b);
            return Task.FromResult(ReturnedBooks);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<Book?> UpdateAsync(Book book)
        {
            var oldBook = await _dbset.FirstOrDefaultAsync(b => b.Id == book.Id);
            if (oldBook == null)
            {
                return null;
            }
            oldBook.Title = book.Title;
            oldBook.Description = book.Description;
            oldBook.Author = book.Author;
            oldBook.Price = book.Price;
            oldBook.PublishedDate = book.PublishedDate;
            oldBook.Genre = book.Genre;

            await _context.SaveChangesAsync();
            return oldBook;
        }
        public async ValueTask<Book?> GetOneByIdAsync(int id)
        {
          var BookById = await _dbset.FindAsync(id);
            if (BookById==null)
            { 
                return null;
            }
            return BookById;
        }
    }
}