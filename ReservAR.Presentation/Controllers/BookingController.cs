using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReservAR.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public BookingController()
        {

        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAll()
        {
            await Task.CompletedTask;
            return Ok("hola mundo");
        }
    }
}
