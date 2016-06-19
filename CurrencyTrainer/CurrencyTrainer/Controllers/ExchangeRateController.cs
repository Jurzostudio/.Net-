using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace CurrencyTrainer.Controllers
{
    public class ExchangeRateController : Controller
    {
        // GET: ExchangeRate
        public ActionResult Index()
        {
            return View();
        }
        private void setValues()
        {
            dynamic root = JObject.Parse("http://api.fixer.io/latest");
            int id = root.rates[0].AUD;
        }
    }
}