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
    class MainViewModel : BindableBase
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
