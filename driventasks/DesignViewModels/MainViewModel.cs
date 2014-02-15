using System.Collections.ObjectModel;

namespace driventasks.DesignViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            TaskItems = new ObservableCollection<TaskItemViewModel>();
            LoadData();
        }

        public bool IsLoadingData { get; set; }

        public bool IsAddingNewTask { get; set; }

        public string NewTaskTitle { get; set; }

        public string NewTaskDescription { get; set; }

        public int NewTaskRating { get; set; }

        public ObservableCollection<TaskItemViewModel> TaskItems { get; set; }
       
        public void LoadData()
        {
            TaskItems.Add(new TaskItemViewModel("fdk", "kdlad"));
            TaskItems.Add(new TaskItemViewModel("fdk", "kdlad"));
            TaskItems.Add(new TaskItemViewModel("fdk", "kdlad"));
            TaskItems.Add(new TaskItemViewModel("fdk", "kdlad"));
            TaskItems.Add(new TaskItemViewModel("fdk", "kdlad"));
        }
    }
}
