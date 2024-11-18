using basel.Dto.PostDtos;
using basel.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace basel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo _repo;
        public BooksController(IBookRepo repo)
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
            var Book = _repo.Get(id);
            if (Book == null)
            {
                return NotFound();
            }
            return Ok(Book);
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
        public IActionResult Post(Book_Dto Book_Dto)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(Book_Dto);
                return Created();
            }
            else
            {
                return BadRequest();
            }


        }
        [HttpPost("All")]
        public IActionResult PostAll(Book_Dto Book_Dto)
        {
            if (ModelState.IsValid)
            {
                _repo.AddAll(Book_Dto);
                return Created();
            }
            else
            {
                return BadRequest();
            }


        }
        [HttpPut]
        public IActionResult Put(Book_Dto Book_Dto, int id)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(Book_Dto, id);
                return Accepted();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("All")]
        public IActionResult PutAll(Book_Dto Book_Dto, int id)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateAll(Book_Dto, id);
                return Accepted();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
