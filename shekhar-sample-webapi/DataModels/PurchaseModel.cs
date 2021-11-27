using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shekhar_sample_webapi.DataModels
{
    public class PurchaseModel
    {
        public List<Item> items { get; set; }
        public CardDetails cd { get; set; }
        public int coupon_number { get; set; }
        public bool loyality { get; set; }
    }
}
