using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.ViewModels
{

    internal class CryptoApiCoinGecko
    {
        public static readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<Tuple<DateTime, decimal>>> GetHistoricalPrices(string coinId, int days)
        {
            string apiUrl = $"https://api.coingecko.com/api/v3/coins/{coinId}/market_chart?vs_currency=usd&days={days}";

            try
            {
              
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                JObject jsonResponse = JObject.Parse(responseBody);
                JArray pricesArray = (JArray)jsonResponse["prices"];

                List<Tuple<DateTime, decimal>> priceList = new List<Tuple<DateTime, decimal>>();

                foreach (var priceData in pricesArray)
                {
                    long timestamp = (long)priceData[0];
                    decimal price = (decimal)priceData[1];

                    DateTime date = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).DateTime;
                    priceList.Add(new Tuple<DateTime, decimal>(date, price));
                }

                return priceList;
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
