using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace eShopee2.Classes
{
    public class Product: Database
    {
        public bool addProduct(string name, string excerpt, string description, int cost, string instock, string featured, string status, string image)
        {
            int effectedRows = setData("insert into products (name, excerpt, description, cost, instock, featured, status, image) values('"+name+"', '"+excerpt+"', '"+description+"', "+cost+", '"+instock+"', '"+featured+"', '"+status+"', '"+image+"')");

            if (effectedRows == 1)
                return true;

            return false;
        }

        public bool addCategory(string name, string description, int parent = 0)
        {
            int effectedRows = setData("insert into categories (name, description, parent) values('" + name + "', '" + description + "', "+parent+")");

            if (effectedRows == 1)
                return true;

            return false;
        }

        public bool mapProductToCategory(int productId, int categoryId)
        {
            int effectedRows = setData("insert into product_category (productId, categoryId) values(" + productId + ", "+categoryId+")");

            if (effectedRows == 1)
                return true;

            return false;
        }

        public bool unmapProductFromCategory(int productId, int categoryId=0)
        {
            string query = "delete from product_category where productId="+productId;

            if (categoryId != 0)
                query += " and categoryId="+categoryId;

            int effectedRows = setData(query);

            if (effectedRows > 0)
                return true;

            return false;
        }

        public SqlDataReader getProductsByCategory(int categoryId)
        {
            SqlDataReader dataSet = getData("select productId from product_category where categoryId="+categoryId);

            if (dataSet.HasRows)
                return dataSet;

            return null;
        }

        public SqlDataReader getCategoryByProduct(int productId)
        {
            SqlDataReader dataSet = getData("select categoryId from product_category where productId=" + productId);

            if (dataSet.HasRows)
                return dataSet;

            return null;
        }

        public SqlDataReader getProduct(string query)
        {
            string dbQuery = "select * from products where " + query;

            SqlDataReader dataSet = getData(dbQuery);

            if (dataSet.HasRows)
                return dataSet;

            return null;
        }

        public int getProductIdByName(string name)
        {
            string dbQuery = "select id from products where name='"+name+"'";

            SqlDataReader dataSet = getData(dbQuery);

            if (dataSet.HasRows)
            {
                dataSet.Read();
                int id = Convert.ToInt32(dataSet["id"]);
                dataSet.Close();
                return id;
            }

            return 0;
        }
        public SqlDataReader getCategory(string query)
        {
            SqlDataReader dataSet = getData("select * from categories where " + query);

            if (dataSet.HasRows)
                return dataSet;

            return null;
        }

        public SqlDataReader getParentCategoies()
        {
            SqlDataReader dataSet = getData("select * from categories where parent=0");
            return dataSet;
        }

        public SqlDataReader getChildCategories(int parent)
        {
            SqlDataReader dataSet = getData("select * from categories where parent=" + parent);
            return dataSet;
        }

        public bool setProductStatus(int productId, string status)
        {
            int effectedRows = setData("update products set status='"+status+"' where id="+ productId);

            if (effectedRows == 1)
                return true;

            return false;
        }

        public bool setProduct(int id, string name, string excerpt, string description, int cost, string instock, string featured, string status, string image)
        {
            int effectedRows = setData("update products set name='"+name+"', excerpt='"+excerpt+"', description='"+description+"', cost="+cost+", instock='"+instock+"', featured='"+featured+"', status='"+status+"', image='"+image+"' where id="+id);

            if (effectedRows == 1)
                return true;

            return false;
        }

        public bool setCategory(int id, string name, string description, int parent = 0)
        {
            int effectedRows = setData("update categories set name='"+name+"', description='"+description+"', parent="+parent+" where id="+id);

            if (effectedRows == 1)
                return true;

            return false;
        }



    }
}












