using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using eRestaurantSystem.Entities;
using eRestaurantSystem.DAL;
using System.ComponentModel;
using eRestaurantSystem.Entities.DTOs; // use for ODS access
using eRestaurantSystem.Entities.POCOs;

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


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ReservationByDate> GetReservationsByDate(string date)
        {
            if (date == "" || date == null)
            {
                return new List<ReservationByDate>();
            }
            using (var context = new eRestaurantContext())
            {
                // remember linq does not like using datetime casting.
                int year = (DateTime.Parse(date)).Year;
                int month = (DateTime.Parse(date)).Month;
                int day = (DateTime.Parse(date)).Day;

                //query syntax
                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select new ReservationByDate()
                              {
                                  Description = item.Description,
                                  Reservations = from row in item.Reservations
                                                 where row.ReservationDate.Year == year &&
                                                       row.ReservationDate.Month == month &&
                                                       row.ReservationDate.Day == day
                                                 select new ReservationDetail() // POCO
                                                 {
                                                     CustomerName = row.CustomerName,
                                                     ReservationDate = row.ReservationDate,
                                                     NumberInParty = row.NumberInParty,
                                                     ContactPhone = row.ContactPhone,
                                                     ReservationStatus = row.ReservationStatus
                                                 }
                              };
                return results.ToList();

            }

        }


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CategoryMenuItem> CategoryMenuItems_List()
        {
            
            using (var context = new eRestaurantContext())
            {

                //query syntax
                var results = from item in context.MenuCategories
                              orderby item.Description
                              select new CategoryMenuItem()
                              {
                                  Description = item.Description,
                                  MenuItems = from row in item.MenuItems
                                                 select new MenuItem() // POCO
                                                 {
                                                     Description = row.Description,
                                                     Price = row.CurrentPrice,
                                                     Calories = row.Calories,
                                                     Comment = row.Comment
                                                 }
                              };
                return results.ToList();

            }

        }
    }
}


