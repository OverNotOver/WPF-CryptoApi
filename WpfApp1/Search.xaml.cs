using GalaSoft.MvvmLight.Messaging;
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
        public CryptoViewModel _cryptoView;
        public Search(object data)
        {
            InitializeComponent();
            _cryptoView = (CryptoViewModel?)data;
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Перезупускай");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name = textBox.Text;

            foreach (var item in _cryptoView.Cryptos)
            {
                if (item.Name == name || item.Symbol == name)
                {
                    textBlock.Text += item.Name + "\n";
                    textBlock.Text += item.Price + "\n";
                    textBlock.Text += item.MakeCap + "\n";
                    textBlock.Text += item.Number + "\n";
                    textBlock.Text += item.Symbol + "\n";
                }

            }
           
        }
    }
}
