using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace eShopee2.Product
{
    public partial class Add_Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            Classes.Product objProduct = new Classes.Product();

            SqlDataReader categoryData = objProduct.getParentCategoies();

            if (categoryData == null)
                return;

            while (categoryData.Read())
            {
                ListItem categoryItem = new ListItem(categoryData["name"].ToString(), categoryData["id"].ToString());
                lstCategory.Items.Add(categoryItem);

                Classes.Product objProductB = new Classes.Product();
                SqlDataReader childCategory = objProductB.getChildCategories(Convert.ToInt32(categoryData["id"]));

                if (childCategory != null)
                    while (childCategory.Read())
                    {
                        categoryItem = new ListItem("!_"+childCategory["name"].ToString(), childCategory["id"].ToString());
                        lstCategory.Items.Add(categoryItem);
                    }

                objProductB.close();
            }

            objProduct.close();


        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.ToString();
            string excerpt = txtExcerpt.Text.ToString();
            string description = txtDescription.Text.ToString();
            int cost = Convert.ToInt32(txtCost.Text);
            string inStock = radInStock.SelectedValue;
            string featured = radFeatured.SelectedValue;
            string status = radStatus.SelectedValue;

            string[] allowedExtensions = { ".JPG", ".PNG" };
            string imageExtension = Path.GetExtension(fileImage.PostedFile.FileName).ToUpper();
            
            bool error = false;

            if (!allowedExtensions.Contains(imageExtension))
            {
                error = true;
                litError.Text = "Invalid Image Provided";
            }

            if (error)
                return;


            string image = Guid.NewGuid().ToString() + imageExtension;

            string uploadDirectory = Path.Combine(Request.PhysicalApplicationPath, "uploads");
            string uploadedFile = Path.Combine(uploadDirectory, image);
            
            fileImage.PostedFile.SaveAs(uploadedFile);

            Classes.Product objProduct = new Classes.Product();

            if (objProduct.addProduct(name, excerpt, description, cost, inStock, featured, status, image))
            {
                litError.Text = "Product Added Successfully";

                int productId = objProduct.getProductIdByName(name);

                foreach (ListItem category in lstCategory.Items)
                {
                    if (category.Selected)
                        objProduct.mapProductToCategory(productId, Convert.ToInt32(category.Value));        
                }
            }                    

            





            
        }
    }
}