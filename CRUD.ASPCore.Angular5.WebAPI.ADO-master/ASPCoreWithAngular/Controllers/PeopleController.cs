using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using ASPCoreWithAngular.Models;

namespace ASPCoreWithAngular.Controllers
{
    public class PeopleController : Controller
    {
        PeopleDataAccessLayer people;

        public PeopleController()
        {
            people = new PeopleDataAccessLayer();
        }

        [HttpGet("[action]")]
        [Route("api/People/Index")]
        public IEnumerable<Person> Index()
        {
            return people.GetPeople();
        }

        [HttpPost]
        [Route("api/People/Create")]
        public int Create([FromBody] Person person)
        {
            return people.AddPerson(person);
        }

        [HttpGet]
        [Route("api/People/Details/{id}")]
        public Person Details(int id)
        {
            return people.GetPerson(id);
        }

        [HttpPut]
        [Route("api/People/Edit")]
        public int Edit([FromBody]Person person)
        {
            return people.UpdatePerson(person);
        }

        [HttpDelete]
        [Route("api/People/Delete/{id}")]
        public int Delete(int id)
        {
            return people.DeletePerson(id);
        }

        [HttpGet("[action]")]
        [Route("api/People/GetCountries")]
        public IEnumerable<Country> GetCountries()
        {
            return people.GetCountries();
        }

        [HttpGet("[action]")]
        [Route("api/People/GetCities{countryID}")]
        public IEnumerable<City> GetCities(int countryID)
        {
            return people.GetCities(countryID);
        }
    }
}
