using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace driventasks_viewmodel.Models
{
    class Rating
    {
        private int _rating = 0;
        public int Rating
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
    }
}
