using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace eRestaurantSystem.Entities
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberInParty { get; set; }
        public string ContactPhone { get; set; }
        public string ReservationStatus { get; set; }
        public string EventCode { get; set; }

        // Navigation Properties
        public virtual SpecialEvent Event { get; set; }
        
        // the reservations table is a many to many relationship to the tables table
        // the SQL reservationsTable resolves this problem however
        // reservationsTable holds only a compound primary key.
        // we will not create a reservationsTable entity in our project
        // but handle it via navigation mapping
        // therefore we will place a iCollection<> property in this entity 
        // refering to the tables table.

        public virtual ICollection<Table> Tables { get; set; }


    }
}
