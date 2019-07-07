using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementSystem.Models;

namespace StockManagementSystem.Gateway
{
    public class StockOutGateway
    {
        private string connectionString =
               WebConfigurationManager.ConnectionStrings["StockManagementSystemDBCon"].ConnectionString;


        public int SaveStockOut(StockOut aStockOut)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //string querry = "Insert into StockOut_tbl (ItemID,StockOutQuantity,Flag,StockOutDate) values(" +
            //                aStockOut.ItemId + "," + aStockOut.StockOutQuantity + ",'" + aStockOut.Flag + "','" + aStockOut.StockOutDate +
            //                "')";
            string querry = "Insert into StockOut_tbl (ItemID,StockOutQuantity,Flag,StockOutDate) values(@ItemId,@StockOutQuantity,@Flag,@StockOutDate)";
            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.AddWithValue("ItemId", aStockOut.ItemId);
            cmd.Parameters.AddWithValue("StockOutQuantity", aStockOut.StockOutQuantity);
            cmd.Parameters.AddWithValue("Flag", aStockOut.Flag);
            cmd.Parameters.AddWithValue("StockOutDate", aStockOut.StockOutDate);

            int rowCount = cmd.ExecuteNonQuery();

            connection.Close();

            return rowCount;
            
        }

        public List<StockOut> GetAllItemBetweenTwoDate(DateTime fromDateTime, DateTime toDateTime)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "select I.ItemName [Item Name],sum(S.StockOutQuantity) [Sales Quantity] from StockOut_tbl as S inner Join Item_tbl as I on S.ItemID=I.ItemID where S.StockOutDate between @FromDate and @Todate and Flag='sell' GROUP BY I.ItemName";
            SqlCommand cmd = new SqlCommand(querry, connection);

            cmd.Parameters.AddWithValue("FromDate", fromDateTime);
            cmd.Parameters.AddWithValue("ToDate", toDateTime);

            SqlDataReader reader = cmd.ExecuteReader();
            List<StockOut> aStockOuts = new List<StockOut>();

            while (reader.Read())
            {
                 StockOut aStockOut=new StockOut();

                aStockOut.ItemName = (string)reader["Item Name"];
                aStockOut.StockOutQuantity = (int) reader["Sales Quantity"];
               

                aStockOuts.Add(aStockOut);
            }
            reader.Close();
            connection.Close();

            return aStockOuts;
        }
    }
}