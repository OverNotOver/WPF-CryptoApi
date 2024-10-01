using GalaSoft.MvvmLight.Messaging;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Model;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        private CryptoApiCoinGecko _coinGecko;
        public CryptoViewModel _cryptoView;
        public Search(object data)
        {
            InitializeComponent();
            _cryptoView = (CryptoViewModel)data;
            _coinGecko = new CryptoApiCoinGecko();
       


        }

        private async void LoadGraph(string nameCrypto, int periodDays)
        {
            
            List<Tuple<DateTime, decimal>> prices = await _coinGecko.GetHistoricalPrices(nameCrypto, periodDays);

            if (prices != null)
            {
                var plotModel = new PlotModel { Title = $"{nameCrypto} Price (USD)" };


                var xAxis = new DateTimeAxis
                {
                    Position = AxisPosition.Bottom,
                    Title = "Date",
                    IsZoomEnabled = false,  
                    IsPanEnabled = false   
                };

                var yAxis = new LinearAxis
                {
                    Position = AxisPosition.Left,
                    Title = "Price (USD)",
                    IsZoomEnabled = false,  
                    IsPanEnabled = false   
                };


                plotModel.Axes.Add(xAxis);
                plotModel.Axes.Add(yAxis);


                var series = new LineSeries
                {
                    Title = "Price",
                    MarkerType = MarkerType.Circle,
                    MarkerSize = 4,
                    MarkerStroke = OxyColors.Red
                };

                foreach (var price in prices)
                {
                    series.Points.Add(DateTimeAxis.CreateDataPoint(price.Item1, (double)price.Item2));
                }


                plotModel.Series.Add(series);
                PlotView.Model = plotModel;
            }
            else
            {
                MessageBox.Show("Не вишло");
            }
        }

 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
    
            string name = textBox.Text.ToUpper();
            textBlock.Text = "";
            foreach (var item in _cryptoView.Cryptos)
            {
         
                if (item.Name == name || item.Symbol == name)
                {
                   
                    textBlock.Text += item.Price + "\n";
                    textBlock.Text += item.MakeCap + "\n";
                    textBlock.Text += item.Symbol + "\n";
                    do
                    {
                        LoadGraph(item.Name.ToLower(),5);
                    }
                    while (false);
                }

            }

       

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
