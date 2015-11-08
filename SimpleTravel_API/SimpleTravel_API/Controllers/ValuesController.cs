using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnionApp.Domain.Core;
using OnionApp.Domain.Interfaces;
using OnionApp.Services.Interfaces;
using OnionApp.Infrastructure.Business;
using OnionApp.Infrastructure.Data;
using Newtonsoft.Json;
using Ninject;

namespace SimpleTravel_API.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IAccommodationRepository repo;// = new AccommodationRepository();
        private readonly IReservation reservation;// = new CacheReservation();
        
        public ValuesController(IAccommodationRepository r, IReservation res) 
        {
            repo = r;
            reservation = res;
        }
        
        public ValuesController()
        {
            this.repo = new AccommodationRepository();
            this.reservation = new CacheReservation();
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            var accommodation = repo.GetAccommodationList();
            string acList = JsonConvert.SerializeObject(accommodation);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(string acName, string acAdress, AccommodationType acType)
        {

            //find by numberId = id Contact in DB. 
            Accommodation ac = new Accommodation() { Id = Guid.NewGuid(), TypeId = acType, Name = acName, Address = acAdress };
            repo.Create(ac);
            repo.Save();
            var accommodation = repo.GetAccommodationList();
            string acList = JsonConvert.SerializeObject(accommodation);
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