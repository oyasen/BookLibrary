using basel.Dto.PostDtos;
using basel.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace basel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepo _repo;
        public GenresController(IGenreRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.Get());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Genre = _repo.Get(id);
            if (Genre == null)
            {
                return NotFound();
            }
            return Ok(Genre);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public IActionResult Post(Genre_Dto_Only Genre_Dto)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(Genre_Dto);
                return Created();
            }
            else
            {
                return BadRequest();
            }


        }
        [HttpPost("All")]
        public IActionResult PostAll(Genre_Dto Genre_Dto)
        {
            if (ModelState.IsValid)
            {
                _repo.AddAll(Genre_Dto);
                return Created();
            }
            else
            {
                return BadRequest();
            }


        }
        [HttpPut]
        public IActionResult Put(Genre_Dto_Only Genre_Dto, int id)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(Genre_Dto, id);
                return Accepted();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("All")]
        public IActionResult PutAll(Genre_Dto Genre_Dto, int id)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateAll(Genre_Dto, id);
                return Accepted();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
