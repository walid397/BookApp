using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IBookReposaitory
    {
        public Task<Book> CreatAsync(Book book);
        public Task<IQueryable<Book>> GetAllAsync();
        public ValueTask<Book> GetOneByIdAsync(int id);
        public Task<Book> UpdateAsync(Book book);
        public Task<Book> DeleteAsync(int id);
        //public Task<List<Book>> SearchAsync(string name);
        public Task<int> SaveChangesAsync();
    }
}
