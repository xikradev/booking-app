using api.Domain.Dto.Request;
using api.Domain.Dto.Response;
using api.Domain.Interfaces;
using api.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PerkController : ControllerBase
    {
        private readonly IPerkService _service;
        private readonly IMapper _mapper;

        public PerkController(IPerkService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody] PerkRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Perk perk = _mapper.Map<Perk>(request);
                _service.Add(perk);

                return CreatedAtAction("GetById", new {id = perk.Id}, perk);
            }catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
                return StatusCode(500, "An internal error occurred while processing the request.");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lstPerk = _service.FindAll();
            if(lstPerk.Count()  == 0)
            {
                return NotFound("No Perks data was found in the list.");
            }
            var response = _mapper.Map<List<PerkResponse>>(lstPerk).ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            Perk perk = _service.Find(id);
            if(perk == null)
            {
                return NotFound($"Perk with Id {id} not found");
            }
            var response = _mapper.Map<PerkResponse>(perk);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] PerkRequest request, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var perk = _service.Find(id);
                    if(perk == null)
                    {
                        return NotFound($"Perk with Id {id} not found");
                    }

                    _mapper.Map(request, perk);
                    _service.Update(perk);
                    return Ok("Perk updated successfully.");
                }
            }catch(Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
                return StatusCode(500, "An internal error occurred while processing the request.");
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            Perk perk = (_service.Find(id));
            if(perk == null)
            {
                return NotFound($"Perk with Id {id} not found");
            }
            _service.Delete(perk);
            return NoContent();
        }
    }
}
