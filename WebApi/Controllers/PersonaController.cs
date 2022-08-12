using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        public PersonaService _personaService;

        public PersonaController(PersonaService personsaservice)
        {
            _personaService = personsaservice;
        }
        [HttpGet]
        public ActionResult<List<Persona>> Get()
        {
            return _personaService.Get();
        }
        /*
        [HttpPost(Name = "Persona")]
        [Route("New")]
        public dynamic CreatePersona()
        {
            List<Persona> personas = new List<Persona>
            {
                
                new Persona
                {
                    Id = 3,
                    Nombre = "Mirai",
                    Apellido = "Vargas",
                    Edad = 2,
                    Empleo = {"No empleo"} ,
                    DepFab = ""
                }
            };
            return personas;
        }
        [HttpPost]
        [Route("crearNew")]
        public dynamic Edit()
        {
            List<Persona> personas = new List<Persona>
            {

                new Persona
                {
                    Id = 2,
                    Nombre = "Mirai",
                    Apellido = "Vargas",
                    Edad = 2,
                    Empleo = {"Desarrollador","soporte"},
                    DepFab = ""
                }
            };
            return personas;
        }
        
        [HttpGet]
        [Route("listar")]
        public dynamic ReadPersona()
        {

        }
        [HttpGet]
        [Route("cliente")]
        public dynamic UpdatePersona()
        {

        }
        [HttpGet]
        [Route("cliente")]
        public dynamic DeletePersona()
        {

        }
        */


    }
}
