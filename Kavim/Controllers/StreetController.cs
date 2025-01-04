using AutoMapper;
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

        private readonly IMapper _mapper;
        public StreetController(IStreetService context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<StreetController>
        [HttpGet]
        public ActionResult Get([FromQuery] string? name, [FromQuery] string? city)
        {
            var s = _context.GetAll(name, city);
            var result=_mapper.Map<IEnumerable< StreetDto>>(s);
            return Ok(result);
        }

        // GET api/<StreetController>/5

        //צריך לחשוב איך לעשות את זה 
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var s= _mapper.Map<StreetDto>( _context.GetById(id));
            if(s == null)
                return NotFound();
            return Ok(s);

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
        public IActionResult update(int id, [FromBody] NameAndCity street)
        {
            bool result = _context.UpDate(id,street );

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
