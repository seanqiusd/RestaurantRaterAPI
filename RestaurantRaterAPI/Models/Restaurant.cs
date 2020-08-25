using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    // Restaurant Entity (The class that gets stored in the database)
    public class Restaurant
    {

        [Key] // this is must have 

        public int Id { get; set; }

        [Required] // also must have. make sure that you have attributes placed above each new property
        public string Name { get; set; }
        
        [Required]

        public double Rating { get; set; }

        public bool IsRecommended
        {
            get
            {
                return Rating > 3.5;
            }
        }

        //public bool IsRecommended => Rating > 3.5; even shorter hand way of saying the same thing

        //public bool IsRecommended
        //{
        //    get
        //    {
        //        //bool isRecommended = Rating > 3.5;
        //        //return isRecommended;



        //        //return Rating > 3.5; // ternary below that is simplified, this does the same thing as ternary below

        //        //return (Rating > 3.5) ? true : false; // ternary

        //        //if (Rating > 3.5)
        //        //{
        //        //    return true;
        //        //}
        //        //else
        //        //{
        //        //    return false;
        //        //}
        //    }
        //}

    }
}