using DTO_s.ResultView;
using DTO_s;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sevices
{
    public interface IBookService
    {
        public Task<ResultView<CreatBookDto>> CreatBookAsync(CreatBookDto book);
        public Task<ResultView<List<CreatBookDto>>> GetAllBooksAsync();
        public Task<CreatBookDto> UpdateBookAsync(CreatBookDto book);
        public Task<ResultView<CreatBookDto>> DeleteBookAsync(int id);
        public Task<ResultView<CreatBookDto>> GetOneBookByIdAsync(int id);
    }
}
