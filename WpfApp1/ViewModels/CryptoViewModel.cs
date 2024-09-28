using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using WpfApp1.Model;

namespace WpfApp1.ViewModels
{
    public class CryptoViewModel
    {

        public ObservableCollection<Crypto> Cryptos { get; set; }

        private readonly CryptoApiCoinMarketCap apiClient;

        public CryptoViewModel()
        {
            Cryptos = new ObservableCollection<Crypto>();
            apiClient = new CryptoApiCoinMarketCap();
            LoadData();
        }

        //public Crypto GetSearch(string nameCrypto)
        //{
        //    foreach (var item in cryptoViewModel.Cryptos)
        //    {
        //        if (item.Name == nameCrypto)
        //        {
        //            return item;
        //        }

        //    }
        //    return null;
        //}

        private async void LoadData()
        {
            List<Crypto> cryptoData = await apiClient.GetCryptoApi();
            int counter = 0;

            Cryptos.Clear();

            if (cryptoData != null) 
            {
                foreach (var crypto in cryptoData)
                {
                    if (true)
                    {
                        Cryptos.Add(crypto);
                        counter++;
                    }

                }
            }
            else
            {
                MessageBox.Show("Null");
            }



        }
    }



}
