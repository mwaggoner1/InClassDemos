<Query Kind="Statements">
  <Connection>
    <ID>e193b4dd-1844-4202-9965-651ad595080d</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Find out information on the tables in the restaurant at a specific date/time
// Create a date and time object to use for sample input data
var date = Bills.Max(b => b.BillDate).Date;
var time = Bills.Max(b => b.BillDate).TimeOfDay.Add(new TimeSpan(0, 30, 0));
date.Add(time).Dump("The test date/time I am using");

// Step 1 - Get the table info along with any walk-in bills and reservation bills for the specific time slot
var step1 = from data in Tables
             select new
             {
                Table = data.TableNumber,
                Seating = data.Capacity,
                // This sub-query gets the bills for walk-in customers
                WalkIns = from walkIn in data.Bills
                        where 
                               walkIn.BillDate.Year == date.Year
                            && walkIn.BillDate.Month == date.Month
                            && walkIn.BillDate.Day == date.Day
                            && walkIn.BillDate.TimeOfDay <= time
                            && (!walkIn.OrderPaid.HasValue || walkIn.OrderPaid.Value >= time)
//                          && (!walkIn.PaidStatus || walkIn.OrderPaid >= time)
                        select walkIn,
                 // This sub-query gets the bills for reservations
                 Reservations = from booking in data.ReservationTables
                        from reservationParty in booking.Reservation.Bills
                        where 
                               reservationParty.BillDate.Year == date.Year
                            && reservationParty.BillDate.Month == date.Month
                            && reservationParty.BillDate.Day == date.Day
                            && reservationParty.BillDate.TimeOfDay <= time
                            && (!reservationParty.OrderPaid.HasValue || reservationParty.OrderPaid.Value >= time)
//                          && (!reservationParty.PaidStatus || reservationParty.OrderPaid >= time)
                        select reservationParty
             };
step1.Dump();


// Step 2 - Union the walk-in bills and the reservation bills while extracting the relevant bill info
// .ToList() helps resolve the "Types in Union or Concat are constructed incompatibly" error
var step2 = from data in step1.ToList() // .ToList() forces the first result set to be in memory
            select new
            {
                Table = data.Table,
                Seating = data.Seating,
                CommonBilling = from info in data.WalkIns.Union(data.Reservations)
                                select new // info
                                {
                                    BillID = info.BillID,
                                    BillTotal = info.BillItems.Sum(bi => bi.Quantity * bi.SalePrice),
                                    Waiter = info.Waiter.FirstName,
                                    Reservation = info.Reservation
                                }
            };
step2.Dump();


// Step 3 - Get just the first CommonBilling item
//         (presumes no overlaps can occur - i.e., two groups at the same table at the same time)
var step3 = from data in step2.ToList()
            select new
            {
                Table = data.Table,
                Seating = data.Seating,
                Taken = data.CommonBilling.Count() > 0,
                // .FirstOrDefault() is effectively "flattening" my collection of 1 item into a 
                // single object whose properties I can get in step 4 using the dot (.) operator
                CommonBilling = data.CommonBilling.FirstOrDefault()
            };
step3.Dump();


// Step 4 - Build our intended seating summary info
var step4 = from data in step3
            select new // SeatingSummary() // the DTO class to use in my BLL
            {
                Table = data.Table,
                Seating = data.Seating,
                Taken = data.Taken,
                // use a ternary expression to conditionally get the bill id (if it exists)
                BillID = data.Taken ?               // if(data.Taken)
                         data.CommonBilling.BillID  // value to use if true
                       : (int?) null,               // value to use if false
                BillTotal = data.Taken ? 
                            data.CommonBilling.BillTotal : (decimal?) null,
                Waiter = data.Taken ? data.CommonBilling.Waiter : (string) null,
                ReservationName = data.Taken ?
                                  (data.CommonBilling.Reservation != null ?
                                   data.CommonBilling.Reservation.CustomerName : (string) null)
                                : (string) null
            };
step4.Dump();