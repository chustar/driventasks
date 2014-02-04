using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace driventasks.Data
{
    internal class DataStorage
    {
        public static MobileServiceClient DrivenTasks = new MobileServiceClient(
            "https://driventasks.azure-mobile.net/",
            "");
    }
}
