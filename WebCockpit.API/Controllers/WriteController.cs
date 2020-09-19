using Microsoft.AspNetCore.Mvc;
using WebCockpit.API.Responses;
using WebCockpit.Application.Interfaces;

namespace WebCockpit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriteController : ControllerBase
    {
        private readonly IWriteService _writeService;

        public WriteController(IWriteService writeService)
        {
            _writeService = writeService;
        }

        [HttpGet]
        public IActionResult Write([FromQuery(Name = "event")] string eventName, [FromQuery(Name = "data")] uint data)
        {
            eventName = eventName.ToUpper();
            _writeService.Write(eventName, data);

            var response = new WriteEventResponse(eventName, data);

            return Ok(response);
        }
    }
}
