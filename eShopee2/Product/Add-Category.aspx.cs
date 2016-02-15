using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eShopee2.Product
{
    public partial class Add_Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.Auth objAuth = new Classes.Auth();
            objAuth.isAdmin();

            if (IsPostBack)
                return;

            Classes.Product objProduct = new Classes.Product();

            SqlDataReader categoryData= objProduct.getParentCategoies();

            if (categoryData == null)
                return;

            while (categoryData.Read())
            { 
                ListItem categoryItem = new ListItem(categoryData["name"].ToString(), categoryData["id"].ToString());
                lstParent.Items.Add(categoryItem);
            }


        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            Classes.Product objProduct = new Classes.Product();

            string name = txtName.Text.ToString();
            string description = txtDescription.Text.ToString();
            int parent = Convert.ToInt32(lstParent.SelectedValue);

            if (objProduct.addCategory(name, description, parent))
            {
                litError.Text = "Category Addedd Successfully";
            }                    

        }
    }
}