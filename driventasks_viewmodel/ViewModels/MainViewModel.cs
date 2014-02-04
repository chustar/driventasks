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

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
