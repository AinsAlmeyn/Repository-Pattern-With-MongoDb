using CrudSample.Core.IRepositories;
using CrudSample.Core.IServices;

namespace CrudSample.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

    }
}
