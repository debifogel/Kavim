using Kavim.Core.classes;
using Kavim.Core.Services;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kavim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private  readonly IBusService _context;

        public BusController(IBusService context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            Bus s = _context.GetById(id);
            if (s is null)
            {
                return NotFound();
            }
            return Ok(s);
        }

        [HttpGet]
        public IEnumerable<object>? Get([FromQuery] string? name, [FromQuery] string? destination, [FromQuery] string? source, [FromQuery] CompanyName? company)
        {

            return _context.GetAll(name,company,destination,source);
            
        }
       

        // POST api/<BusController>
        [HttpPost]
        public IActionResult Post([FromBody] Busfrombody bus)
        {
            
            _context.Post(bus);
            return Ok();
        }

        // PUT api/<BusController>/5
        [HttpPut("/update{id}")]
        public IActionResult Update(int id, [FromBody] Busfrombody bus)
        {
           bool result= _context.UpDate(id, bus);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPut("/addStation{id}")]
        public IActionResult addStation(int id, [FromBody] StationAndi station)
        {
           bool result= _context.AddStation(station,id);
            if (result) { return Ok();}
            
           return NotFound();
        }

        // DELETE api/<BusController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.Delete(id);
            return Ok();
        }
    }
}
