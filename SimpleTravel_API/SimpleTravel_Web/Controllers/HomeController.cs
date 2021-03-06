﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SimpleTravel_API.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public ActionResult Index()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:24081");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/values").Result;
                var result = response.Content.ReadAsAsync<IEnumerable<string>>().Result;
                if (result == null)
                {
                    return View();
                }
                else
                {
                    return View((IEnumerable<string>)result);
                }
            }
            catch (AggregateException e)
            {
                return View();
            }                  
            
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
