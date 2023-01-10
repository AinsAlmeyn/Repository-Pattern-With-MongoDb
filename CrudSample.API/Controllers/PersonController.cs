using CrudSample.Core.Entities;
using CrudSample.Core.IRepositories;
using CrudSample.Core.IServices;
using CrudSample.Core.ResponseArticle;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CrudSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonService personService, IPersonRepository personRepository)
        {
            _personService = personService;
            _personRepository = personRepository;
        }

        [HttpPost("Add_Person")]
        public IActionResult CreatePerson(Person person)
        {
            var result = _personRepository.InsertOne(person);
            return Ok(result);
        }

        [HttpGet("Get_Person_By_Id/{id}")]
        public IActionResult GetById(string id)
        {
            var result = _personRepository.GetById(id);
            return Ok(result);
        }

        [HttpGet("Get_All_Person")]
        public IActionResult GetAll()
        {
            var result = _personRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("Delete_One_Person/{id}")]
        public IActionResult DeletePerson(string id)
        {
            _personRepository.DeleteOne(x => x.Id == ObjectId.Parse(id));
            return Ok();
        }

        [HttpGet("Get_All_Person_By_Filter/{age}")]
        public IActionResult GetPersonWithFilter(int age)
        {
            var result = _personRepository.FilterBy(x => x.Age >= age);
            return Ok(result);
        }

        [HttpPost("Update_One_Person")]
        public IActionResult UpdatePerson(UpdatePerson person)
        {
            person.Person.Id = ObjectId.Parse(person.Id);
            var result = _personRepository.UpdateOne(person.Person, person.Id);
            return Ok(result);
        }
    }


}
