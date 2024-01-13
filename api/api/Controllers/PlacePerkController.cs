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
    public class PlacePerkController : ControllerBase
    {
        private readonly IPlacePerkService _service;
        private readonly IMapper _mapper;

        public PlacePerkController(IMapper mapper, IPlacePerkService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        public IActionResult Add([FromBody] PlacePerkRequest request)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                PlacePerk placePerk = _mapper.Map<PlacePerk>(request);
                _service.Add(placePerk);
                return StatusCode(201, "PlacePerk Created successfuly.");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");

                return StatusCode(500, "An internal error occurred while processing the request.");
            }
        }

        [HttpGet]
        public IActionResult Get()
            {
            var lstPlacePerk = _service.FindAll();
            if(lstPlacePerk.Count() == 0)
            {
                return NotFound("No PlacePerk data was found in the list.");
            }
            var response = _mapper.Map<List<PlacePerkResponse>>(lstPlacePerk).ToList();
            return Ok(response);
        }

        [HttpGet("/ByPlaceId/{id}")]
        public IActionResult GetByPlace(int id)
        {
            PlacePerk placePerk = _service.FindByPlace(id);
            if(placePerk == null)
            {
                return NotFound($"PlacePerk with PlaceId {id} not found");
            }
            var response = _mapper.Map<PlacePerkResponse>(placePerk);
            return Ok(response);
        }
    }
}
