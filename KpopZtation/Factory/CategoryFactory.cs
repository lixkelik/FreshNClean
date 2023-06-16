using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Factory
{
    public class CategoryFactory
    {
        public static Category createCategory(string categoryName)
        {
            Category category = new Category();
            category.CategoryName = categoryName;

            return category;
        }
    }
}