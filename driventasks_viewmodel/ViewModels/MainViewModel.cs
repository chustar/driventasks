﻿using driventasks_viewmodel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace driventasks_viewmodel.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            TaskGroups = new ObservableCollection<TaskGroup>();
        }

        private bool _syncState;
        public bool SyncState
        {
            get
            {
                return _syncState;
            }
            set
            {
                _syncState = value;
                NotifyPropertyChanged("SyncState");
            }
        }
        public ObservableCollection<TaskGroup> TaskGroups { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
