using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using eRestaurantSystem.Entities;
using eRestaurantSystem.DAL;
using System.ComponentModel; // use for ODS access

namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class AdminController
    {

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SpecialEvent> SpecialEvent_List()
        {
            // the using is a transaction!
            using (var context = new eRestaurantContext())
            {
                // retrieve the data from the SpecialEvents Table

                // method syntax
                return context.SpecialEvents.OrderBy(x => x.Description).ToList();

            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> ReservationsByEventCode_List(string eventCode)
        {
            if(eventCode == "" || eventCode == null) {
                return new List<Reservation>();
            }
            // the using is a transaction!
            using (var context = new eRestaurantContext())
            {
                // retrieve the data from the SpecialEvents Table

                // change this to list the tables
                // query syntax
                var results = from item in context.Reservations
                              where item.EventCode.Equals(eventCode)
                              orderby item.ReservationDate, item.CustomerName
                              select item;

                return results.ToList();

            }
        }

    }
}


