using driventasks.Data;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace driventasks.Models
{
    public class TaskItem
    {
        public TaskItem(string title, string description, Rating rating)
        {
            Ratings = new ObservableCollection<Rating>();
            Ratings.Add(rating);
            DateCreated = DateTime.UtcNow;
            tasksTable.InsertAsync(this);
        }

        [JsonProperty(PropertyName = "title")] 
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")] 
        public string Description { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty(PropertyName = "started")]
        public DateTime DateStarted { get; set; }

        [JsonProperty(PropertyName = "modified")]
        public DateTime DateModified { get; set; }

        [JsonProperty(PropertyName = "completed")]
        public DateTime DateCompleted { get; set; }

        [JsonProperty(PropertyName = "deleted")]
        public DateTime DateDeleted { get; set; }

        [JsonProperty(PropertyName = "ratings", ItemIsReference = true)] 
        public ObservableCollection<Rating> Ratings { get; set; }

        public bool Started
        {
            get
            {
                return DateStarted == null;
            }
        }

        public bool Completed
        {
            get
            {
                return DateCompleted == null;
            }
        }

        public bool Deleted
        {
            get
            {
                return DateDeleted == null;
            }
        }

        public async Task Update()
        {
            DateModified = DateTime.UtcNow;
            await tasksTable.UpdateAsync(this);
        }
       
        public async Task Start()
        {
            DateStarted = DateTime.UtcNow;
            await tasksTable.UpdateAsync(this);
        }
        
        public async Task Complete()
        {
            DateCompleted = DateTime.UtcNow;
            await Update();
        }

        public async Task Delete()
        {
            DateModified = DateTime.UtcNow;
            await Update();
        }
        
        public async Task AddRating(int rating = 0)
        {
            Ratings.Add(new Rating(rating));
            await Update();
        }

        private IMobileServiceTable<TaskItem> tasksTable = DataStorage.DrivenTasks.GetTable<TaskItem>();
    }
}
