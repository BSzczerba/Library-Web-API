using LibraryAPI.Entities;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/library")]
    [Authorize]
    public class LibraryController:ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            this._libraryService = libraryService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _libraryService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var result = _libraryService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult AddLibrary([FromBody] CreateLibraryDto dto)
        {
            int libraryId = _libraryService.Create(dto);
            return Created($"api/library/{libraryId}", null);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _libraryService.Delete(id);
            return NoContent();
        }
    }
}

