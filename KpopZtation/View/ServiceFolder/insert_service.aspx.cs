using KpopZtation.Controller;
using KpopZtation.Model;
using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View.AlbumFolder
{
    public partial class insert_service : System.Web.UI.Page
    {
        ServiceController serviceController = new ServiceController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            CustomerRepo custRepo = new CustomerRepo();

            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/View/home.aspx");
            }
            else
            {
                Customer cust;
                if (Session["user"] == null)
                {
                    int id = int.Parse(Request.Cookies["user_cookie"].Value);
                    cust = custRepo.GetCustomerById(id);
                    Session["user"] = cust;
                }
                else
                {
                    cust = (Customer)Session["user"];
                }

                if (cust.CustomerRole == "admin") MasterPageFile = "~/View/Master/Admin.Master";
                else Response.Redirect("~/View/home.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            errorLbl.Visible = true;
            if (string.IsNullOrEmpty(priceTbx.Text))
            {
                errorLbl.Text = "Please enter a value";
            }
            string name = nameTbx.Text.Trim();
            string desc = descTbx.Text.Trim();
            string price = priceTbx.Text;

            string response;

            if(Request["ID"] == null)
            {
                Response.Redirect("~/View/home.aspx");
            }

            int categoryId = int.Parse(Request["ID"]);
               
            response = serviceController.CheckInsertService(categoryId, name, desc, price);

            if (response == "success") Response.Redirect("~/View/ArtistFolder/detail_artist.aspx?ID=" + categoryId);
            else errorLbl.Text = response;
        }
    }
}