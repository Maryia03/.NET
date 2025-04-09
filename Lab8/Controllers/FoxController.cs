using Lab8.Data;
using Lab8.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers
{
    [Route("api/fox")]
    [ApiController]
    public class FoxController : ControllerBase
    {
        private IFoxesRepository foxesRepository;
        public FoxController(IFoxesRepository _foxesRepository) 
        { 
            foxesRepository = _foxesRepository;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Fox fox)
        {
            foxesRepository.Add(fox);
            return CreatedAtAction(nameof(Get), new { id = fox.Id }, fox);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var foxes = foxesRepository.GetAll();
            foxes = foxes.OrderByDescending(x => x.Loves).ThenBy(x => x.Hates);
            return Ok(foxes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var fox = foxesRepository.Get(id);
            if(fox == null)
                return NotFound();
            else
                return Ok(fox);
        }

        [HttpPut("love/{id}")]
        public IActionResult Love(int id)
        {
            var fox = foxesRepository.AddLove(id);
            if (fox == null)
                return NotFound();
            return Ok(fox);
        }

        [HttpPut("hate/{id}")]
        public IActionResult Hate(int id)
        {
            var fox = foxesRepository.AddHate(id);
            if (fox == null)
                return NotFound();
            return Ok(fox);
        }
    }
}
