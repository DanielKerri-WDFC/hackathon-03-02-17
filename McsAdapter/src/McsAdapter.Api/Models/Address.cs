using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McsAdapter.Api.Models
{
    public class Address
    {
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string Postcode { get; set; }

    }
}
