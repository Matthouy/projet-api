using APIprojet.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIprojet.Services
{
    public class MenuService
    {
        // Collection de tous les users stockés en BDD
        private readonly IMongoCollection<Menu> _menuCollection;


        /// <summary>   
        /// Constructeur pour le CRUD de requette sur la collection USERS
        /// </summary>
        /// <param name="FastFoodDatabaseSettings">Informations de connexion à la BDD</param>
        public MenuService(IOptions<FastFoodDataBaseSettings> FastFoodDatabaseSettings)
        {
            MongoClient mongoClient = new MongoClient(FastFoodDatabaseSettings.Value.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(FastFoodDatabaseSettings.Value.DatabaseName);
            _menuCollection = mongoDatabase.GetCollection<Menu>(FastFoodDatabaseSettings.Value.MenuCollectionName);
        }

        public async Task<List<Menu>> GetAsync() =>
        await _menuCollection.Find(_ => true).ToListAsync();

        public async Task<Menu?> GetAsync(string id) =>
            await _menuCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Menu newMenu) =>
            await _menuCollection.InsertOneAsync(newMenu);

        public async Task UpdateAsync(string id, Menu updatedBook) =>
            await _menuCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _menuCollection.DeleteOneAsync(x => x.Id == id);
    }
}
