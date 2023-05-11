using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using crudOperation_ADO.net.Models;

namespace MvcCrudOperation.Models
{
    public class Productcmd
    {
        private SqlConnection con = null;
        private void ConnectionReturn()
        {
            string connString = ConfigurationManager.ConnectionStrings["Defualt"].ConnectionString;
            con = new SqlConnection(connString);
        }

        public List<Product> getAllProductData()
        {
            ConnectionReturn();
            List<Product> ReturnList = new List<Product>();

            string Getpro = "select * from [dbo].[Product]";
            con.Open();
            SqlCommand cmd = new SqlCommand(Getpro, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product pro = new Product();
                    pro.ProductId = Convert.ToInt32(dr["ProductId"]);
                    pro.ProductName = dr["ProductName"].ToString();
                    pro.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    ReturnList.Add(pro);
                }
            }
            con.Close();
            return ReturnList;

        }

        internal bool EditProductData(Product pro)
        {
            throw new NotImplementedException();
        }

        public List<Category> FillDropDown()
        {
            ConnectionReturn();
            List<Category> categ = new List<Category>();

            string Getpro = "select * from [dbo].[Category]";
            con.Open();
            SqlCommand cmd = new SqlCommand(Getpro, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Category cate = new Category();
                    cate.CategoryId= Convert.ToInt32(dr["CategoryId"]);
                    cate.CategoryName = dr["CategoryName"].ToString();

                    categ.Add(cate);
                }
            }
            con.Close();
            return categ;

        }

        public bool InsretProductData(Product pro)
        {

            ConnectionReturn();
            string InsertData = "insert into [dbo].[Product] (ProductId,ProductName,CategoryId) values(" + pro.ProductId + ",'" + pro.ProductName + "'," + pro.CategoryId+ ")";
            con.Open();
            SqlCommand cmd = new SqlCommand(InsertData, con);
            int status = cmd.ExecuteNonQuery();
            con.Close();

            if (status > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool editProductData(Product pro)
        {

            ConnectionReturn();
            string UpdateData = "update [dbo].[Product] set ProductName = '" + pro.ProductName + "', CategoryId = " + pro.CategoryId + " where ProductId = " + pro.ProductId + "";
            con.Open();
            SqlCommand cmd = new SqlCommand(UpdateData, con);
            int status = cmd.ExecuteNonQuery();
            con.Close();

            if (status > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool deleteProductData(int pro)
        {

            ConnectionReturn();
            string deleteData = "delete from [dbo].[product] where ProductId =" + pro + "";
            con.Open();
            SqlCommand cmd = new SqlCommand(deleteData, con);
            int status = cmd.ExecuteNonQuery();
            con.Close();

            if (status > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}