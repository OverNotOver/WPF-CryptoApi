using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Crypto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double MakeCap { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public double PercentChange24h { get; set; }
 
    }

}
