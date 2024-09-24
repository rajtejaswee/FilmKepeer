using System;
using Filmkeeper.Entities;
using Microsoft.AspNetCore.Mvc;
using Filmkeeper.Exceptions;

namespace Filmkeeper.Controllers
{
    [ApiController]
    [Route("reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewServices _reviewServices;

        public ReviewController(IReviewServices reviewServices)
        {
            this._reviewServices = reviewServices;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            { 
           
                return Ok(this._reviewServices.Get(id));
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Review review)
        {
            try
            {
                this._reviewServices.Create(review);
                return Ok();
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Review review)
        {
            try
            {
                this._reviewServices.Update(review);
                return Ok();
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
                this._reviewServices.Delete(id);
                return Ok();
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
