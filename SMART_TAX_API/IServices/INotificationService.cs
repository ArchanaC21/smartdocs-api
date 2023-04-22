using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.IServices
{
    public interface INotificationService
    {
        Response<List<NOTIFICATION>> notificationList();
        Response<int> GetNotificationCount();
        Response<NOTIFICATION> GetNotificationDetails(int ID);
        Response<string> ChangeNotificationStatus(int ID);
    }
}
