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
        CategoryController categoryController = new CategoryController();
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
            ShowCategoryList();
        }

        protected void DataRebinding()
        {
            categories = categoryController.GetAllCategory();
        }

        protected void ShowCategoryList()
        {
            TableRow row = null;

            for (int i = 0; i < categories.Count; i++)
            {
                if (i % 4 == 0)
                {
                    row = new TableRow();
                    row.Style["display"] = "flex";
                    row.Style["flex-wrap"] = "wrap";
                    row.Style["flex-direction"] = "row";
                    row.Style["justify-content"] = "center";
                    row.Style["gap"] = "80px";
                    row.Style["margin-top"] = "43px";
                    row.Style["margin-bottom"] = "43px";
                    categoriesTable.Rows.Add(row);
                }

                TableCell categoryCell = new TableCell();
                categoryCell.Style["text-align"] = "center";
                categoryCell.Style["background-color"] = "#EDFCFF";
                categoryCell.Style["width"] = "240px";
                categoryCell.Style["height"] = "253px";
                categoryCell.Style["border-radius"] = "20px";
                categoryCell.Style["display"] = "flex";
                categoryCell.Style["flex-direction"] = "column";
                categoryCell.Style["align-items"] = "center";
                categoryCell.Style["justify-content"] = "center";
                categoryCell.Style["gap"] = "30px";

                Image categoryImage = new Image();
                categoryImage.ImageUrl = "~/Assets/CategoryImages/" + categories[i].CategoryImages;
                categoryImage.Style["width"] = "113px";
                categoryImage.Style["height"] = "113px";
                categoryImage.Style["object-fit"] = "cover";
                categoryImage.CssClass = "categoryImg";
                categoryCell.Controls.Add(categoryImage);

                Panel container = new Panel();
                container.CssClass = "categoryNameCtn";

                Button checkDetailsButton = new Button();
                checkDetailsButton.Text = categories[i].CategoryName;
                checkDetailsButton.Style["color"] = "#689E99";
                checkDetailsButton.Style["font-family"] = "'Lato', sans-serif";
                checkDetailsButton.Style["font-weight"] = "700px";
                checkDetailsButton.Style["font-size"] = "30px";
                checkDetailsButton.Style["width"] = "187px";
                checkDetailsButton.Style["border"] = "2px solid #689E99";
                checkDetailsButton.Style["border-radius"] = "30px";
                checkDetailsButton.Style["background-color"] = "#FFFFFF";
                checkDetailsButton.CssClass = "checkDetails btn";
                checkDetailsButton.CommandArgument = categories[i].CategoryID.ToString();
                checkDetailsButton.Command += CheckDetails_OnClick;
                container.Controls.Add(checkDetailsButton);

                categoryCell.Controls.Add(container);
                row.Cells.Add(categoryCell);
            }
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CategoryFolder/insert_artist.aspx");
        }

        protected void CheckDetails_OnClick(object sender, CommandEventArgs e)
        {
            int categoryId = int.Parse(e.CommandArgument.ToString());
            Response.Redirect("~/View/CategoryFolder/detail_category.aspx?ID=" + categoryId);
        }
    }
}