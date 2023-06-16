using KpopZtation.Model;
using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Handler
{
    public class ServiceHandler
    {
        ServiceRepo serviceRepo = new ServiceRepo();
        CategoryRepo categoryRepo = new CategoryRepo();

        public Service GetServiceById(int id)
        {
            Service service = serviceRepo.GetServiceById(id);
            return service;
        }

        public List<Service> GetAllCategoryService(int categoryId)
        {
            return serviceRepo.GetServiceByCategoryId(categoryId);
        }

        public String InsertService(int categoryId, string name, string desc, int price)
        {
            Category category = categoryRepo.FindCategoryById(categoryId);

            if (category == null) return "category not found";

            int response = serviceRepo.InsertService(categoryId, name, desc, price);
            if (response > 0) return "success";
            else return "failed";
        }

        public String UpdateService(int serviceId, string name, string desc, int price)
        {
            Service service = serviceRepo.GetServiceById(serviceId);

            if (service == null) return "service not found";

            int response = serviceRepo.UpdateService(serviceId, name, desc, price);

            if (response > 0) return "success";
            return "failed";
        }

        public String DeleteService(int serviceId)
        {
            Service service = serviceRepo.GetServiceById(serviceId);

            if (service == null) return "not found";
            else
            {
                int response = serviceRepo.DeleteService(serviceId);
                if (response > 0) return "success";
                return "failed";
            }
        }

    }
}