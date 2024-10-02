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
using System.Windows.Shapes;
using WpfApp1.Model;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window_convert.xaml
    /// </summary>
    public partial class Window_convert : Window
    {
        public CryptoViewModel _cryptoView;


        public Window_convert(object data)
        {
            InitializeComponent();
            _cryptoView = (CryptoViewModel)data;
            this.DataContext = _cryptoView;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal res = 0;
            decimal crypt1 = 0;
            decimal crypt2 = 0;
            decimal numb;
            try
            {
                if (decimal.TryParse(numb1.Text, out numb))
                {
                    foreach (var item in _cryptoView.Cryptos)
                    {
                        if (comb1.Text == item.Name) crypt1 = decimal.Parse(item.Price.Substring(2));
                        if (comb2.Text == item.Name) crypt2 = decimal.Parse(item.Price.Substring(2));
                    }

                }
                
                res = ConvertCrypto.Convert(numb, crypt1, crypt2);
                numb2.Text = Math.Round(res, 3).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       



        }
    }
}
