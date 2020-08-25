using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RestaurantController : ApiController
    {
        RestaurantDbContext _context = new RestaurantDbContext();

        // all endpoints will be public
        //-- Create (Post)
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            if (ModelState.IsValid) // modelstate property is inside apicontroller
            {
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync();

                return Ok("You created a restaurant and it was saved!"); // this is a built in method that gives a 200 ok
            }

            return BadRequest(ModelState); // returns modelstate dictionary
        }

        //-- Read (Get)
        // Get by ID

        // Get All

        //-- Update (Put)

        //-- Delete (Delete)


    }
}
