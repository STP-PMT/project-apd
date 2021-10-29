using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
