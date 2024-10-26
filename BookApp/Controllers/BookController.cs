using Application.Sevices;
using AutoMapper;
using DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookservice;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookservice = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CreatBookDto>>> GetAll()
        {
            var ListOfBooks = await _bookservice.GetAllBooksAsync();

            return Ok(ListOfBooks.Entity);
        
        }
        [HttpPost]
        public async Task<ActionResult<CreatBookDto>> Create([FromBody] CreatBookDto creatBookDto)
        {
            var ListOfBooks = await _bookservice.GetAllBooksAsync();
            var CheckBook = ListOfBooks.Entity.FirstOrDefault(b=>b.Title==creatBookDto.Title);
            if (CheckBook != null)
            {
                return BadRequest(ListOfBooks.ErrorMessage);
            }
            else
            {
           var BookCreated =   await _bookservice.CreatBookAsync(creatBookDto);
            return Ok(BookCreated.Entity);
            }
        }
        [HttpPut]
        public async Task<ActionResult<CreatBookDto>> Update(CreatBookDto creatBookDto)
        {
            var updatedBook = await _bookservice.UpdateBookAsync(creatBookDto);
            if (updatedBook == null)
            {
                return NotFound("Book not found");
            }
            return Ok(updatedBook);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CreatBookDto>> GetOneById(int id)
        {
            var BookById = await _bookservice.GetOneBookByIdAsync(id);
            if (BookById == null)
            {
                return NotFound("Book not found");
            }
            return Ok(BookById);
        }

        [HttpDelete]
        public async Task<ActionResult<CreatBookDto>> Delete(int id)
        {
            var DeletedBookById = await _bookservice.DeleteBookAsync(id);
            if (DeletedBookById == null)
            {
                return NotFound("Book not found");
            }
            return Ok(DeletedBookById);
        }
    }
}