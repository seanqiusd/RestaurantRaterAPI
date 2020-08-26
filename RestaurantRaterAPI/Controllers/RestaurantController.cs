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

            Restaurant restaurant = await _context.Restaurants.FindAsync(id); // r.Id is the id from the restaurant and id is the passed in parameter

            if (restaurant != null)
            {
                return Ok(restaurant);
            }

            return NotFound(); // built in method
        }

        // Get All
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync(); // Async methods usually need await in front
            return Ok(restaurants);
        }

        //-- Update (Put)
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri]int id, [FromBody]Restaurant updatedRestaurant) // uri kind of encapsulate urls
        {
            if (ModelState.IsValid)
            {

                // Find and udpate the appropriate restaurant
                Restaurant restaurant = await _context.Restaurants.FindAsync(id);

                if (restaurant != null)
                {
                    // Update the restaurant now that we found it
                    restaurant.Name = updatedRestaurant.Name;
                    //restaurant.Rating = updatedRestaurant.Rating;

                    await _context.SaveChangesAsync();

                    return Ok("Restaurant has been updated.");
                }
                // Didn't find the restaurant
                return NotFound();
                
            }
            return BadRequest(ModelState); // modelstate tells badrequest what specifically went wrong
           
        }

        //-- Delete (Delete)
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRestaurantById(int id)
        {
            Restaurant entity = await _context.Restaurants.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(entity);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The restaurant was deleted");
            }

            return InternalServerError(); // this is built in method; a 500 error
        }

    }
}
