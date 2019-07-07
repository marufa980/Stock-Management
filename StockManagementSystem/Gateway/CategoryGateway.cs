using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementSystem.Models;

namespace StockManagementSystem.Gateway
{
    public class CategoryGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockManagementSystemDBCon"].ConnectionString;


        public List<Category> GetAllCategoryInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string querry = "Select * from Category_tbl";
            SqlCommand cmd = new SqlCommand(querry, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Category> categoies = new List<Category>();

            while (reader.Read())
            {
                Category aCategory=new Category();
                aCategory.CategoryId = (int)reader["CategoryID"];
                aCategory.CategoryName = reader["CategoryName"].ToString();

                categoies.Add(aCategory);
            }

            connection.Close();
            return categoies;

        }


        public int SaveCategoryInfo(Category aCategory)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string querry = "INSERT INTO Category_tbl(CategoryName) Values(@CategoryName)";

            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.AddWithValue("CategoryName", aCategory.CategoryName);

            int rowCount = cmd.ExecuteNonQuery();
            connection.Close();

            return rowCount;
        }

        public int IsCategoryAllreadyExist(Category aCategory)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string querry = "Select count(*) from Category_tbl where CategoryName=@CategoryName";

            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.AddWithValue("CategoryName", aCategory.CategoryName);

            int rowCount = (int)cmd.ExecuteScalar();
            connection.Close();

            return rowCount;


        }

        public int UpdateCategoryInfo(Category aCategory)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string querry = "update Category_tbl set CategoryName=@CategoryName where CategoryID=@CategoryId";
            SqlCommand cmd = new SqlCommand(querry, connection);

            cmd.Parameters.AddWithValue("CategoryName", aCategory.CategoryName);
            cmd.Parameters.AddWithValue("CategoryId", aCategory.CategoryId);

            int rowCount = cmd.ExecuteNonQuery();

            connection.Close();

            return rowCount;
        }

        public Category GetCategoryInfo(int categoryId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "Select * from Category_tbl where CategoryID=@CategoryId";

            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.AddWithValue("CategoryId", categoryId);

            SqlDataReader reader = cmd.ExecuteReader();
            Category aCategory = null;

            if(reader.HasRows)
            {
                reader.Read();
                aCategory = new Category();
                aCategory.CategoryId = (int)reader["CategoryID"];
                aCategory.CategoryName = reader["CategoryName"].ToString();
        
            }

            connection.Close();
            return aCategory;

        }

    }
}