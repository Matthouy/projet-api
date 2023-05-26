using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace APIprojet.Models
{
    public class Plats
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string NomPlat { get; set; } = null!;

        public Decimal Prix { get; set; }

        public string Categorie { get; set; } = null!;
    }
}
