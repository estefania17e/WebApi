using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Models

{
    public class Persona
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; }
        [BsonElement("id")]
        public int Id { get; set; } = 100;
        [BsonElement("nombre")]
        public string Nombre { get; set; } = "Name";
        [BsonElement("apellido")]
        public string Apellido { get; set; } = "Sname";
        [BsonElement("edad")]
        public int Edad { get; set; } = 101;
        [BsonElement("deporte")]
        public string DepFab { get; set; } = "Deporte";
        [BsonElement("empleos")]
        public List<string> Empleo { get; set; } = new List<string>();
        
    }
}
