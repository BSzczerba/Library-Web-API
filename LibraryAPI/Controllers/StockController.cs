using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/library/{libraryId}/stock")]
    [ApiController]
    [Authorize]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            this._stockService = stockService;
        }
        [HttpPost]
        public ActionResult Post([FromRoute] int libraryId, [FromBody] CreateStockDto dto)
        {
            var NewStockId = _stockService.Create(libraryId, dto);
            return Created($"api/library/{libraryId}/stock/{NewStockId}", null);
        }
        [HttpGet("{stockId}")]
        public ActionResult<StockDto> Get([FromRoute] int libraryId, [FromRoute] int stockId)
        {
            StockDto dish = _stockService.GetById(libraryId, stockId);
            return Ok(dish);
        }
        [HttpGet]
        public ActionResult<List<StockDto>> GetAll([FromRoute] int libraryId)
        {
            var result = _stockService.GetAll(libraryId);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult DeleteAll([FromRoute] int libraryId)
        {
            _stockService.DeleteAll(libraryId);
            return NoContent();
        }
        [HttpDelete("{stockId}")]
        public ActionResult Delete([FromRoute] int libraryId, [FromRoute] int stockId)
        {
            _stockService.DeleteById(libraryId, stockId);
            return NoContent();
        }
    }
}
