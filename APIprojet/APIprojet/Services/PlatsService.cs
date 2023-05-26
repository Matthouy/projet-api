using APIprojet.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIprojet.Services
{
    public class PlatsService
    {
        // Collection de tous les users stockés en BDD
        private readonly IMongoCollection<Plats> _platsCollection;


        /// <summary>   
        /// Constructeur pour le CRUD de requette sur la collection USERS
        /// </summary>
        /// <param name="FastFoodDatabaseSettings">Informations de connexion à la BDD</param>
        public PlatsService(IOptions<FastFoodDataBaseSettings> FastFoodDatabaseSettings)
        {
            MongoClient mongoClient = new MongoClient(FastFoodDatabaseSettings.Value.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(FastFoodDatabaseSettings.Value.DatabaseName);
            _platsCollection = mongoDatabase.GetCollection<Plats>(FastFoodDatabaseSettings.Value.PlatsCollectionName);
        }

        public async Task<List<Plats>> GetAsync() =>
        await _platsCollection.Find(_ => true).ToListAsync();

        public async Task<Plats?> GetAsync(string id) =>
            await _platsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Plats newPlat) =>
            await _platsCollection.InsertOneAsync(newPlat);

        public async Task UpdateAsync(string id, Plats updatedBook) =>
            await _platsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _platsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
