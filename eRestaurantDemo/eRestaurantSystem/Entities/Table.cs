using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace eRestaurantSystem.Entities
{
    public class Table
    {
        [Key]
        public int TableID { get; set; }
        [Required(ErrorMessage="Table Number is Required")]
        [Range(1, 25, ErrorMessage="Table Number must be a positive number")]
        public byte TableNumber { get; set; }
        public bool Smoking { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }

        // Navigation Properties
        public ICollection<Reservation> Reservations { get; set; }

    }
}
