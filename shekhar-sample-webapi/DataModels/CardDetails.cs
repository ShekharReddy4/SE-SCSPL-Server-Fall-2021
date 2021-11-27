using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shekhar_sample_webapi.DataModels
{
    public class CardDetails
    {
        public string card_number { get; set; }
        public string name_on_card { get; set; }
        public string cvv { get; set; }
        public string expiry { get; set; }
    }
}
