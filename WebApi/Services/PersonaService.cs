using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApi.Models;
using MongoDB.Driver;
using WebApi.Services;

namespace WebApi.Services
{
    public class PersonaService
    {
        private IMongoCollection<Persona> _persona;
        public PersonaService(IPersonaSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _persona = database.GetCollection<Persona>(settings.Collection);
            /*
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Collection);
            _persona = database.GetCollection<Persona>(settings.Collection);*/

        }
      
        public List<Persona> Get()
        {
            //true = a.id =1 | 
            return _persona.Find(d => true).ToList();
        }



    }
}
