using CrudSample.Core.Entities;
using CrudSample.Core.IRepositories;
using Microsoft.Extensions.Options;

namespace CrudSample.DataAccess.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(IOptions<MongoSettings.MongoSettings> settings) : base(settings)
        {
        }
    }
}
