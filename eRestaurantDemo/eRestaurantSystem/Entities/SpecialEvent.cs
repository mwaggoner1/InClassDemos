using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace eRestaurantSystem.Entities
{
    public class SpecialEvent
    {
        [Key]
        [Required(ErrorMessage="Event Code is Required")]
        [StringLength(1, ErrorMessage="Event Code Can Only Be A Single Character")]
        public string EventCode { get; set; }
        [Required(ErrorMessage="A Description is Required (5-30 characters)")]
        [StringLength(30, MinimumLength=5, ErrorMessage="A Description Must be Between 5 - 30 characters")]
        public string Description { get; set; }
        
        public bool Active { get; set; }


        // Navigation Virtual Properties
        public virtual ICollection<Reservation> Reservations { get; set; }
        

        public SpecialEvent() {
            
        }
    
    }
}
