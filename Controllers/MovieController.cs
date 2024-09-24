using System;
using Filmkeeper.Entities;
using Microsoft.AspNetCore.Mvc;
using Filmkeeper.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Firebase.Storage;

namespace Filmkeeper.Controllers
{
    [Route("movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieServices _movieServices;

        public MovieController(IMovieServices movieServices)
        {
            this._movieServices = movieServices;
        }

        [Route("movies")]
        public IActionResult GetAll([FromQuery] int year)
        {
            var result = _movieServices.GetAllByYear(year);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Movies movie)
        {
            try
            {
                _movieServices.Create(movie);
                return Ok(movie);
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_movieServices.Get(id));
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _movieServices.Delete(id);
                return Ok();
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Movies movie)
        {
            try
            {
                _movieServices.Update(movie);
                return Ok();
            }
            catch (InvalidArguementException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");
            var task = await new FirebaseStorage("restapidemo-d68c7.appspot.com")
                    .Child(Guid.NewGuid().ToString() + ".jpg")
                    .PutAsync(file.OpenReadStream());
            return Ok(task);
        }


    }
}
 