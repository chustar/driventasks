using driventasks.Models;
using driventasks.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace driventasks.ViewModels
{
    public class RatingViewModel : BindableBase
    {
        public Rating rating;

        #region Constructors
        public RatingViewModel()
        {
        }

        public RatingViewModel(Rating rating)
        {
            this.rating = rating;
        }
        #endregion

        #region Properties
        public string Id
        {
            get { return rating.Id; }
        }

        private int _ratingValue;
        public int RatingValue
        {
            get
            {
                return _ratingValue;
            }
            set
            {
                _ratingValue = value;
                NotifyPropertyChanged("RatingValue");
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyPropertyChanged("Description");
            }
        }
        #endregion

        public async Task LoadData(string id)
        {
            if (rating == null)
            {
                this.rating = await Rating.FetchById(id);
            }

            RatingValue = rating.RatingValue;
            Description = rating.Description;
        }

        public async Task SaveData()
        {
            if (rating == null)
            {
                rating = new Rating(RatingValue, Description);
                await Rating.Create(rating);
            }
            else
            {
                await Rating.Update(rating);
            }
        }
    }
}