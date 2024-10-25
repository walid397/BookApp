using Microsoft.EntityFrameworkCore;
using Models;

namespace Context
{
    public class BookContext:DbContext
    {
      public  DbSet<Book> Books { get; set; }
        public BookContext(DbContextOptions<BookContext> options):base(options) 
        {

        }
        
    }
}
