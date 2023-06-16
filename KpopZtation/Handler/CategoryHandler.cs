using KpopZtation.Model;
using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Handler
{
    public class CategoryHandler
    {
        CategoryRepo categoryRepo = new CategoryRepo();
        ServiceRepo serviceRepo = new ServiceRepo();


        public string InsertCategory(string categoryName)
        {
            Category category = categoryRepo.FindCategoryByName(categoryName);

            if (category != null) return "duplicate";

            // status > 0 == success, status == 0 failed
            int status = categoryRepo.InsertCategory(categoryName);
            if (status > 0) return "success";
            else return "failed";
        }

        public Category GetCategoryById(int id)
        {
            return categoryRepo.FindCategoryById(id);
        }

        public List<Category> GetAllCategory()
        {
            return categoryRepo.GetAllCategory();
        }
    }
}