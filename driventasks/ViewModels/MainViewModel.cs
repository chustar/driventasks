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
            TaskGroups = new ObservableCollection<TaskGroupViewModel>();
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

        private bool _isAddingNewTask = false;
        public bool IsAddingNewTask
        {
            get
            {
                return _isAddingNewTask;
            }
            set
            {
                _isAddingNewTask = value;
                NotifyPropertyChanged("IsAddingNewTask");
            }
        }

        public string NewTaskTitle { get; set; }
        public string NewTaskDescription { get; set; }

        public int NewTaskRating { get; set; }

        public ObservableCollection<TaskGroupViewModel> TaskGroups { get; set; }
       
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

        private SimpleCommand _toggleAddNewTaskCommand;
        public SimpleCommand ToggleAddNewTaskCommand
        {
            get
            {
                if (_toggleAddNewTaskCommand == null)
                {
                    _toggleAddNewTaskCommand = new SimpleCommand(async parameter =>
                    {
                        IsAddingNewTask = true;
                    });
                }
                return _toggleAddNewTaskCommand;
            }
        }
        
        private SimpleCommand _addNewTaskCommand;
        public SimpleCommand AddNewTaskCommand
        {
            get
            {
                if (_addNewTaskCommand == null)
                {
                    _addNewTaskCommand = new SimpleCommand(parameter =>
                    {
                        if (!NewTaskTitle.Equals(""))
                        {
                            TaskGroups.Add(new TaskGroupViewModel(new TaskGroup(new TaskItem(NewTaskTitle, NewTaskDescription, new Rating(NewTaskRating)))));
                        }
                    });
                }
                return _addNewTaskCommand;
            }
        }
    
        public async Task LoadData(int page = 0)
        {
            IsLoadingData = true;
            foreach (var taskGroup in await TaskGroup.FetchAll(page))
            {
                TaskGroups.Add(new TaskGroupViewModel(taskGroup));
            }

            IsLoadingData = false;
        }
    }
}
