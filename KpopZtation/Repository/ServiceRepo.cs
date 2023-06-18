using KpopZtation.Factory;
using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Repository
{
    public class ServiceRepo
    {
        DatabaseEntities7 db = Database.getDb();

        public int ServiceCountByCategory(int categoryId)
        {
            int totalService = (from service in db.Services where service.CategoryID == categoryId select service).ToList().Count();
            return totalService;
        }

        public List<Service> GetServiceByCategoryId(int categoryId)
        {
            return (from service in db.Services where service.CategoryID == categoryId select service).ToList();
        }

        public Service GetServiceById(int serviceId)
        {
            return (from service in db.Services where service.ServiceID == serviceId select service).ToList().LastOrDefault();
        }

        public int InsertService(int categoryId, string name, string desc, int price)
        {
            Service service = ServiceFactory.createService(categoryId, name, price, desc);

            db.Services.Add(service);
            return db.SaveChanges();
        }

        public int UpdateService(int serviceId, string name, string desc, int price)
        {
            Service service = GetServiceById(serviceId);

            service.ServiceName = name;
            service.ServiceDescription = desc;
            service.ServicePrice = price;

            return db.SaveChanges();
        }
        public void RemoveServiceList(List<Service> serviceList)
        {
            db.Services.RemoveRange(serviceList);
            db.SaveChanges();
        }

        public int DeleteService(int serviceId)
        {
            Service service = GetServiceById(serviceId);

            db.Services.Remove(service);
            return db.SaveChanges();
        }
    }
}