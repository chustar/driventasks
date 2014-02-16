using System;
using System.Collections.ObjectModel;

using DesignTimeBuddy;

namespace driventasks.DesignViewModels
{
    public class TaskItemViewModel
    {
        public TaskItemViewModel()
        {
            Title = DesignTimeBuddy.DeisgnTimeBuddy.GetSimpleString(3);
            Description = DesignTimeBuddy.DeisgnTimeBuddy.GetSimpleString();
            Ratings = new ObservableCollection<Rating>();
            LoadData();
        }

        public void LoadData()
        {
            int count = randomizer.Next(0, 5);
            for (int i = 0; i < count; i++)
            {
                Ratings.Add(new Rating(randomizer.Next(-2,2)));
            }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ObservableCollection<Rating> Ratings { get; set; }

        private static Random randomizer = new Random();
    }

    public class Rating
    {
        public Rating(int ratingValue)
        {
            RatingValue = ratingValue;
        }

        public int RatingValue { get; set; }

        public DateTime DateCreated { get; set; }
    }

}
