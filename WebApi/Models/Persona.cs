using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace WebApi.Models

{
    public class Persona
    {
        [BsonId]
        [JsonPropertyName("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _Id { get; set; } = null;
        [BsonElement("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; } = 100;
        [BsonElement("nombre")]
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = "Name";
        [BsonElement("apellido")]
        [JsonPropertyName("apellido")]
        public string Apellido { get; set; } = "Second name";
        [BsonElement("edad")]
        [JsonPropertyName("edad")]
        public int Edad { get; set; } = 101;
        [BsonElement("deporte")]
        [JsonPropertyName("deporte")]
        public string DepFab { get; set; } = "Deporte";
        [BsonElement("empleos")]
        [JsonPropertyName("empleos")]
        public List<string> Empleo { get; set; } = new List<string>();
        
    }
}
