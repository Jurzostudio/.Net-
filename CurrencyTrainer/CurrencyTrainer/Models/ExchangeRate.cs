using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace CurrencyTrainer.Models
{
    public static class ExchangeRate
    {
        private Dictionary<string, double> currencyRate = new Dictionary<string, double>();
        private void setValues(string currencyName)
        {
            var json = new WebClient().DownloadString(@"http://api.fixer.io/latest?base=" + currencyName);
            dynamic root = JObject.Parse(json);
            var mydic = root.rates;
            string jsonOnlyWithRates = Convert.ToString(root.rates);
            Dictionary<string, double> currencyRate = JsonConvert.DeserializeObject<Dictionary<string, double>>(jsonOnlyWithRates);
        }
        private void setValues(string currencyName, DateTime date)
        {
            string myDate = date.ToString("yyyy-MM-dd");
            //var json = new WebClient().DownloadString(@"http://api.fixer.io/" + latest?base=" + currencyName);
            dynamic root = JObject.Parse(json);
            var mydic = root.rates;
            string jsonOnlyWithRates = Convert.ToString(root.rates);
            Dictionary<string, double> currencyRate = JsonConvert.DeserializeObject<Dictionary<string, double>>(jsonOnlyWithRates);
        }
        public Dictionary<string, double> CurrencyRate
        {
            get { return currencyRate; }
        }
    }
}