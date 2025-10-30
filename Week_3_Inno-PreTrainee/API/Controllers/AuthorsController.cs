using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using Week_3_Inno_PreTrainee.Application.Dto.AuthorDto;
using Week_3_Inno_PreTrainee.Application.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Web.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorsController : ControllerBase
    {
        private readonly IServiceAuthor _service;
        private readonly IValidator<AuthorForCreationDto> _putAuthorCreationValidator;
        private readonly IValidator<AuthorForUpdateDto> _putAuthorUpdateValidator;

        public AuthorsController(IServiceAuthor service,
            IValidator<AuthorForCreationDto> putAuthorCreationValidator,
            IValidator<AuthorForUpdateDto> putAuthorUpdateValidator
            )
        {
            _service = service;
            _putAuthorCreationValidator = putAuthorCreationValidator;
            _putAuthorUpdateValidator = putAuthorUpdateValidator;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<Author>>> GetAll()
        {
            var authors =  await _service.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("{id:int}")]
        public async Task <ActionResult<Author>> GetById(int id)
        {
            var author = await _service.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task <ActionResult<AuthorForCreationDto>> Create([FromBody] AuthorForCreationDto authorDto)
        {
            var result = _putAuthorCreationValidator.Validate(authorDto);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }
            var author = new Author
            {
                Name = authorDto.Name,
                DateOfBirth = authorDto.DateOfBirth
            };

            var created = await _service.CreateAuthor(author);
            return Ok(created);
        }

        [HttpPut("{id:int}")]
        public async Task <IActionResult> Update(int id, [FromBody] AuthorForUpdateDto authorDto)
        {
            var result = _putAuthorUpdateValidator.Validate(authorDto);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }
            var author = new Author
            {
                Name = authorDto.Name,
                DateOfBirth = authorDto.DateOfBirth
            };
            await _service.UpdateAuthor(id, author);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task <IActionResult> Delete(int id)
        {
            var author = await _service.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            await _service.DeleteAuthorById(id);
            return NoContent();
        }
        [HttpGet("search")]
        public async Task <ActionResult<IEnumerable<Author>>>GetsByName(string name)
        {
            var authors = await _service.GetAllAuthorsWithNameAsync(name);
            return Ok(authors);
        }
        [HttpGet("GetWithCount")]
        public async Task <ActionResult<IEnumerable<Author>>>GetsWithCount()
        {
            var authors = await _service.GetAllAuthorsWithBooksAsync();
            var authorsDto = authors.Select(a => new AuthorForReadWithCount(a.Id, a.Name,a.DateOfBirth,a.Books.Count()));
            return Ok(authorsDto);
        }
    }
}
