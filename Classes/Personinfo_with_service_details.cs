using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessMarketPlace
{
    public class Personinfo_with_service_details
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<String> Interested_offers { get; set; }
        public List<String> Offered_services { get; set; }

        public Personinfo_with_service_details()
        {
          
            Interested_offers = new List<String>();
            Offered_services = new List<String>();
        }
    }
    
}
