using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Week_3_Inno_PreTrainee.Application.Dto.BookDto;
using Week_3_Inno_PreTrainee.Application.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Web.Controllers
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
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var books = _service.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public ActionResult<Book> GetById(int id)
        {
            var book = _service.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<BookForCreationDto> Create([FromBody] BookForCreationDto bookDto)
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
            var created = _service.CreateBook(book);
            return Ok(created);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] BookUpdateDto bookDto)
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
            _service.UpdateBook(id, book);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var book = _service.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            _service.DeleteBookById(id);
            return NoContent();
        }
    }
}
