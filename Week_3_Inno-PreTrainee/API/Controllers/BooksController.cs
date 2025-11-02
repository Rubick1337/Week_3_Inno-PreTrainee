using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Week_3_Inno_PreTrainee.Application.Dto.BookDto;
using Week_3_Inno_PreTrainee.Application.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController(
            IServiceBook service,
            IValidator<BookForCreationDto> putBookCreationValidator,
            IValidator<BookUpdateDto> putBookrUpdateValidator
    ) : ControllerBase
    {
        private readonly IServiceBook _service = service;
        private readonly IValidator<BookForCreationDto> _putBookCreationValidator = putBookCreationValidator;
        private readonly IValidator<BookUpdateDto> _putBookUpdateValidator = putBookrUpdateValidator;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var books = await _service.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book = await _service.GetBookById(id);
            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookForCreationDto>> Create([FromBody] BookForCreationDto bookDto)
        {
            var result = _putBookCreationValidator.Validate(bookDto);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }
            var book = new Book
            {
                Title = bookDto.Title,
                PublishedYear = bookDto.PublishedYear,
                AuthorId = bookDto.AuthorId,
            };

             var created = await _service.CreateBook(book);
             return Ok(created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookUpdateDto bookDto)
        {
            var result = _putBookUpdateValidator.Validate(bookDto);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }
            var book = new Book
            {
                Title = bookDto.Title,
                PublishedYear = bookDto.PublishedYear,
                AuthorId = bookDto.AuthorId,
            };
            if(book is null )
            {
                return NotFound();
            }
                await _service.UpdateBook(id, book);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _service.GetBookById(id);
            if (book is null)
            {
                return NotFound();
            }
            await _service.DeleteBookById(id);
            return NoContent();
        }
        [HttpGet("by-title")]
        public async Task<ActionResult<Book>> GetsByTitle([FromQuery]string title)
        {
            var books = await _service.GetAllBooksWithTitleAsync(title);
            return Ok(books);
        }
        [HttpGet("by-year")]
        public async Task<ActionResult<Book>> GetsByFilterYear([FromQuery]int year)
        {
            if (year < 0)
            {
                return BadRequest("Год не может быть отрицательным");
            }
            var books = await _service.GetAllBooksFilterByYearAsync(year);
            return Ok(books);
        }
    }
}
