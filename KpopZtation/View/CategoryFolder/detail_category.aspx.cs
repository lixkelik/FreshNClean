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

namespace KpopZtation.View.CategoryFolder
{
    public partial class detail_category : System.Web.UI.Page
    {
        ServiceController serviceController = new ServiceController();
        CategoryController categoryController = new CategoryController();

        Customer cust;
        protected Category category;
        int categoryId;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            CustomerController custController = new CustomerController();

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

                if (cust.CustomerRole == "admin") MasterPageFile = "~/View/Master/Admin.Master";
                else MasterPageFile = "~/View/Master/Customer.Master"; ;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ID"] == null)
            {
                Response.Redirect("~/View/home.aspx");
            }
            categoryId = int.Parse(Request["ID"]);
            if (!IsPostBack)
            {
                if (cust != null)
                {
                    if (cust.CustomerRole == "admin")
                    {
                        insertBtn.Visible = true;
                        insertLbl.Visible = true;
                    }
                }
                
                category = categoryController.GetCategoryById(categoryId);

                categoryName.Text = $"Category: {category.CategoryName}";

                DataRebinding();
            } 
        }


        void DataRebinding()
        {
            List<Service> categoryService = serviceController.GetAllCategoryService(categoryId);
            if (categoryService.Count == 0)
            {
                isEmptyLbl.Visible = true;
            }
            albumGrid.DataSource = categoryService;
            albumGrid.DataBind();
        }

        protected void albumGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (cust == null || cust.CustomerRole == "Cust")
            {
                e.Row.Cells[5].Visible = false;
            }
            else if (cust.CustomerRole == "admin")
            {
                e.Row.Cells[5].Visible = true;
            }
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            categoryId = int.Parse(Request["ID"]);
            Response.Redirect("~/View/ServiceFolder/insert_service.aspx?ID=" + categoryId);
        }

        protected void albumGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = albumGrid.Rows[e.RowIndex];
            int id = int.Parse(row.Cells[1].Text);
            string response = serviceController.DeleteService(id);

            errorLbl.Text = response;
            DataRebinding();
        }

        protected void albumGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = albumGrid.Rows[e.NewEditIndex];

            int id = int.Parse(row.Cells[1].Text);
            categoryId = int.Parse(Request["ID"]);
            Response.Redirect("~/View/ServiceFolder/edit_service.aspx?ID=" + id+"&categoryID="+categoryId);
        }

        protected void albumGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = albumGrid.SelectedRow;

            int id = int.Parse(row.Cells[0].Text);
            Response.Redirect("~/View/ServiceFolder/detail_service.aspx?ID=" + id);
        }
    }
}