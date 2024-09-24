using System;
using Filmkeeper.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Filmkeeper.Controllers
{
    [ApiController]
    [Route("genres")]
    public class GenreController:ControllerBase
    {
        private IGenreServices _GenreServices;
        public GenreController(IGenreServices genreServices)
        {
            this._GenreServices = genreServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._GenreServices.Get());
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(this._GenreServices.Get(id));
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            this._GenreServices.Delete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody]Genres genre)
        {
            this._GenreServices.Update(genre);
            return Ok();
        }
        [HttpPost]
        public IActionResult Create([FromBody]Genres genre)
        {
            this._GenreServices.Create(genre);
            return Ok();
        }
    }
}

