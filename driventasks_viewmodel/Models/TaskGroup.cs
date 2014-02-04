using driventasks.Data;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace driventasks.Models
{
    class TaskGroup
    {
        public TaskGroup(TaskItem taskItem)
        {
            PrimaryTaskItem = taskItem;
            TaskItems = new ObservableCollection<TaskItem>();
            taskGroupsTable.InsertAsync(this);
        }

        public int Id { get; set; }
        
        [JsonProperty(PropertyName = "primarytaskitem", IsReference = true)]
        public TaskItem PrimaryTaskItem { get; set; }

        [JsonProperty(PropertyName = "taskitems", ItemIsReference = true)]
        public ObservableCollection<TaskItem> TaskItems {get; set; }
        
        public static async Task<ObservableCollection<TaskGroup>> FetchAll(int page)
        {
           return await taskGroupsTable
                .Where(taskGroupItem => taskGroupItem.PrimaryTaskItem.Deleted == null 
                    && taskGroupItem.PrimaryTaskItem.Completed == null)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                .ToCollectionAsync(20);
        }

        public async Task CompleteAll()
        {
            var completeList = new List<Task>();
            completeList.Add(PrimaryTaskItem.Complete());
            foreach (var taskItem in TaskItems)
            {
                completeList.Add(taskItem.Complete());
            }

            await Task.WhenAll(completeList);
        }

        public async Task UpdateAll()
        {
            var updateList = new List<Task>();
            updateList.Add(PrimaryTaskItem.Update());
            foreach (var taskItem in TaskItems)
            {
                updateList.Add(taskItem.Update());
            }

            await Task.WhenAll(updateList);
        }

        public async Task DeleteAll()
        {
            var deleteList = new List<Task>();
            deleteList.Add(PrimaryTaskItem.Delete());
            foreach (var taskItem in TaskItems)
            {
                deleteList.Add(taskItem.Delete());
            }

            await Task.WhenAll(deleteList);
        }

        private static int pageSize = 20;
        private static IMobileServiceTable<TaskGroup> taskGroupsTable = DataStorage.DrivenTasks.GetTable<TaskGroup>();
    }
}
