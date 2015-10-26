using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
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
        #region Query Samples
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

        #endregion

        /*  Special Events CRUD */
        #region CRUD insert update delete
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void SpecialEvents_Add(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var added = context.SpecialEvents.Add(item);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void SpecialEvents_Update(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {

                context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }


        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void SpecialEvents_Delete(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var existing = context.SpecialEvents.Find(item.EventCode);
                context.SpecialEvents.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion


        /* Waiter CRUD */
        #region CRUD insert update delete
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Waiter Waiter_GetWaiterById(int id)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                return context.Waiters.Find(id);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Waiter> Waiters_List()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                return context.Waiters.OrderBy(x => x.FirstName).ToList();
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int Waiter_Add(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var added = context.Waiters.Add(item);
                context.SaveChanges();
                return added.WaiterID;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Waiter_Update(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {

                context.Entry<Waiter>(context.Waiters.Attach(item)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }


        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Waiter_Delete(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var existing = context.Waiters.Find(item.WaiterID);
                context.Waiters.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion


        #region CategoryMenuItems Reporting

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CategoryMenuItems> GetReportCategoryMenuItems()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from cat in context.Items
                              orderby cat.Description, cat.Description
                              select new CategoryMenuItems
                              {
                                  CategoryDescription = cat.Category.Description,
                                  ItemDescription = cat.Description,
                                  Price = cat.CurrentPrice,
                                  Calories = cat.Calories,
                                  Comment = cat.Comment
                              };

                return results.ToList(); // this was .Dump() in Linqpad
            }
        }

        #endregion

        #region WaiterBills Reporting

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<WaiterBilling> GetReportWaiterBills()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                
                var results = from b in context.Bills
                                where b.BillDate.Month == 5
                                orderby b.BillDate descending, b.Waiter.LastName ascending, b.Waiter.FirstName ascending
                                select new WaiterBilling
                                {
                                    BillDate = b.BillDate,
                                    Name = b.Waiter.LastName + " " + b.Waiter.FirstName,
                                    BillID = b.BillID,
                                    BillTotal = b.Items.Sum(bitem => bitem.Quantity * bitem.SalePrice),
                                    PartySize = b.NumberInParty,
                                    Contact = b.Reservation.CustomerName

                                };

                return results.ToList();
                
                
            }
        }

        #endregion
    }
}


