using api.Domain.Dto.Request;
using api.Domain.Dto.Response;
using api.Domain.Interfaces;
using api.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;
        private readonly IMapper _mapper;

        public AddressController(IAddressService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Add([FromBody] AddressRequest request)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Address address = _mapper.Map<Address>(request);
                _service.Add(address);
                
                return CreatedAtAction("GetById", new {id =  address.Id}, address);

            }catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");

                return StatusCode(500, "An internal error occurred while processing the request.");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lstAddress = _service.FindAll();
            if(lstAddress.Count() == 0)
            {
                return NotFound("No Address data was found in the list.");
            }
            var response  = _mapper.Map<List<AddressResponse>>(lstAddress).OrderBy(x => x.Id).ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Address address = _service.Find(id);
            if(address == null)
            {
                return NotFound($"Address with Id {id} not found");
            }
            var response = _mapper.Map<AddressResponse>(address);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] AddressRequest request, int id)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var address = _service.Find(id);
                    if (address == null)
                    {
                        return NotFound($"Address with Id {id} not found.");
                    }

                    _mapper.Map(request, address);
                    _service.Update(address);
                    return Ok("Address updated successfully.");
                }
            }catch(Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
                return StatusCode(500, "An internal error occurred while processing the request.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            Address address = _service.Find(id);
            if( address == null )
            {
                return NotFound($"Address with Id {id} not found");
            }

            _service.Delete(address);

            return NoContent();
        }
    }
}
