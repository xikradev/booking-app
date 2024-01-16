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
        public IActionResult Get([FromQuery] int placeId, [FromQuery] int perkId)
        {

            if(placeId > 0 && perkId > 0)
            {
                var placePerk = _service.FindByPlacePerk(placeId, perkId);
                if(placePerk == null)
                {
                    return NotFound($"PlacePerk with PlaceId: {placeId} and PerkId {perkId} not found");
                }
                var placePerkResponse = _mapper.Map<PlacePerkResponse>(placePerk);
                return Ok(placePerkResponse);
            }
            var lstPlacePerk = new List<PlacePerkViewer>();

            if(placeId > 0 && perkId == 0)
            {
                lstPlacePerk = _service.FindByPlace(placeId).ToList();
                if (lstPlacePerk.Count() == 0)
                {
                    return NotFound("No PlacePerk data was found in the list.");
                }
            }
            else if(placeId == 0 && perkId > 0)
            {
                lstPlacePerk = _service.FindByPerk(perkId).ToList();
                if (lstPlacePerk.Count() == 0)
                {
                    return NotFound("No PlacePerk data was found in the list.");
                }
            }else if(placeId == 0 && perkId == 0)
            {
                lstPlacePerk = _service.FindAll().ToList();
                if (lstPlacePerk.Count() == 0)
                {
                    return NotFound("No PlacePerk data was found in the list.");
                }
            }

            var response = _mapper.Map<List<PlacePerkResponse>>(lstPlacePerk);
            return Ok(response);
        }
    }
}
