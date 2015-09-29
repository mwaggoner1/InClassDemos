using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eRestaurantSystem.Entities;
using System.Data.Entity;

namespace eRestaurantSystem.DAL
{
    internal class eRestaurantContext : DbContext
    {
        public eRestaurantContext()
            : base("name=EatIn")
        {
            // Constructor is to pass web config string name
        } 

        // Setup the DbSet Mappings
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Waiter> Waiters { get; set; }

        // When overrideing OnModelCreating(), it is important to remember to call the base model's
        // implementation before you exit the method

        // The ManyToManyNavigationPropertyConfiguration.Map Method lets you configure the tables and
        // columns use for many to many relationships. It takes a ManyToManyPropertyConfigurationProperty
        // instance in which you specify the column names b calling the MapLeftKey, MapRightKey,  and ToTable Methods

        // The "left" key is the one specified in the hasMany method
        // The "right" key is the one specified in the withMany method

        // we have a many to many relationship between reservation and tables. 
        // A reservation may need many tables. A table can have overtime many reservations. 


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Reservation>().HasMany(r => r.Tables)
                .WithMany(x => x.Reservations)
                .Map(mapping => {
                    mapping.ToTable("ReservationTables");
                    mapping.MapLeftKey("TableID");
                    mapping.MapRightKey("ReservationID");
                });

            base.OnModelCreating(modelBuilder);
        }



    }
}
