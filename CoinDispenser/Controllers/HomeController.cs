using CoinDispenser.Data;
using CoinDispenser.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace CoinDispenser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private AppDbContext _context;


        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {

            return View();
        }

        
        public IActionResult GetCoins(string txtAmount)
        {
            string urlParameters = "?amount=" + txtAmount;

            string strURL = string.Format("https://localhost:44326/api/CoinChanger");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(strURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            List<CoinLookup> coins = null;
            if (response.IsSuccessStatusCode)
            {
                 coins = response.Content.ReadAsAsync<IEnumerable<CoinLookup>>().Result.ToList();               
            }

             return View("Index",coins);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    
    
    
        

    
    }
}
