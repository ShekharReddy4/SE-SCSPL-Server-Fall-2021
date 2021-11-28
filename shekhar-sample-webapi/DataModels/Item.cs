using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shekhar_sample_webapi.DataModels
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        public int StockCount { get; set; }
        public int Price { get; set; }
        public bool IsScalable { get; set; }
    }
}
