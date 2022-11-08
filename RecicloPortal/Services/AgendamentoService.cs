using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RecicloPortal.Models;

namespace RecicloPortal.Services
{
    public class AgendamentoService
    {
        private readonly IMongoCollection<Agendamento> recicloCollection;

        public AgendamentoService(
            IOptions<RecicloDatabaseSettings> recicloDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                recicloDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                recicloDatabaseSettings.Value.DatabaseName);

            recicloCollection = mongoDatabase.GetCollection<Agendamento>(
                "Agendamento");
        }

        public async Task<List<Agendamento>> GetAsync() =>
            await recicloCollection.Find(_ => true).ToListAsync();

        public async Task<Agendamento?> GetAsync(string id) =>
            await recicloCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Agendamento newUser) =>
            await recicloCollection.InsertOneAsync(newUser);

        public async Task UpdateAsync(string id, Agendamento updateUser) =>
            await recicloCollection.ReplaceOneAsync(x => x.Id == id, updateUser);

        public async Task RemoveAsync(string id) =>
            await recicloCollection.DeleteOneAsync(x => x.Id == id);
    }
}
