using KpopZtation.Handler;
using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Controller
{
    public class ServiceController
    {
        ServiceHandler serviceHandler = new ServiceHandler();
        private String CheckName(string name)
        {
            if(name == null || name == "") return "Service name must be filled!";
            if (name.Length > 50) return "Service name must be < 50 character";
            return "";
        }

        private String CheckDesc(string desc)
        {
            if (desc == null || desc == "") return "Description must be filled!";
            if (desc.Length > 255) return "Description must be < 255 character";
            return "";
        }

        private String CheckPrice(int price)
        {
            if (price == 0) return "Price must be filled!";
            if (price < 100000 || price > 1000000) return "Price must be > 100000 and < 1000000";
            return "";
        }

        public String CheckPrice(string price)
        {
            if (price == null || price == "") return "Price must be filled!";
            return "";
        }

        public String CheckInsertService(int categoryId, string name, string desc, string price)
        {
            int cPrice = 0;
            string response = CheckName(name);
            if (response == "") response = CheckDesc(desc);
            if(response == "")
            {
                response = CheckPrice(price);
                if(response == "")
                {
                    cPrice = int.Parse(price);
                }
                else
                {
                    return response;
                }
            }
            if (response == "") response = CheckPrice(cPrice);
            if (response == "")
            {
                response = serviceHandler.InsertService(categoryId, name, desc, cPrice);
                if (response == "success") return "success";
                else if (response == "category not found") return "Category not found!";
                else return "Failed, please try again later!";
            }
            return response;
        }

        public String CheckUpdateService(int serviceId, string name, string desc, string price)
        {
            int cPrice = 0;
            string response = CheckName(name);
            if (response == "") response = CheckDesc(desc);
            if (response == "")
            {
                response = CheckPrice(price);
                if (response == "")
                {
                    cPrice = int.Parse(price);
                }
                else
                {
                    return response;
                }
            }
            if (response == "") response = CheckPrice(cPrice);
            if (response == "")
            {
                response = serviceHandler.UpdateService(serviceId, name, desc, cPrice);
                if (response == "success") return "success";
                else if (response == "service not found") return "Service not found!";
                else return "Failed, please try again later!";
            }
            return response;
        }

        public String DeleteService(int id)
        {
            string response = serviceHandler.DeleteService(id);

            if (response == "not found") return "No service found!";
            if (response == "failed") return "Failed to delete! Please try again";
            return "Service Deleted!";

        }

        public List<Service> GetAllCategoryService(int categoryId)
        {
            return serviceHandler.GetAllCategoryService(categoryId);
        }

        public Service GetServiceById(int serviceId)
        {
            return serviceHandler.GetServiceById(serviceId);
        }

    }
}