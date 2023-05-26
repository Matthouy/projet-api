using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace APIprojet.Models
{
    public class Menu
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Burger { get; set; } = null!;

        public string Boisson { get; set; } = null!;

        public string Dessert { get; set; } = null!;
    }
}
