using Application.Contracts;
using AutoMapper;
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
    public class BookService:IBookService
    {
        private readonly IBookReposaitory _bookReposaitory;
        private readonly IMapper _mapper;
        public BookService(IBookReposaitory bookReposaitory, IMapper mapper)
        {
            _bookReposaitory = bookReposaitory;
            _mapper = mapper;
        }
        public async Task<ResultView<CreatBookDto>> CreatBookAsync(CreatBookDto book)
        {
            var ExistBook = (await _bookReposaitory.GetAllAsync()).Any(b => b.Id == book.Id);//IQuarable
            if (ExistBook)
            {
                ResultView<CreatBookDto> FailedResult = new ResultView<CreatBookDto>
                {
                    Entity = null,
                    IsSuccesed = false,
                    ErrorMessage = "Name Already Exist"
                };
                return FailedResult;
            }
            else
            {
                var bookmap = _mapper.Map<Book>(book);
                var CreatedBook = await _bookReposaitory.CreatAsync(bookmap);
                var bookmapDto = _mapper.Map<CreatBookDto>(CreatedBook);

                ResultView<CreatBookDto> SuccessedResult = new ResultView<CreatBookDto>
                {
                    Entity = bookmapDto,
                    IsSuccesed = true,
                    ErrorMessage = "Successed"
                };
                return SuccessedResult;
            }

        }
        public async Task<ResultView<CreatBookDto>> DeleteBookAsync(int id)
        {
            var ListOfBooks = (await _bookReposaitory.GetAllAsync());
            var ExistDeletedBook = ListOfBooks.Any(b=> b.Id == id);
            if (!ExistDeletedBook)
            {
                ResultView<CreatBookDto> FailedResult = new ResultView<CreatBookDto>
                {
                    Entity = null,
                    IsSuccesed = false,
                    ErrorMessage = "Book Doesn't Exist"
                };
                return FailedResult;
            }
            else
            {

            var book = await _bookReposaitory.DeleteAsync(id);
            var DeletedBookMapped = _mapper.Map<CreatBookDto>(book);

                ResultView<CreatBookDto> SuccessResult = new ResultView<CreatBookDto>
                {
                    Entity = DeletedBookMapped,
                    IsSuccesed = true,
                    ErrorMessage = "Book Deleted Successfully"
                };
                return SuccessResult;

            }


        }
        public async Task<ResultView<List<CreatBookDto>>> GetAllBooksAsync()
        {
            var ListOfBooks = (await _bookReposaitory.GetAllAsync()).ToList();
            var ListOfBooksMapping = _mapper.Map<List<CreatBookDto>>(ListOfBooks);
            return new ResultView<List<CreatBookDto>>() { Entity = ListOfBooksMapping ,ErrorMessage="Name Already Exist"};
        }
        public async Task<ResultView<CreatBookDto>> GetOneBookByIdAsync(int id)
        {
            var book = (await _bookReposaitory.GetOneByIdAsync(id));
            var BookDTO = _mapper.Map<CreatBookDto>(book);
            if (book == null)
            {
                ResultView<CreatBookDto> FailedResult = new ResultView<CreatBookDto>
                {
                    Entity = null,
                    IsSuccesed = false,
                    ErrorMessage = "There is no Book With This Id"
                };
                return FailedResult;
            }
            else
            {
                ResultView<CreatBookDto> SuccessResult = new ResultView<CreatBookDto>
                {
                    Entity = BookDTO,
                    IsSuccesed = true,
                    ErrorMessage = "Success"
                };
                return SuccessResult;
            }

        }
        public async Task<CreatBookDto?> UpdateBookAsync(CreatBookDto book)
        {
            var existingBook = await _bookReposaitory.GetOneByIdAsync(book.Id);
            if (existingBook == null)
            {
                return null;
            }
            var updatedBookEntity = _mapper.Map<Book>(book);
            var mappedUpdatedBook = await _bookReposaitory.UpdateAsync(updatedBookEntity);
            await _bookReposaitory.SaveChangesAsync();
            return _mapper.Map<CreatBookDto>(mappedUpdatedBook);
        }

    }
}