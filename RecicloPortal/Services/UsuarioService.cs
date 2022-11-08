using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RecicloPortal.Models;

namespace RecicloPortal.Services
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> recicloCollection;

        public UsuarioService(
            IOptions<RecicloDatabaseSettings> recicloDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                recicloDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                recicloDatabaseSettings.Value.DatabaseName);

            recicloCollection = mongoDatabase.GetCollection<Usuario>(
                "Usuario");
        }

        public async Task<List<Usuario>> GetAsync() =>
            await recicloCollection.Find(_ => true).ToListAsync();

        public async Task<Usuario?> GetAsync(string id) =>
            await recicloCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Usuario newUser) =>
            await recicloCollection.InsertOneAsync(newUser);

        public async Task UpdateAsync(string id, Usuario updateUser) =>
            await recicloCollection.ReplaceOneAsync(x => x.Id == id, updateUser);

        public async Task RemoveAsync(string id) =>
            await recicloCollection.DeleteOneAsync(x => x.Id == id);
    }
}
