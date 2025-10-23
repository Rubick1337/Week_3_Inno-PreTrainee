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
        public ActionResult<IEnumerable<Author>> GetAll()
        {
            var authors = _service.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Author> GetById(int id)
        {
            var author = _service.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public ActionResult<AuthorForCreationDto> Create([FromBody] AuthorForCreationDto authorDto)
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

            var created = _service.CreateAuthor(author);
            var createdDto = new AuthorForCreationDto(created.Name, created.DateOfBirth);
            return Ok(createdDto);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] AuthorForUpdateDto authorDto)
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
            _service.UpdateAuthor(id, author);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var author = _service.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            _service.DeleteAuthorById(id);
            return NoContent();
        }
    }
}
