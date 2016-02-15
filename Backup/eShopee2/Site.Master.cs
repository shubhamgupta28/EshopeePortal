using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eShopee2
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                Classes.Product objProduct = new Classes.Product();

                SqlDataReader categoryData = objProduct.getParentCategoies();

                if (categoryData == null)
                    return;

                while (categoryData.Read())
                {
                    MenuItem categoryItem = new MenuItem(categoryData["name"].ToString(), "", "", "~/Product/View-Product.aspx?category=" + Convert.ToInt32(categoryData["id"]));

                    Classes.Product objProductB = new Classes.Product();
                    SqlDataReader childCategory = objProductB.getChildCategories(Convert.ToInt32(categoryData["id"]));

                    if (childCategory != null)
                        while (childCategory.Read())
                        {
                            categoryItem.ChildItems.Add(new MenuItem(childCategory["name"].ToString(), "", "", "~/Product/View-Product.aspx?category=" + Convert.ToInt32(childCategory["id"])));  
                        }

                    objProductB.close();

                    NavigationMenu.Items.Add(categoryItem);
                }


                if (Session["loggedIn"] == "true")
                {
                    NavigationMenu.Items.Add(accountProfile());
                }

                if (Session["role"] == "Admin")
                {
                    NavigationMenu.Items.Add(productMenu());
                }

                objProduct.close();
            
        }

        private MenuItem accountProfile()
        {
            MenuItem parentItem = new MenuItem("My Profile", "", "", "#");

            parentItem.ChildItems.Add(new MenuItem("View Profile", "", "", "~/Account/View-Profile.aspx"));
            parentItem.ChildItems.Add(new MenuItem("Edit Profile", "", "", "~/Account/Edit-Profile.aspx"));
            parentItem.ChildItems.Add(new MenuItem("Change Password", "", "", "~/Account/Change-Password.aspx"));
            parentItem.ChildItems.Add(new MenuItem("Logout", "", "", "~/Account/Logout.aspx"));

            return parentItem;
        }

        private MenuItem productMenu()
        {
            MenuItem parentItem = new MenuItem("Products", "", "", "#");

            parentItem.ChildItems.Add(new MenuItem("Add Product", "", "", "~/Product/Add-Product.aspx"));
            parentItem.ChildItems.Add(new MenuItem("Add Category", "", "", "~/Product/Add-Category.aspx"));
            parentItem.ChildItems.Add(new MenuItem("All Products", "", "", "~/Product/View-All-Products.aspx"));
           
            return parentItem;
        }

        

    }
}
