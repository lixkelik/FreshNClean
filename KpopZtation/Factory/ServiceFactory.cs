using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Factory
{
    public class ServiceFactory
    {
        public static Service createService(int categoryID, string name, int price, string desc)
        {
            Service service = new Service();
            service.CategoryID= categoryID;
            service.ServiceName = name;
            service.ServicePrice = price;
            service.ServiceDescription = desc;

            return service;
        }
    }
}