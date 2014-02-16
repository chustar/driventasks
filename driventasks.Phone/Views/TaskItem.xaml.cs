using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using driventasks.ViewModels;

namespace driventasks.Views
{
    public partial class TaskItem : PhoneApplicationPage
    {
        public TaskItem()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            string taskItemId = "";
            if (NavigationContext.QueryString.TryGetValue("taskItemId", out taskItemId))
            {
                var taskItemViewModel = new TaskItemViewModel();
                var task = taskItemViewModel.LoadData(taskItemId);
                await task;

                DataContext = taskItemViewModel;
            }
            else
            {
                NavigationService.Navigate(new Uri("MainPage.xaml"));
            }
        }
    }
}