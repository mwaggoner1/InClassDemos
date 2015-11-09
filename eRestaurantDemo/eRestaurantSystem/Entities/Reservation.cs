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
        [Required]
        [StringLength(40, ErrorMessage="Customer Name Must be Less Than 40 Characters")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Reservation Date Is Required")]
        public DateTime ReservationDate { get; set; }
        [Required(ErrorMessage = "Number In Party Is Required")]
        [Range(1, 16, ErrorMessage="Party Size Cannot Exceeed 16 People")]
        public int NumberInParty { get; set; }
        [Required(ErrorMessage = "Contact Phone Number Is Required")]
        [StringLength(15, ErrorMessage="Contact Phone Number Must be Less Than 15 Characters")]
        public string ContactPhone { get; set; }
        [Required(ErrorMessage="Reservation Status Code Is Required")]
        [StringLength(1, ErrorMessage = "Reservation Status Code Must be 1 Character")]
        public string ReservationStatus { get; set; }
        [StringLength(1, ErrorMessage = "Event Code Must be 1 Character")]
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
        public virtual ICollection<Bill> Bills { get; set; }

        public const string BOOKED      = "B";
        public const string ARRIVED     = "A";
        public const string COMPLETED   = "C";
        public const string CANCELED    = "X";
        public const string NO_SHOW     = "N"; 
 

 



    }
}
