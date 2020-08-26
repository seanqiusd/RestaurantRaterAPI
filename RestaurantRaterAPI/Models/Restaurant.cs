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

        [Key] // Primary Key      this is must have 

        public int Id { get; set; }

        [Required] // also must have. make sure that you have attributes placed above each new property
        public string Name { get; set; }
        
        //[Required] we got rid of this here bc for ratings, it's going to come all from Rating Class

        public double Rating 
        { 
            get 
            {
                // return FoodRating + EnvironmentRating + CleanlinessRating
                // Calculate a total average score based on Ratings
                double totalAverageRating = 0;

                // Add all Ratings together to get total Average Rating
                foreach (var rating in Ratings)
                {
                    // totalAverageRating = totalAverageRating + rating.AverageRating; the += means this line of code
                    totalAverageRating += rating.AverageRating; // average of averages... every persons averages, average those averages

                }

                // Return Average of Total if the count is above 0
                return (Ratings.Count > 0) ? Math.Round(totalAverageRating / Ratings.Count, 2) : 0; // if we didn't convert what we had here to this ternary, it would divide by 0 and return an infinite rating, which is great, but not accurate......clarification the Ratings.Count is the count of the number of reviewers (people)

            } 
        }

        // Average Food Rating
        public double FoodRating
        {
            get
            {
                
                double totalAverageRating = 0;

                foreach (var rating in Ratings)
                {
                   
                    totalAverageRating += rating.FoodScore;

                }
                return (Ratings.Count > 0) ? Math.Round(totalAverageRating / Ratings.Count, 2) : 0;

            }
        }


        // Average Environment Rating
        public double EnvironmentRating
        {
            get
            {
                // Calculate a total average score based on Ratings
                double totalAverageRating = 0;

                // Add all Ratings together to get total Average Rating
                foreach (var rating in Ratings)
                {
                    // totalAverageRating = totalAverageRating + rating.AverageRating; the += means this line of code
                    totalAverageRating += rating.EnvironmentScore; // average of averages... every persons averages, average those averages

                }

                // Return Average of Total if the count is above 0
                return (Ratings.Count > 0) ? Math.Round(totalAverageRating / Ratings.Count, 2) : 0; // if we didn't convert what we had here to this ternary, it would divide by 0 and return an infinite rating, which is great, but not accurate......clarification the Ratings.Count is the count of the number of reviewers (people)

            }
        }

        // another way to do environment rating
        //public double EnvironmentRating
        //{
        //    get
        //    {
        //        var scores = Ratings.Select(rating => rating.EnvironmentScore); // this is kind of like a foreachloop here// the var here becomes an IEnumerable<double>....it can also be a List<double>
        //        double totalEnvironmentscore = scores.Sum();
        //        return (Ratings.Count > 0) ? totalEnvironmentscore / Ratings.Count : 0;
        //    }
        //}

        // Average Cleanliness Rating
        public double CleanlinessRating
        {
            get
            {
                // Calculate a total average score based on Ratings
                double totalAverageRating = 0;

                // Add all Ratings together to get total Average Rating
                foreach (var rating in Ratings)
                {
                    // totalAverageRating = totalAverageRating + rating.AverageRating; the += means this line of code
                    totalAverageRating += rating.CleanlinessScore; // average of averages... every persons averages, average those averages

                }

                // Return Average of Total if the count is above 0
                return (Ratings.Count > 0) ? Math.Round(totalAverageRating / Ratings.Count, 2) : 0; // if we didn't convert what we had here to this ternary, it would divide by 0 and return an infinite rating, which is great, but not accurate......clarification the Ratings.Count is the count of the number of reviewers (people)

            }
        }

        // another way to do cleanliness rating
        //public double CleanlinessScore
        //{
        //    get
        //    {
        //        var totalScore = Ratings.Select(r => r.CleanlinessScore).Sum();
        //        return (Ratings.Count > 0) ? totalScore / Ratings.Count : 0;
        //        // return (Ratings.Count > 0) ? Ratings.Select(r=>r.CleanlinessScore).Sum() / Ratings.Count : 0;  All of this is in the ternary we created above
        //    }
        //}



        public bool IsRecommended
        {
            get
            {
                return Rating > 8.5;
            }
        }

        // All of the associated Rating objects from the database
        // based on the Foreign Key relationship
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>(); // this ties t back to the Ratings class.... the left side List<Rating> is going to hold all the objects/properties in Rating class.

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