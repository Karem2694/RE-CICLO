using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RecicloPortal.Models
{
    public class Agendamento
    {
        public DateTime Data { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string CpfCnpj { get; set; }

    }
}