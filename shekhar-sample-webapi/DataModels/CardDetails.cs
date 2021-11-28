using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace shekhar_sample_webapi.DataModels
{
    public class CardDetails: IEquatable<CardDetails>
    {
        public string card_number { get; set; }
        public string name_on_card { get; set; }
        public string cvv { get; set; }
        public string expiry { get; set; }


        public bool Equals(CardDetails other)
        {
            if (this.card_number == other.card_number && this.name_on_card == other.name_on_card
                && this.cvv == other.cvv && this.expiry == other.expiry)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
