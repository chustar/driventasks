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

        public async Task LoadData(string id)
        {
            this.taskItem = await TaskItem.FetchById(id);
            Title = taskItem.Title;
            Description = taskItem.Description;
        }

        #region TaskItemViewModel Commands
        private SimpleCommand _addRatingItemCommand;
        public SimpleCommand AddRatingItemCommand
        {
            get
            {
                if (_addRatingItemCommand == null)
                    _addRatingItemCommand = new SimpleCommand(async property =>
                {
                    //addRating
                });
                return _addRatingItemCommand;
            }
        }

        private SimpleCommand _addTaskItemCommand;
        public SimpleCommand AddTaskItemCommand
        {
            get
            {
                if (_addTaskItemCommand == null)
                    _addTaskItemCommand = new SimpleCommand(async property =>
                {
                    //addTask
                });
                return _addTaskItemCommand;
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

        private SimpleCommand _deleteTaskItemCommand;
        public SimpleCommand DeleteTaskItemCommand
        {
            get
            {
                if (_deleteTaskItemCommand == null)
                    _deleteTaskItemCommand = new SimpleCommand(async property =>
                {
                    await taskItem.Delete();
                });
                return _deleteTaskItemCommand;
            }
        }

        private SimpleCommand _rateTaskCommand;
        public SimpleCommand RateTaskCommand
        {
            get
            {
                if (_rateTaskCommand == null)
                {
                    _rateTaskCommand = new SimpleCommand(async parameter =>
                    {
                        int rating = (parameter as int?).Value;
                        await taskItem.AddRating(rating);
                    });
                }
                return _rateTaskCommand;
            }
        }
        #endregion

        public void LoadData()
        {
            foreach (var rating in taskItem.Ratings)
            {
                Ratings.Add(new RatingViewModel(rating));
            }
        }
    }
}
