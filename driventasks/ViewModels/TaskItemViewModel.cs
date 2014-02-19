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
    public class TaskItemViewModel : BindableBase
    {
        private TaskItem taskItem;

        #region Constructors
        public TaskItemViewModel()
        {
            Ratings = new ObservableCollection<RatingViewModel>();
        }

        public TaskItemViewModel(TaskItem taskItem)
        {
            this.taskItem = taskItem;

            Title = taskItem.Title;
            Description = taskItem.Description;
            Ratings = new ObservableCollection<RatingViewModel>();
        }
        #endregion

        #region Properties

        public string Id
        {
            get { return taskItem.Id; }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                NotifyPropertyChanged("_title");
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
                NotifyPropertyChanged("_description");
            }
        }

        public ObservableCollection<RatingViewModel> Ratings { get; private set; }

        public RatingViewModel NewRating { get; set; }
        #endregion

        #region TaskItemViewModel Commands
        private SimpleCommand _addRatingCommand;
        public SimpleCommand AddRatingCommand
        {
            get
            {
                if (_addRatingCommand == null)
                    _addRatingCommand = new SimpleCommand(async property =>
                {
                    await NewRating.SaveData();
                    taskItem.Ratings.Add(NewRating.rating);
                    await TaskItem.Update(taskItem);
                    Ratings.Add(NewRating);
                });
                return _addRatingCommand;
            }
        }

        private SimpleCommand _updateTaskItemCommand;
        public SimpleCommand UpdateTaskItemCommand
        {
            get
            {
                if (_updateTaskItemCommand == null)
                    _updateTaskItemCommand = new SimpleCommand(async property =>
                {
                    await taskItem.Update();
                });
                return _updateTaskItemCommand;
            }
        }

        private SimpleCommand _startTaskItemCommand;
        public SimpleCommand StartTaskItemCommand
        {
            get
            {
                if (_startTaskItemCommand == null)
                    _startTaskItemCommand = new SimpleCommand(async property =>
                {
                    await taskItem.Start();
                });
                return _startTaskItemCommand;
            }
        }

        private SimpleCommand _completeTaskItemCommand;
        public SimpleCommand CompleteTaskItemCommand
        {
            get
            {
                if (_completeTaskItemCommand == null)
                    _completeTaskItemCommand = new SimpleCommand(async property =>
                {
                    await taskItem.Complete();
                });
                return _completeTaskItemCommand;
            }
        }
        #endregion
        
        public async Task LoadData(string id)
        {
            if (taskItem == null)
            {
                this.taskItem = await TaskItem.FetchById(id);
            }

            Title = taskItem.Title;
            Description = taskItem.Description;
            
            foreach (var rating in taskItem.Ratings)
            {
                Ratings.Add(new RatingViewModel(rating));
            }
        }

        public async Task SaveData()
        {
            if (taskItem == null)
            {
                taskItem = new TaskItem(Title, Description, new Rating(0));
                await TaskItem.Create(taskItem);
            }
            else
            {
                taskItem.Title = Title;
                taskItem.Description = Description;
                await taskItem.Update();
            }
        }

        public async Task DeleteData()
        {
            if (taskItem != null)
            {
                await taskItem.Delete();
            }
        }
    }
}
