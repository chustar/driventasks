using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace driventasks_viewmodel.Models
{
    class TaskGroup
    {
        public TaskGroup(TaskItem taskItem)
        {
            PrimaryTaskItem = taskItem;
            TaskItems = new ObservableCollection<TaskItem>();
        }

        public TaskItem PrimaryTaskItem { get; set; }
        public ObservableCollection<TaskItem> TaskItems {get; set; }
    }
}
