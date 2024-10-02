using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public static class ConvertCrypto
    {
        public static decimal Convert(decimal number1InPut, decimal number1ToUsd, decimal number2ToUsd) 
        {
            return (number1InPut * number1ToUsd) / number2ToUsd;
        }
    }
}
