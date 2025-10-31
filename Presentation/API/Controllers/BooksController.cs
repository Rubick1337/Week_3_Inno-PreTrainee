using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Week_3_Inno_PreTrainee.Application.Dto.BookDto;
using Week_3_Inno_PreTrainee.Application.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Presentation.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceBook _service;
        private readonly IValidator<BookForCreationDto> _putBookCreationValidator;
        private readonly IValidator<BookUpdateDto> _putBookUpdateValidator;

        public BooksController(IServiceBook service,
            IValidator<BookForCreationDto> putBookCreationValidator,
            IValidator<BookUpdateDto> putBookrUpdateValidator
            )
        {
            _service = service;
            _putBookCreationValidator = putBookCreationValidator;
            _putBookUpdateValidator = putBookrUpdateValidator;
        }

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
            if (book == null)
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
            try
            {
                var created = await _service.CreateBook(book);
                return Ok(created);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }

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
            try
            {
                await _service.UpdateBook(id, book);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _service.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            await _service.DeleteBookById(id);
            return NoContent();
        }
        [HttpGet("search")]
        public async Task<ActionResult<Book>> GetsByTitle(string title)
        {
            var books = await _service.GetAllBooksWithTitleAsync(title);
            return Ok(books);
        }
        [HttpGet("filter")]
        public async Task<ActionResult<Book>> GetsByFilterYear(int year)
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
