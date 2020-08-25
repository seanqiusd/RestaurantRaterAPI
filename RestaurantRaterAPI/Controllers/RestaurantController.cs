using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext(); // we set a field

        // all endpoints will be public
        //-- Create (Post)
        [HttpPost]
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model) // if we want to change PostRestaurant to CreateRestaurant, the only way to make sure that this method is set as a post method is to add attribute [HttpPost]
        {
            if (model is null) // == works the same
            {
                return BadRequest("Your request body cannot be empty.");
            }

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
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            return Ok();
        }

        // Get All
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync(); // Async methods usually need await in front
            return Ok(restaurants);
        }

        //-- Update (Put)

        //-- Delete (Delete)


    }
}
