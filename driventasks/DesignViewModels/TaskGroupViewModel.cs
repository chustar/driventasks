﻿using System;
using System.Collections.ObjectModel;

namespace driventasks.DesignViewModels
{
    public class TaskGroupViewModel
    {
        public TaskGroupViewModel()
        {
            LoadData();
        }

        public TaskItemViewModel PrimaryTaskItemViewModel { get; set; }
        public ObservableCollection<TaskItemViewModel> TaskItemViewModels { get; set; }

        public void LoadData()
        {
            PrimaryTaskItemViewModel = new TaskItemViewModel("lfajdkfla;", "sldfjkadlf");
            int count = new Random().Next(0, 5);
            for (int i = 0; i < count; i++)
            {
                TaskItemViewModels.Add(new TaskItemViewModel("new titile item " + i, new Random().Next(0, 1) == 0 ? "" : "new description item " + i + "longer description text yeaaa buddy"));
            }
        }
    }
}
