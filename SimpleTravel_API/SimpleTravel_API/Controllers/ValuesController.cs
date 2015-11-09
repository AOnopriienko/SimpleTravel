using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Ninject;
using SimpleTravel.Infrastructure;

namespace SimpleTravel_API.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IApartmentRepository repo;
        private readonly IReservation reservation;
        
        public ValuesController(IApartmentRepository r, IReservation res) 
        {
            repo = r;
            reservation = res;
        }
        
        public ValuesController()
        {
            this.repo = new ApartmentRepository();
            this.reservation = new CacheReservation();
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            var apartment = repo.GetApartmentList();
            string acList = JsonConvert.SerializeObject(apartment);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(string acName, string acAdress, ApartmentType acType)
        {

            //find by numberId = id Contact in DB. 
            Apartment ac = new Apartment() { Id = Guid.NewGuid(), TypeId = acType, Name = acName, Address = acAdress };
            repo.Create(ac);
            repo.Save();
            var apartment = repo.GetApartmentList();
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
            repo.Dispose();
            base.Dispose(disposing);
        }
    }
}