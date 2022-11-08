using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RecicloPortal.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; } = null!;
        [BsonElement("Email")]

        public string Email { get; set; } = null!; 
        [BsonElement("CpfCnpj")]

        public string CpfCnpj { get; set; } = null!;
    }
}
