using System;
using Filmkeeper.Entities;
using Microsoft.AspNetCore.Mvc;
using Filmkeeper.Exceptions;

namespace Filmkeeper.Controllers
{
    [ApiController]
    [Route("producers")]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerServices _producerServices;

        public ProducerController(IProducerServices producerServices)
        {
            this._producerServices = producerServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this._producerServices.Get());
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Producers producer)
        {
            try
            {
                this._producerServices.Create(producer);
                return Ok();
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(this._producerServices.Get(id));
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                this._producerServices.Delete(id);
                return Ok();
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Producers producer)
        {
            try
            {
                this._producerServices.Update(producer);
                return Ok();
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
