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
    class MainViewModel : INotifyPropertyChanged
    {
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

        public async Task LoadData(int page = 0)
        {
            IsLoadingData = true;
            TaskGroups = await TaskGroup.FetchAll(page);
            IsLoadingData = false;
        }

        public ObservableCollection<TaskGroup> TaskGroups { get; set; }

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

        private SimpleCommand _updateTaskItemCommand;
        public SimpleCommand UpdateTaskItemCommand
        {
            get
            {
                if (_updateTaskItemCommand == null)
                    _updateTaskItemCommand = new SimpleCommand(async property =>
                {
                    var taskItem = property as TaskItem;
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
                    var taskItem = property as TaskItem;
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
                    var taskItem = property as TaskItem;
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
                    var taskItem = property as TaskItem;
                    await taskItem.Delete();
                });
                return _deleteTaskItemCommand;
            }
        }

        private SimpleCommand _completeTaskGroupCommand;
        public SimpleCommand CompleteTaskGroupCommand
        {
            get
            {
                if (_completeTaskGroupCommand == null)
                    _completeTaskGroupCommand = new SimpleCommand(async property =>
                {
                    var taskGroup = property as TaskGroup;
                    await taskGroup.CompleteAll();
                });
                return _deleteTaskItemCommand;
            }
        }
        
        private SimpleCommand _deleteTaskGroupCommand;
        public SimpleCommand DeleteTaskGroupCommand
        {
            get
            {
                if (_deleteTaskGroupCommand == null)
                    _deleteTaskGroupCommand = new SimpleCommand(async property =>
                {
                    var taskGroup = property as TaskGroup;
                    await taskGroup.DeleteAll();
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
                    _rateTaskCommand = new SimpleCommand(parameter =>
                    {
                        int rating = (parameter as int?).Value;
                        //How do I know both the Task and the Rating at this point?
                        //I might have to split this across multiple VMs.
                    });
                }
                return _rateTaskCommand;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
