using KpopZtation.Controller;
using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View.ServiceFolder
{
    public partial class detail_service : System.Web.UI.Page
    {
        ServiceController serviceController = new ServiceController();
        CartController cartController = new CartController();

        Customer cust;
        Service service;
        int serviceId;

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
            serviceId = int.Parse(Request["ID"]);

            if (!IsPostBack)
            {
                if (cust != null)
                {
                    if (cust.CustomerRole == "Cust")
                    {
                        addToCartBtn.Visible = true;
                        stockTbx.Visible = true;
                    }
                }

                service = serviceController.GetServiceById(serviceId);

                albumNameLbl.Text = $"Service name: {service.ServiceName}";
                descLbl.Text = $"Description:\n{service.ServiceDescription}";
                priceLbl.Text = $"Price: {service.ServicePrice}";
                albumImg.ImageUrl = "~/Assets/logo.png";
            }
        }

        protected void addToCartBtn_Click(object sender, EventArgs e)
        {
            string qty = stockTbx.Text;

            string response = cartController.AddAlbumToCart(serviceId, qty, cust.CustomerID);
            errorLbl.Text = response;
        }
    }
}