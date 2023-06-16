using KpopZtation.Handler;
using KpopZtation.Model;
using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Controller
{
    public class CategoryController
    {
        CategoryHandler categoryHandler = new CategoryHandler();


        public String CheckInsertCategory(string name)
        {
            if (name == null || name == "") return "Category name must be filled!";

            string response = categoryHandler.InsertCategory(name);

            return CheckReturnString(response);
        }

        public String CheckReturnString(string response)
        {
            if (response == "success") return "success";
            else if (response == "duplicate") return "Category name duplicated! Input unique name!";
            else return "Failed, please try again!";
        }
        public Category GetCategoryById(int id)
        {
            return categoryHandler.GetCategoryById(id);
        }

        public List<Category> GetAllCategory()
        {
            return categoryHandler.GetAllCategory();
        }


    }
}