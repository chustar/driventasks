using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace driventasks_viewmodel.Models
{
    class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ObservableVector<Rating> Ratings { get; set; }
        }
}
