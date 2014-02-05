using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using driventasks.Models;
using System.Collections.ObjectModel;
using driventasks.Utilities;

namespace driventasks.ViewModels
{
    class TaskGroupViewModel
    {
        public TaskGroupViewModel(TaskGroup taskGroup)
        {
            this.taskGroup = taskGroup;
            LoadData();
        }
       
        public ObservableCollection<TaskItemViewModel> TaskItemViewModels {get; set; }
        
        private SimpleCommand _completeTaskGroupCommand;
        public SimpleCommand CompleteTaskGroupCommand
        {
            get
            {
                if (_completeTaskGroupCommand == null)
                    _completeTaskGroupCommand = new SimpleCommand(async property =>
                {
                    await taskGroup.CompleteAll();
                });
                return _deleteTaskGroupCommand;
            }
        }
        
        private SimpleCommand _deleteTaskGroupCommand;
        public SimpleCommand DeleteTaskGroupCommand
        {
            get
            {
                if (_deleteTaskGroupCommand == null)
                    _deleteTaskGroupCommand = new SimpleCommand(async property =>
                {
                    await taskGroup.DeleteAll();
                });
                return _deleteTaskGroupCommand;
            }
        }

        public void LoadData()
        {
            foreach(TaskItem taskItem in taskGroup.TaskItems)
            {
                TaskItemViewModels.Add(new TaskItemViewModel(taskItem));
            }
        }
        
        private TaskGroup taskGroup;
    }
}
