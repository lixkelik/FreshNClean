using KpopZtation.Controller;
using KpopZtation.Handler;
using KpopZtation.Model;
using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View
{
    public partial class home : System.Web.UI.Page
    {
        CategoryController artistController = new CategoryController();
        CustomerController custController = new CustomerController();
        public List<Category> categories;
        Customer cust;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                MasterPageFile = "~/View/Master/Guest.Master";
            }
            else
            {
                
                if (Session["user"] == null)
                {
                    int id = int.Parse(Request.Cookies["user_cookie"].Value);
                    cust = custController.GetCustomerById(id);
                    Session["user"] = cust;
                }
                else
                {
                    cust = (Customer)Session["user"];
                }

                if (cust.CustomerRole == "admin")
                {
                    MasterPageFile = "~/View/Master/Admin.Master";
                }
                else MasterPageFile = "~/View/Master/Customer.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataRebinding();
        }

        protected void DataRebinding()
        {
            categories = artistController.GetAllCategory();
        }


        protected void insertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CategoryFolder/insert_artist.aspx");
        }

        protected void service1Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CategoryFolder/detail_category.aspx?ID=" + categories[0].CategoryID);
        }

        protected void service2Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CategoryFolder/detail_category.aspx?ID=" + categories[1].CategoryID);
        }

        protected void service3Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CategoryFolder/detail_category.aspx?ID=" + categories[2].CategoryID);
        }

        protected void service4Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CategoryFolder/detail_category.aspx?ID=" + categories[3].CategoryID);
        }
    }
}