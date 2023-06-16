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
        ArtistController artistController = new ArtistController();
        CustomerController custController = new CustomerController();
        public List<Artist> artist;
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
            artist = artistController.GetAllArtist();
        }


        protected void insertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ArtistFolder/insert_artist.aspx");
        }

        protected void service1Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ArtistFolder/detail_artist.aspx?ID=" + artist[0].ArtistID);
        }

        protected void service2Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ArtistFolder/detail_artist.aspx?ID=" + artist[1].ArtistID);
        }

        protected void service3Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ArtistFolder/detail_artist.aspx?ID=" + artist[2].ArtistID);
        }

        protected void service4Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ArtistFolder/detail_artist.aspx?ID=" + artist[3].ArtistID);
        }
    }
}