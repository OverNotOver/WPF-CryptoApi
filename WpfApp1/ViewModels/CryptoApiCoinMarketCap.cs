using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModels
{
    public class CryptoApiCoinMarketCap
    {
        private static readonly HttpClient _HttpClient = new HttpClient();

        const string API_KEY = "04c86425-ade8-48ed-9e25-96c9c19a1faa";

        public async Task<List<Crypto>> GetCryptoApi()
        {
            string url = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest";

            _HttpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", API_KEY);
            _HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");



            try
            {
                HttpResponseMessage responseMessage = await _HttpClient.GetAsync(url);
                responseMessage.EnsureSuccessStatusCode();

                string responseGet = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseGet);

                var JsonCryptoToken = jsonResponse["data"];

                List<Crypto> cryptosList = new List<Crypto>();

                foreach (var cryptoCurrenci in JsonCryptoToken)
                {
                    Crypto crypto = new Crypto();
                    crypto.Number = int.Parse(cryptoCurrenci["cmc_rank"].ToString());
                    crypto.Name = cryptoCurrenci["name"].ToString();
                    crypto.Symbol = cryptoCurrenci["symbol"].ToString();

                    double cap = 0;
                    if (cryptoCurrenci["quote"]["USD"]["market_cap"] != null && double.TryParse(cryptoCurrenci["quote"]["USD"]["market_cap"].ToString(), out cap)) crypto.MakeCap = "$ " +Math.Round(cap, 3).ToString("N0", CultureInfo.InvariantCulture);
                    else crypto.MakeCap = null;
               

                    decimal price = 0;           
                    if (cryptoCurrenci["quote"]["USD"]["price"] != null && decimal.TryParse(cryptoCurrenci["quote"]["USD"]["price"].ToString(), out price)) crypto.Price = "$ " + Math.Round(price, 2).ToString();
                    else crypto.Price = null;

                    double percent = 0;
                    if(cryptoCurrenci["quote"]["USD"]["percent_change_24h"] != null && double.TryParse(cryptoCurrenci["quote"]["USD"]["percent_change_24h"].ToString(), out percent)) crypto.PercentChange24h = Math.Round(percent, 3).ToString() + "%";
                    else crypto.PercentChange24h = null;
                       
            
                    cryptosList.Add(crypto);
                }

                return cryptosList;


            }
            catch (HttpRequestException ex)
            {
                return null;
            }
        }

  
    }
}
