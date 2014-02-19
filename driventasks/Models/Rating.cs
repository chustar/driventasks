using driventasks.Data;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace driventasks.Models
{
    public class Rating
    {
        public Rating(int rating = 0, string description  = "")
        {
            RatingValue = rating;
            Description = description;
        }

        public string Id { get; set; }

        private int _rating = 0;

        [JsonProperty(PropertyName = "rating")] 
        public int RatingValue
        {
            get
            {
                return _rating;
            }
            set
            {
                if (value >= -2 && value <= 2)
                {
                    _rating = value;
                }
            }
        }

        [JsonProperty(PropertyName = "description")] 
        public string Description { get; set; }


        [JsonProperty(PropertyName = "created")]
        public DateTime DateCreated {get; set; }

        public static async Task Create(Rating rating)
        {
            await ratingsTable.InsertAsync(rating);
        }
        
        public static async Task<Rating> FetchById(string id)
        {
            return (await ratingsTable
                .Where(rating => rating.Id == id)
                .Take(1)
                .ToListAsync()).First();
        }

        public static async Task Update(Rating rating)
        {
            await ratingsTable.UpdateAsync(rating);
        }
        
        private static IMobileServiceTable<Rating> ratingsTable = DataStorage.DrivenTasks.GetTable<Rating>();
    }
}
