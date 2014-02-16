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

        /// <summary>
        /// Completes user authentication if it had been started.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string taskItemId = "";
            if (NavigationContext.QueryString.TryGetValue("taskItemId", out taskItemId))
            {
                DataContext = new TaskItemViewModel(taskItemId);
            }
            else
            {
                NavigationService.Navigate(new Uri("MainPage.xaml"));
            }
        }
    }
}