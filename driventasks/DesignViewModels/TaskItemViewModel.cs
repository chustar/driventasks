using System;
using System.Collections.ObjectModel;

namespace driventasks.DesignViewModels
{
    public class TaskItemViewModel
    {
        public TaskItemViewModel(string title, string description)
        {
            Title = title;
            Description = description;
            Ratings = new ObservableCollection<Rating>();
            LoadData();
        }

        public void LoadData()
        {
            int count = new Random().Next(1, 5);
            for (int i = 0; i < count; i++)
            {
                Ratings.Add(new Rating(new Random().Next(-2,2)));
            }
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public ObservableCollection<Rating> Ratings { get; set; }
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
