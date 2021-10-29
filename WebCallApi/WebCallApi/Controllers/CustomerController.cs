using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebCallApi.Models;

namespace WebCallApi.Controllers
{
    public class CustomerController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        List<Customer> cuslist = new List<Customer>();

        public CustomerController() {
            _clientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors) => { return true; };
        }
        [HttpGet]
        public async Task<List<Customer>> GetCustomer()
        {
            cuslist = new List<Customer>();
            using (var httpClient = new HttpClient(_clientHandler)) 
            {
                using (var response = await httpClient.GetAsync("https://localhost:44383/api/Customer")) 
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    cuslist = JsonConvert.DeserializeObject<List<Customer>>(strJson);
                }
            }

            return cuslist;
        }
        // GET: CustomerController
        public async Task<ActionResult> Index()
        {
            var customer = await GetCustomer();
            return View(customer);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            Customer cus = new Customer();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new 
                    StringContent(JsonConvert.SerializeObject(customer),Encoding.UTF8,"application/json");
                using (var reponse = await httpClient.PostAsync("https://localhost:44383/api/Customer", content))
                {
                    string apiResponse = await reponse.Content.ReadAsStringAsync();
                    cus = JsonConvert.DeserializeObject<Customer>(apiResponse);
                    if (ModelState.IsValid) {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(cus);           
        }

        // GET: CustomerController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Customer  mycus = null;
            cuslist = new List<Customer>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44383/api/Customer/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cuslist = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
                    mycus = cuslist[0];
                   
                }
            }
            return View(mycus);
           
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            Customer cus = new Customer();
            if (!ModelState.IsValid) return View(customer);
            using(var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content =
                    new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44383/api/Customer/" + id, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cus = JsonConvert.DeserializeObject<Customer>(apiResponse);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CustomerController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string del = "";
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var reponse = await httpClient.DeleteAsync("https://localhost:44383/api/Customer/" + id))
                {
                    del = await reponse.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
