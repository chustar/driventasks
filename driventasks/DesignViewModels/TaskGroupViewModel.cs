using System;
using System.Collections.ObjectModel;

namespace driventasks.DesignViewModels
{
    public class TaskGroupViewModel
    {
        public TaskGroupViewModel()
        {
            PrimaryTaskItemViewModel = new TaskItemViewModel("new titile primary " + new Random().Next(0, 100), "new primary description item longer description text yeaaa buddy");
            TaskItemViewModels = new ObservableCollection<TaskItemViewModel>();
            IsExpanded = false;
            LoadData();
        }

        public bool IsExpanded { get; set; }
        public TaskItemViewModel PrimaryTaskItemViewModel { get; set; }
        public ObservableCollection<TaskItemViewModel> TaskItemViewModels { get; set; }

        public void LoadData()
        {
            int count = 0;// new Random().Next(0, 5);
            for (int i = 0; i < count; i++)
            {
                TaskItemViewModels.Add(new TaskItemViewModel("new titile item " + i, new Random().Next(0, 2) == 1 ? "" : "new description item " + i + "longer description text yeaaa buddy"));
            }
        }
    }
}
