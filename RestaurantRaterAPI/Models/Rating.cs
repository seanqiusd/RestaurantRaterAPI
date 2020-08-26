using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    public class Rating
    {
        // we are making a class of a property here with Rating class
        [Key] // Primary Key
        public int Id { get; set; } // Id is used in other classes, but bc this is a different one, it's ok to use here again

        // Foreign Key
        [ForeignKey(nameof(Restaurant))] // when we setup foreign keys, we need 2 things; 1. a foreign key (actual value), 2. and the navigation property, which tells us which table to go to// nameOf() is used instead of directly using string "Restaurant" bc if we ever go back and change the variable name Restaurant from the virtual property, it'll also change what's inside nameof().
        public int RestaurantId { get; set; }
        // ForeignKey Navigation Property
        public virtual Restaurant Restaurant { get; set; } // with entity framework, this lets us tell entity framework that RestaurantId and Restaurant are connected

        [Required]
        [Range(0, 10)] // gives a range with min and max for scoring purposes
        public double FoodScore { get; set; }

        [Required]
        [Range(0, 10)]
        public double EnvironmentScore { get; set; }

        [Required]
        [Range(0, 10)]
        public double CleanlinessScore { get; set; }

        // Add all scores and get the average out of 10
        public double AverageRating
        {
            get
            {
                var totalScore = FoodScore + EnvironmentScore + CleanlinessScore;
                return totalScore / 3;
            }
        }

    }
}