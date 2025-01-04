using Kavim.Core.classes;
using Kavim.Core.repsitory;
using Kavim.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kavim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StreetController : ControllerBase
    {
        private readonly IStreetService _context;


        public StreetController(IStreetService context)
        {
            _context = context;
        }
        // GET: api/<StreetController>
        [HttpGet]
        public IEnumerable<Street> Get([FromQuery] string? name, [FromQuery] string? city)
        {
            return _context.GetAll(name, city);
        }

        // GET api/<StreetController>/5

        //צריך לחשוב איך לעשות את זה 
        [HttpGet("{id}")]
        public Street Get(int id)
        {

            return _context.GetById(id);


        }

        // POST api/<StreetController>
        [HttpPost]
        public IActionResult Post([FromBody] NameAndCity value)

        {
            _context.Post(value);
            return Ok();
        }

        // PUT api/<StreetController>/5
        [HttpPut("/update/{id}")]
        public IActionResult update(int id, [FromBody] Street street)
        {
            bool result = _context.UpDate(id, street);

            if (result)
            {
               
                return Ok();
            }
            return NotFound();
        }
        [HttpPut("/addStation/{id}")]
        public IActionResult AddStation(int id, [FromBody] Station station)
        {
            bool result = _context.AddStation(station, id);
            if (result)
            {
                
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<StreetController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result=_context.Delete(id);
            if (result)
            {
               
                return Ok();
            }
            return NotFound();
        }
    }
}
