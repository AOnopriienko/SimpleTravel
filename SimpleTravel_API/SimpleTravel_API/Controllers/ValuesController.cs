using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Ninject;
using SimpleTravel.Infrastructure;
using SimpleTravel.Infrastructure.Repositories.Implementation;

namespace SimpleTravel_API.Controllers
{
    public class ValuesController : ApiController
    {
        public IRepository<Apartment> repository;

        public ValuesController(IRepository<Apartment> apartmentRepository) 
        {
            repository = apartmentRepository;
        }
        
        public ValuesController()
        {
            this.repository = new ApartmentRepository();
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            var apartment = repository.GetList();
            string acList = JsonConvert.SerializeObject(apartment);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(string acName, string acAdress, ApartmentType acType)
        {

            //find by numberId = id Contact in DB. 
            Apartment ac = new Apartment() { Id = Guid.NewGuid(), TypeId = acType, Name = acName, Address = acAdress };
            repository.Create(ac);
            repository.Save();
            var apartment = repository.GetList();
            string acList = JsonConvert.SerializeObject(apartment);
            return acList;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}