using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class ShowValueController : ApiController
    {
        // GET: api/ShowValue
        public IEnumerable<string> Get()
        {
            return new string[] { "สิทธิพงษ์", "ชลสิทธิ์","ดุ๋งๆ" };
        }

        // GET: api/ShowValue/5
        public string Get(int id)
        {
            if (id == 1) return "One";
            else if (id == 2) return "Two";
            else if (id == 3) return "Three";
            return "Number";
        }

        // POST: api/ShowValue
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShowValue/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShowValue/5
        public void Delete(int id)
        {
        }
    }
}
