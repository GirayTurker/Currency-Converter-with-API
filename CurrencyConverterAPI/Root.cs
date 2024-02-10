using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurrencyConverterAPI
{
    public class Root
    {
        //get all record in rates and set in rate class as currency name
        public Rate rates { get; set; }
        public long timestamp;
        public string licence;
    }
}
