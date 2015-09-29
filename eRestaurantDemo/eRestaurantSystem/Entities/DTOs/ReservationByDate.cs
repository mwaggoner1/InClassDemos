using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using eRestaurantSystem.Entities.POCOs;

namespace eRestaurantSystem.Entities.DTOs
{
    public class ReservationByDate
    {
        public string Description { get; set; }
        // the rest of the data will be a collection of POCO rows
        // the actual poco will be defined in the linq query
        public IEnumerable<ReservationDetail> Reservations { get; set; }

    }
}
