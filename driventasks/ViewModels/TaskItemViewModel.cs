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
        public TaskItemViewModel()
        {
        }

        public TaskItemViewModel(TaskItem taskItem)
        {
            this.taskItem = taskItem;

            Title = taskItem.Title;
            Description = taskItem.Description;
        }

        #region Reflected Properties
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

        public ObservableCollection<Rating> Ratings
        {
            get { return taskItem == null ? new ObservableCollection<Rating>() : taskItem.Ratings; }
        }
        #endregion

        public async Task LoadData(string id)
        {
            this.taskItem = await TaskItem.FetchById(id);
            Title = taskItem.Title;
            Description = taskItem.Description;
        }

        #region TaskItemViewModel Commands
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
        #endregion
        }
    }
}
