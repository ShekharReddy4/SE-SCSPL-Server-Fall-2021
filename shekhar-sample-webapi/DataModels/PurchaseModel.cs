using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shekhar_sample_webapi.DataModels
{
    public class PurchaseModel
    {
        public List<Item> Items { get; set; }
        public List<CardDetails> cardDetailsArray { get; set; }
        public List<int> checkidArray { get; set; }
        public bool iscash { get; set; }
        
    }
}
