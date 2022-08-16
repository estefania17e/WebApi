using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService _personaService;

        public PersonaController(PersonaService personsaservice)
        {
            _personaService = personsaservice;
        }
        [HttpGet]
        public async Task<List<Persona>> Get() => await _personaService.GetAsync();
       
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Persona>> Get(string id)
        {
            var person = await _personaService.GetAsync(id);

            if (person is null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            var person = await _personaService.GetAsync(id);

            if (person is null)
            {
                return NotFound();
            }

            return person;
        }


        [HttpPost]
        public async Task<ActionResult<Persona>> Post(Persona newPersona)
        {

            await _personaService.CreateAsync(newPersona);

            return CreatedAtAction(nameof(Get), new { id = newPersona._Id }, newPersona);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<Persona>> Update(string id, Persona NewPerson)
        {

            var person = await _personaService.GetAsync(id);

            if (person is null)
            {
                return NotFound();
            }
            NewPerson._Id = person._Id;

            await _personaService.UpdateAsync(id, person);

            return NoContent();

            return person;
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var person = await _personaService.GetAsync(id);

            if (person is null)
            {
                return NotFound();
            }

            await _personaService.RemoveAsync(id);

            return NoContent();
        }
    }
}    
