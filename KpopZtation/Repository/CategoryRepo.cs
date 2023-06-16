using KpopZtation.Factory;
using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Repository
{
    public class CategoryRepo
    {
        DatabaseEntities db = Database.getDb();

        public Category FindCategoryById(int id)
        {
            return (from c in db.Categories where c.CategoryID == id select c).ToList().FirstOrDefault();
        }

        public Category FindCategoryByName(String name)
        {
            return (from c in db.Categories where c.CategoryName == name select c).ToList().FirstOrDefault();
        }


        public List<Category> GetAllCategory()
        {
            return (from c in db.Categories select c).ToList();
        }

        public int InsertCategory(string name)
        {
            Category category = CategoryFactory.createCategory(name);
            db.Categories.Add(category);

            return db.SaveChanges();
        }

    }
}