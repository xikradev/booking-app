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
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _service;
        private readonly IMapper _mapper;

        public PhotoController(IPhotoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody] PhotoRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Photo photo = _mapper.Map<Photo>(request);
                _service.Add(photo);

                return CreatedAtAction(nameof(GetById) ,new {Id = photo.Id} , photo);

            }catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");

                return StatusCode(500, "An internal error occurred while processing the request.");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lstPhotos = _service.FindAll();
            if(lstPhotos.Count() == 0)
            {
                return NotFound("No Photo data was found in the list.");
            }
            var response = _mapper.Map<List<PhotoResponse>>(lstPhotos).ToList();
            return Ok(response);
    }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Photo photo = _service.Find(id);
            if(photo == null)
            {
                return NotFound($"Photo with Id {id} not found");
            }
            var response = _mapper.Map<PhotoResponse>(photo);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] PhotoRequest request, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var photo = _service.Find(id);
                    if(photo == null)
                    {
                        return NotFound($"Photo with Id {id} not found");
                    }
                    _mapper.Map(request, photo);
                    _service.Update(photo);
                    return Ok("Photo updated successfully.");
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
            var photo = _service.Find(id);
            if (photo == null)
            {
                return NotFound($"Photo with Id {id} not found");
            }

            _service.Delete(photo);
            return NoContent();
        }
    }
}
