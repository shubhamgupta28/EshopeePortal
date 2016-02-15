using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace eShopee2
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.Database objDB = new Classes.Database();

            SqlDataReader allProducts = objDB.getData("select top 10 * from products where status='active'");

            if (allProducts != null)
            {
                HtmlTable myTable = new HtmlTable();

                while (allProducts.Read())
                {
                    HtmlTableRow myRow = new HtmlTableRow();
                    myTable.Rows.Add(myRow);

                    HtmlTableCell myCell = new HtmlTableCell();
                    myCell.InnerText = "";

                    if (allProducts["image"].ToString() != null)
                    {
                        HtmlImage profilePic = new HtmlImage();
                        profilePic.Height = 50;
                        profilePic.Width = 50;
                        profilePic.Src = "http://" + Request.Url.Authority + "/uploads/" + allProducts["image"].ToString();
                        myCell.Controls.Add(profilePic);
                    }
                    myRow.Cells.Add(myCell);

                    myCell = new HtmlTableCell();
                    myCell.InnerHtml = "<b><u><a href=Product/View-Product.aspx?id=" + allProducts["ID"] + " >" + allProducts["name"].ToString() + "</a></u></b><br>"
                                        + allProducts["description"].ToString();

                    myRow.Cells.Add(myCell);
                }

                objDB.close();
                pnlProduct.Controls.Add(myTable);

            }
        }
    }
}
