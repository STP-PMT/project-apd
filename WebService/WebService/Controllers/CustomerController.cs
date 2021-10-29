using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class CustomerController : ApiController
    {
        dbTestWebserviceEntities1 context = new dbTestWebserviceEntities1();
        /// <summary>
        /// Show all of customer
        /// </summary>
        /// <returns>all of customer</returns>
        // GET: api/Customer
        public IEnumerable<CustomerDT> Get()
        {
            var result = from c in context.Customers
                         select new CustomerDT { id = c.id, name = c.name, email = c.email };
            return result.ToList();
        }
        /// <summary>
        /// Show search of customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>cutomer from id</returns>

        // GET: api/Customer/5
        public IEnumerable<CustomerDT> Get(int id)
        {
            var result = from c
                         in context.Customers
                         where c.id == id
                         select new CustomerDT { id = c.id, name = c.name, email = c.email };
            return result.ToList();
        }

        // POST: api/Customer
        public void Post([FromBody]CustomerDT customer)
        {
            Customer cus = new Customer();
            cus.name = customer.name;
            cus.email = customer.email;
            context.Customers.Add(cus);
            context.SaveChanges();
        }

        // PUT: api/Customer/5
        public HttpResponseMessage Put(int id, [FromBody]Customer customer)
        {
            Customer cus = new Customer();
            if (customer == null) {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer is Null");
            }
            cus = context.Customers.FirstOrDefault(c => c.id == id);
            if (cus == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer with id = " +
                    id.ToString() + " not found to eidit");
            }
            else 
            {
                cus.name = customer.name;
                cus.email = customer.email;
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, cus);
            }
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
