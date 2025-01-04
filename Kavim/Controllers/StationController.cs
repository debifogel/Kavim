using Kavim.Core.classes;
using Kavim.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kavim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationService _context;
        public StationController(IStationService context)
        {
            _context = context;
        }

        // GET: api/<StationController>
        [HttpGet]
        public IEnumerable<Station> Get()
        {
            return _context.GetAll();
        }

        // GET api/<StationController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            Station s = _context.GetById(id);
            if (s is null)
            {
                return NotFound();
            }
            return Ok(s);
        }

        // POST api/<StationController>
        [HttpPost]
        public IActionResult Post([FromBody] NameAndCity value)
        {
            _context.Post(value);
            return Ok();
        }

        // PUT api/<StationController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Station value)
        {
           bool result= _context.UpDate(id, value);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<StationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _context.Delete(id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }


    }
}
