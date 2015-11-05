using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleTravel_API.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public Contact Get(int id)
        {
            //find by numberId = id Contact in DB. 
            Contact c1 = new Contact() { name = "Alexandr", secondName = "Onopriienko", age = 26, numberId = 1234567890, sex = Sex.Male };
            return c1;
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
    }
}