using basel.Dto;
using basel.Dto.PostDtos;
using basel.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace basel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepo _repo;
        public AuthorsController(IAuthorRepo repo)
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
            var Author = _repo.Get(id);
            if (Author == null)
            {
                return NotFound();
            }
            return Ok(Author);
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
        public IActionResult Post(Author_Dto_Only Author_Dto)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(Author_Dto);
                return Created();
            }
            else
            {
                return BadRequest();
            }


        }
        [HttpPost("All")]
        public IActionResult PostAll(Author_Dto Author_Dto)
        {
            if (ModelState.IsValid)
            {
                _repo.AddAll(Author_Dto);
                return Created();
            }
            else
            {
                return BadRequest();
            }


        }
        [HttpPut]
        public IActionResult Put(Author_Dto_Only Author_Dto, int id)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(Author_Dto, id);
                return Accepted();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("All")]
        public IActionResult PutAll(Author_Dto Author_Dto, int id)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateAll(Author_Dto, id);
                return Accepted();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
