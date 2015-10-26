using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurantSystem.Entities.POCOs
{
    public class WaiterBilling
    {
        public DateTime BillDate { get; set; }
        public String Name { get; set; }
        public int BillID { get; set; }
	    public decimal BillTotal { get; set; }
	    public int PartySize { get; set; }
        public String Contact { get; set; }
        
    }
}
