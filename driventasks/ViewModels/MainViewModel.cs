using driventasks.Data;
using driventasks.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using driventasks.Utilities;

namespace driventasks.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
        {
            TaskItems = new ObservableCollection<TaskItemViewModel>();
        }

        private bool _isLoadingData = false;
        public bool IsLoadingData
        {
            get
            {
                return _isLoadingData;
            }
            set
            {
                _isLoadingData = value;
                NotifyPropertyChanged("IsLoadingData");
            }
        }

        public TaskItemViewModel NewTaskItem { get; set; }

        public ObservableCollection<TaskItemViewModel> TaskItems { get; set; }
       
        private SimpleCommand _refreshCommand;
        public SimpleCommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                {
                    _refreshCommand = new SimpleCommand(async parameter =>
                    {
                        await LoadData();
                    });
                }
                return _refreshCommand;
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
                    await NewTaskItem.SaveData();
                    NewTaskItem.AddRatingCommand.Execute(null);
                });
                return _addTaskItemCommand;
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
                    var taskItem = property as TaskItemViewModel;
                    await taskItem.DeleteData();
                    TaskItems.Remove(taskItem);
                });
                return _deleteTaskItemCommand;
            }
        }

        public async Task LoadData(int page = 0)
        {
            IsLoadingData = true;
            foreach (var taskItem in await TaskItem.FetchAll(page))
            {
                var taskItemViewModel = new TaskItemViewModel(taskItem);
                TaskItems.Add(taskItemViewModel);
            }

            IsLoadingData = false;
        }
    }
}
