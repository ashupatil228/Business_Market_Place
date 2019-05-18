using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessMarketPlace
{
    public class Servicesinfo
    {
        public string ServiceId { get; set; }
        public string ServiceType { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Location { get; set; }
        public string PostedDate { get; set; }
        public string PersonId { get; set; }
        public List<String> InterestedPersonsEmailId { get; set; }

       public Servicesinfo()
        {
            InterestedPersonsEmailId = new List<string>();
        }

    }
}
