using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApi.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace WebApi.Services
{
    public class PersonaService
    {

        private IMongoCollection<Persona> _persona;

        public PersonaService(IOptions<PersonaDatabaseSettings> settings)
        {
            var cliente = new MongoClient(settings.Value.Server);
            var database = cliente.GetDatabase(settings.Value.Database);
            _persona = database.GetCollection<Persona>(settings.Value.Collection);
            /*
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Collection);
            _persona = database.GetCollection<Persona>(settings.Collection);*/

        }

        public async Task<List<Persona>> GetAsync() => await _persona.Find(_ => true).ToListAsync();
        public async Task<Persona?> GetAsync(int id) => await _persona.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Persona?> GetAsync(string id) => await _persona.Find(x => x._Id == id).FirstOrDefaultAsync();
       // public async Task GetCountAsync() => await _persona.CountAsync(_ => true);
        public async Task CreateAsync(Persona New) => await _persona.InsertOneAsync(New);
        public async Task UpdateAsync(string id ,Persona NewPerson) => await _persona.ReplaceOneAsync(x => x._Id == id, NewPerson);
        public async Task RemoveAsync(string id) => await _persona.DeleteOneAsync(x => x._Id == id);

        public List<Persona> Get()
        {
            //true = a.id =1 | 
            return _persona.Find(d => true).ToList();
        }



    }
}
