using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CrudSample.DataAccess
{
    public class CrudSampleDbContext
    {
        private readonly IMongoDatabase _database;
        public CrudSampleDbContext(IOptions<MongoSettings.MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
        }
        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}
