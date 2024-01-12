using api.Domain.Dto.Request;
using api.Domain.Dto.Response;
using api.Domain.Interfaces;
using api.Domain.Models;
using api.Domain.Viewer;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _service;
        private readonly IMapper _mapper;

        public PlaceController(IPlaceService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody] PlaceRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Place place = _mapper.Map<Place>(request);
                _service.Add(place);

                return CreatedAtAction(nameof(GetById), new {Id = place.Id}, place);
            }catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");

                return StatusCode(500, "An internal error occurred while processing the request.");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lstPlaces = _service.FindAll();
            if(lstPlaces.Count() == 0)
            {
                return NotFound("No Place data was found in the list.");
            }
            var response = _mapper.Map<List<PlaceResponse>>(lstPlaces).ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            PlaceViewer place = _service.Find(id);
            if(place == null)
            {
                return NotFound($"Place with Id {id} not found");
            }
            var response = _mapper.Map<PlaceResponse>(place);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] PlaceRequest request, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var foundedPlace = _service.Find(id);
                    if(foundedPlace == null)
                    {
                        return NotFound($"Place with Id {id} not found");
                    }
                    var place = _mapper.Map<Place>(foundedPlace);
                    _mapper.Map(request, place);
                    _service.Update(place);
                    return Ok("Place updated successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
                return StatusCode(500, "An internal error occurred while processing the request.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var foundedPlace = _service.Find(id);
            if (foundedPlace == null)
            {
                return NotFound($"Place with Id {id} not found");
            }
            var place = _mapper.Map<Place>(foundedPlace);
            _service.Delete(place);
            return NoContent();
        }
    }
}
