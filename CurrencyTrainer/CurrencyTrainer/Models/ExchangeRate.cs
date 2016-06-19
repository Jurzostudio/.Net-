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
        private static Dictionary<string, double> currencyRate = new Dictionary<string, double>();
        private static void setValues(string baseCurrency)
        {
            var json = new WebClient().DownloadString(@"http://api.fixer.io/latest?base=" + baseCurrency);
            dynamic root = JObject.Parse(json);
            var mydic = root.rates;
            string jsonOnlyWithRates = Convert.ToString(root.rates);
            Dictionary<string, double> currencyRate = JsonConvert.DeserializeObject<Dictionary<string, double>>(jsonOnlyWithRates);
        }
        private static void setValues(string baseCurrency, DateTime date)
        {
            string myDate = date.ToString("yyyy-MM-dd");
            var json = new WebClient().DownloadString(@"http://api.fixer.io/" + myDate + "?base=" + baseCurrency);
            dynamic root = JObject.Parse(json);
            var mydic = root.rates;
            string jsonOnlyWithRates = Convert.ToString(root.rates);
            Dictionary<string, double> currencyRate = JsonConvert.DeserializeObject<Dictionary<string, double>>(jsonOnlyWithRates);
        }
        private static double ratioBetweenTwoCurrencys(string baseCurrency, string secondCurrency)
        {
            var json = new WebClient().DownloadString(@"http://api.fixer.io/latest?base=" + baseCurrency);
            dynamic root = JObject.Parse(json);
            var mydic = root.rates;
            string jsonOnlyWithRates = Convert.ToString(root.rates);
            Dictionary<string, double> currencyRate = JsonConvert.DeserializeObject<Dictionary<string, double>>(jsonOnlyWithRates);
            return currencyRate[secondCurrency];
        }
        public static Dictionary<string, double> CurrencyRate
        {
            get { return currencyRate; }
        }
        public static List<string> CurrencyList()
        {
            List<string> temp = new List<string>();
            temp.Add("EUR");
            temp.Add("USD");
            temp.Add("GBP");
            temp.Add("RUB");
            temp.Add("PLN");

            temp.Add("AUD");
            temp.Add("BGN");
            temp.Add("BRL");
            temp.Add("CAD");
            temp.Add("CHF");
            temp.Add("CNY");
            temp.Add("CZK");            
            temp.Add("HKD");
            temp.Add("HRK");
            temp.Add("HUF");
            temp.Add("IDR");
            temp.Add("ILS");
            temp.Add("INR");
            temp.Add("JPY");
            temp.Add("KRW");
            temp.Add("MXN");
            temp.Add("MYR");
            temp.Add("NOK");
            temp.Add("NZD");
            temp.Add("PHP");            
            temp.Add("RON");            
            temp.Add("SEK");
            temp.Add("SGD");
            temp.Add("THB");
            temp.Add("TRY");
            temp.Add("ZAR");
            return temp;
        }
    }
}