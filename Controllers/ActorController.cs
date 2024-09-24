using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmkeeper.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Filmkeeper.Exceptions;

namespace Filmkeeper.Controllers
{
    [ApiController]
    [Route("actors")]
    public class ActorController : ControllerBase
    {
        private IActorService _actorServices;

        public ActorController(IActorService actorService)
        {
            this._actorServices = actorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this._actorServices.Get());
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Actors actor)
        {
            try
            {
                this._actorServices.Create(actor);
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
                return Ok(this._actorServices.Get(id));
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
                this._actorServices.Delete(id);
                return Ok();
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Actors actor)
        {
            try
            {
                this._actorServices.Update(actor);
                return Ok();
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
