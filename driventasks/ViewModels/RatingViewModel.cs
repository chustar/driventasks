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
        private Rating rating;

        #region Constructors
        public RatingViewModel()
        {
        }

        public RatingViewModel(Rating rating)
        {
            this.rating = rating;

            LoadData();
        }
        #endregion

        #region Properties
        public string Id
        {
            get { return rating.Id; }
        }

        public int RatingValue { get; set; }

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
                NotifyPropertyChanged("_description");
            }
        }
        #endregion

        public void LoadData()
        {
            RatingValue = rating.RatingValue;
            Description = rating.Description;
        }

        public async Task LoadData(string id)
        {
            if (rating == null)
            {
                this.rating = await Rating.FetchById(id);
            }

            LoadData();
        }
    }
}