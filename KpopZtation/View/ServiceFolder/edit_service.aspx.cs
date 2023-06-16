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

namespace KpopZtation.View.AlbumFolder
{
    public partial class edit_album : System.Web.UI.Page
    {
        ServiceHandler serviceHandler = new ServiceHandler();
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
            if (Request["ID"] == null)
            {
                Response.Redirect("~/View/home.aspx");
            }

            int id = int.Parse(Request["ID"]);
            
            if (!IsPostBack)
            {
                Service service = serviceHandler.GetServiceById(id);
                nameTbx.Text = service.ServiceName;
                descTbx.Text = service.ServiceDescription;
                priceTbx.Text = service.ServicePrice.ToString();
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            string name = nameTbx.Text.Trim();
            string desc = descTbx.Text.Trim();
            string price = priceTbx.Text;

            string response = "";

            int serviceId = int.Parse(Request["ID"]);
            int categoryId = int.Parse(Request["categoryID"]);
            
            response = serviceController.CheckUpdateService(serviceId, name, desc, price);

            if (response == "success") Response.Redirect("~/View/ArtistFolder/detail_category.aspx?ID=" + categoryId);
            else
            {
                errorLbl.Visible = true;
                errorLbl.Text = response;
            }
        }
    }
}