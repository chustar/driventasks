using System.Collections.ObjectModel;

namespace driventasks.DesignViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            TaskGroups = new ObservableCollection<TaskGroupViewModel>();
            LoadData();
        }

        public bool IsLoadingData { get; set; }

        public bool IsAddingNewTask { get; set; }

        public string NewTaskTitle { get; set; }
        public string NewTaskDescription { get; set; }

        public int NewTaskRating { get; set; }

        public ObservableCollection<TaskGroupViewModel> TaskGroups { get; set; }
       
        public void LoadData()
        {
            TaskGroups.Add(new TaskGroupViewModel());
            TaskGroups.Add(new TaskGroupViewModel());
            TaskGroups.Add(new TaskGroupViewModel());
            TaskGroups.Add(new TaskGroupViewModel());
            TaskGroups.Add(new TaskGroupViewModel());
        }
    }
}
