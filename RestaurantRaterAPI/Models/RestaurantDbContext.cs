using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext() : base("DefaultConnection") { } // for base title, go to web.config and look at connectionString name
        public DbSet<Restaurant> Restaurants { get; set; } // This is basically our table in our database (DBContext that stores our entity)...next we need to build our connection string


    }
}