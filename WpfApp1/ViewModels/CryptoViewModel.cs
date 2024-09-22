using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WpfApp1.Model;

namespace WpfApp1.ViewModels
{
    public class CryptoViewModel
    {

        public ObservableCollection<Crypto> Cryptos { get; set; }

        private readonly CryptoApiClient apiClient;

        public CryptoViewModel()
        {
            Cryptos = new ObservableCollection<Crypto>();
            apiClient = new CryptoApiClient();
            LoadData();
        }


        private async void LoadData()
        {
            List<Crypto> cryptoData = await apiClient.GetCryptoApi();
            int counter = 0;

            Cryptos.Clear();
            foreach (var crypto in cryptoData)
            {
                if (counter < 10)
                {
                    Cryptos.Add(crypto);
                    counter++;
                }


            }
        }
    }



}
