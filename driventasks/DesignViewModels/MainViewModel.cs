using System.Collections.ObjectModel;
using DesignTimeBuddy;

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

        public ObservableCollection<TaskItemViewModel> TaskItems { get; set; }
       
        public void LoadData()
        {
            TaskItems.Add(new TaskItemViewModel(DesignTimeBuddy.DeisgnTimeBuddy.GetSimpleString(3), DeisgnTimeBuddy.GetSimpleString()));
            TaskItems.Add(new TaskItemViewModel(DesignTimeBuddy.DeisgnTimeBuddy.GetSimpleString(3), DeisgnTimeBuddy.GetSimpleString()));
            TaskItems.Add(new TaskItemViewModel(DesignTimeBuddy.DeisgnTimeBuddy.GetSimpleString(3), DeisgnTimeBuddy.GetSimpleString()));
            TaskItems.Add(new TaskItemViewModel(DesignTimeBuddy.DeisgnTimeBuddy.GetSimpleString(3), DeisgnTimeBuddy.GetSimpleString()));
            TaskItems.Add(new TaskItemViewModel(DesignTimeBuddy.DeisgnTimeBuddy.GetSimpleString(3), DeisgnTimeBuddy.GetSimpleString()));
            TaskItems.Add(new TaskItemViewModel(DesignTimeBuddy.DeisgnTimeBuddy.GetSimpleString(3), DeisgnTimeBuddy.GetSimpleString()));
        }
    }
}
