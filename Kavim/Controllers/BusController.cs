using AutoMapper;
using Kavim.Core.classes;
using Kavim.Core.Dto;
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
        private readonly IMapper _mapper;
        public BusController(IBusService context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            Bus s = _context.GetById(id);
            if (s is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BusDto>(s));
        }

        [HttpGet]
        public ActionResult Get([FromQuery] string? name, [FromQuery] string? destination, [FromQuery] string? source, [FromQuery] CompanyName? company)
        {

            var b = _context.GetAll(name, company, destination, source);
            var result = _mapper.Map<IEnumerable<BusDto>>(b);       
            return Ok(result);
            
        }
       

        // POST api/<BusController>
        [HttpPost]
        public IActionResult Post([FromBody] Busfrombody bus)
        {
            
             _context.PostAsync(bus);
            return Ok();
        }

        // PUT api/<BusController>/5
        [HttpPut("/update{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Busfrombody bus)
        {
           bool result=await _context.UpDateAsync(id, bus);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPut("/addStation{id}")]
        public async Task<IActionResult> addStation(int id, [FromBody] StationPut station)
        {
            StationAndi temp = new StationAndi();
            temp.Status = station.Status;
            temp.InOrder = station.InOrder;
            temp.Stop = new Station() { Id = station.Stop };
            bool result= await _context.AddStationAsync(temp,id);
            if (result) { return Ok();}
            
           return NotFound();
        }

        // DELETE api/<BusController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _context.DeleteAsync(id);
            return Ok();
        }
    }
}
