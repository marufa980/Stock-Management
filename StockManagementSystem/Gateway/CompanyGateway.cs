using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementSystem.Models;

namespace StockManagementSystem.Gateway
{
    public class CompanyGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockManagementSystemDBCon"].ConnectionString;


        public List<Company> GetAllCompanyInfo()
        {
            SqlConnection connection=new SqlConnection(connectionString);
            connection.Open();

            string querry = "Select * from Company_tbl";

            SqlCommand cmd=new SqlCommand(querry,connection);

            SqlDataReader reader = cmd.ExecuteReader();
            List<Company> companies=new List<Company>();

            while (reader.Read())
            {
                Company aCompany=new Company();
                aCompany.CompanyId = (int) reader["CompanyID"];
                aCompany.CompanyName = reader["CompanyName"].ToString();

                companies.Add(aCompany);
            }

            connection.Close();
            return companies;
            
        }


        public int SaveCompanyInfo(Company aCompany)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string querry = "INSERT INTO Company_tbl(CompanyName) Values(@CompanyName)";

            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.AddWithValue("CompanyName", aCompany.CompanyName);

            int rowCount = cmd.ExecuteNonQuery();
            connection.Close();

            return rowCount;
        }

        public int IsCompanyAllReadyExist(Company aCompany)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string querry = "Select count(*) from Company_tbl where CompanyName=@CompanyName";

            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.AddWithValue("CompanyName", aCompany.CompanyName);

            int rowCount = (int) cmd.ExecuteScalar();

            connection.Close();
            return rowCount;


        }
    }
}