using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementSystem.Models;

namespace StockManagementSystem.Gateway
{
    public class ItemGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockManagementSystemDBCon"].ConnectionString;


        public int IsItemAllreadyExist(Item aItem)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "Select count(*) from Item_tbl where ItemName=@ItemName";
            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.AddWithValue("ItemName", aItem.ItemName);
            int rowCount = (int) cmd.ExecuteScalar();

            connection.Close();
            return rowCount;
        }
        public int SaveItemInfo(Item aItem)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            connection.Open();
            //string querry = "Insert into Item_tbl (CategoryID,CompanyID,ItemName,ReorderLevel) values(" +
            //                aItem.CategoryId + "," + aItem.CompanyId + ",'" + aItem.ItemName + "'," + aItem.ReorderLevel +
            //                ")";
            string querry = "Insert into Item_tbl (CategoryID,CompanyID,ItemName,ReorderLevel) values(@CategoryId,@CompanyId,@ItemName,@ReordeLevel)";
            SqlCommand cmd=new SqlCommand(querry,connection);
            cmd.Parameters.AddWithValue("CategoryId",aItem.CategoryId);
            cmd.Parameters.AddWithValue("CompanyId", aItem.CompanyId);
            cmd.Parameters.AddWithValue("ItemName", aItem.ItemName);
            cmd.Parameters.AddWithValue("ReorderLevel", aItem.ReorderLevel);

            int rowCount = cmd.ExecuteNonQuery();
            connection.Close();

            return rowCount;

        }

        public List<Item> GetAllItemsInfoUnderCompany(int companyId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "Select * from Item_tbl where CompanyID=@CompanyId";

            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.AddWithValue("CompanyId", companyId);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Item> items=new List<Item>();
            while (reader.Read())
            {
                Item item=new Item();

                item.ItemId = (int) reader["ItemID"];
                item.CategoryId = (int) reader["CategoryID"];
                item.CompanyId = (int) reader["CompanyID"];
                item.ItemName = (string) reader["ItemName"];
                item.ReorderLevel = (int) reader["ReorderLevel"];
                item.AvailableQuantity = (int) reader["AvailableQuantity"];

                items.Add(item);
            }

            reader.Close();
            connection.Close();
            
            return items;
           
            

        }

        public Item GetItemInfo(int itemId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "Select * from Item_tbl where ItemID=@ItemId";
            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.AddWithValue("ItemId", itemId);

            SqlDataReader reader = cmd.ExecuteReader();

            Item item = null;
            
            if(reader.HasRows)
            {
                reader.Read();
                item = new Item();

                item.ItemId = (int)reader["ItemID"];
                item.CategoryId = (int)reader["CategoryID"];
                item.CompanyId = (int)reader["CompanyID"];
                item.ItemName = (string)reader["ItemName"];
                item.ReorderLevel = (int)reader["ReorderLevel"];
                item.AvailableQuantity = (int)reader["AvailableQuantity"];

                
            }

            reader.Close();
            connection.Close();

            return item;
           
        }

        public int UpdateAvailabelQuantity(int itemId,int aQuantity)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string querry = "update Item_tbl set AvailableQuantity=@Quantity where ItemID=@ItemId";

            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.AddWithValue("Quantity", aQuantity);
            cmd.Parameters.AddWithValue("ItemId", itemId);

            int rowCount = cmd.ExecuteNonQuery();

            connection.Close();

            return rowCount;
            
        }

        public List<ItemSummaryVM> GetAllItemSummary()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "select I.ItemName [Item Name] ,C.CompanyName as [Company Name],Ca.CategoryName [Category Name],I.AvailableQuantity [Available Quantity],I.ReorderLevel [Reorder Level] from Item_tbl as I inner join Company_tbl as C on I.CompanyID = C.CompanyID inner join Category_tbl as Ca on Ca.CategoryID = I.CategoryID";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<ItemSummaryVM> aItemSummaryVms = new List<ItemSummaryVM>();
            while (reader.Read())
            {
                ItemSummaryVM aItemSummaryVm = new ItemSummaryVM();

                aItemSummaryVm.ItemName = (string)reader["Item Name"];
                aItemSummaryVm.CompanyName = (string)reader["Company Name"];
                aItemSummaryVm.CategoryName = (string)reader["Category Name"];
                aItemSummaryVm.AvailableQuantity = (int) reader["Available Quantity"];
                aItemSummaryVm.ReorderLevel = (int) reader["Reorder Level"];
                
                aItemSummaryVms.Add(aItemSummaryVm);
            }
            reader.Close();
            connection.Close();

            return aItemSummaryVms;
        }

        public List<ItemSummaryVM> GetAllItemSummaryByCompany(int companyId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "select I.ItemName [Item Name] ,C.CompanyName as [Company Name],Ca.CategoryName [Category Name],I.AvailableQuantity [Available Quantity],I.ReorderLevel [Reorder Level] from Item_tbl as I inner join Company_tbl as C on I.CompanyID = C.CompanyID inner join Category_tbl as Ca on Ca.CategoryID = I.CategoryID where I.CompanyID=@CompanyId";
            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.AddWithValue("CompanyId", companyId);

            SqlDataReader reader = cmd.ExecuteReader();
            List<ItemSummaryVM> aItemSummaryVms = new List<ItemSummaryVM>();
            while (reader.Read())
            {
                ItemSummaryVM aItemSummaryVm = new ItemSummaryVM();

                aItemSummaryVm.ItemName = (string)reader["Item Name"];
                aItemSummaryVm.CompanyName = (string)reader["Company Name"];
                aItemSummaryVm.CategoryName = (string)reader["Category Name"];
                aItemSummaryVm.AvailableQuantity = (int)reader["Available Quantity"];
                aItemSummaryVm.ReorderLevel = (int)reader["Reorder Level"];

                aItemSummaryVms.Add(aItemSummaryVm);
            }
            reader.Close();
            connection.Close();
            return aItemSummaryVms;
        }

        public List<ItemSummaryVM> GetAllItemSummaryByCategory(int categoryId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string querry = "select I.ItemName [Item Name] ,C.CompanyName as [Company Name],Ca.CategoryName [Category Name],I.AvailableQuantity [Available Quantity],I.ReorderLevel [Reorder Level] from Item_tbl as I inner join Company_tbl as C on I.CompanyID = C.CompanyID inner join Category_tbl as Ca on Ca.CategoryID = I.CategoryID where I.CategoryID=@CategoryId";

            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.AddWithValue("CategoryId", categoryId);

            SqlDataReader reader = cmd.ExecuteReader();
            List<ItemSummaryVM> aItemSummaryVms = new List<ItemSummaryVM>();

            while (reader.Read())
            {
                ItemSummaryVM aItemSummaryVm = new ItemSummaryVM();

                aItemSummaryVm.ItemName = (string)reader["Item Name"];
                aItemSummaryVm.CompanyName = (string)reader["Company Name"];
                aItemSummaryVm.CategoryName = (string)reader["Category Name"];
                aItemSummaryVm.AvailableQuantity = (int)reader["Available Quantity"];
                aItemSummaryVm.ReorderLevel = (int)reader["Reorder Level"];

                aItemSummaryVms.Add(aItemSummaryVm);
            }
            reader.Close();
            connection.Close();

            return aItemSummaryVms;
        }

        public List<ItemSummaryVM> GetAllItemSummaryByCompanyAndCategory(int companyId,int categoryId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "select I.ItemName [Item Name] ,C.CompanyName as [Company Name],Ca.CategoryName [Category Name],I.AvailableQuantity [Available Quantity],I.ReorderLevel [Reorder Level] from Item_tbl as I inner join Company_tbl as C on I.CompanyID = C.CompanyID inner join Category_tbl as Ca on Ca.CategoryID = I.CategoryID where I.CompanyID=@CompanyId and I.CategoryID=@CategoryId";

            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.AddWithValue("CompanyId", companyId);
            cmd.Parameters.AddWithValue("CategoryId", categoryId);

            SqlDataReader reader = cmd.ExecuteReader();
            List<ItemSummaryVM> aItemSummaryVms = new List<ItemSummaryVM>();

            while (reader.Read())
            {
                ItemSummaryVM aItemSummaryVm = new ItemSummaryVM();

                aItemSummaryVm.ItemName = (string)reader["Item Name"];
                aItemSummaryVm.CompanyName = (string)reader["Company Name"];
                aItemSummaryVm.CategoryName = (string)reader["Category Name"];
                aItemSummaryVm.AvailableQuantity = (int)reader["Available Quantity"];
                aItemSummaryVm.ReorderLevel = (int)reader["Reorder Level"];

                aItemSummaryVms.Add(aItemSummaryVm);
            }

            reader.Close();
            connection.Close();

            return aItemSummaryVms;
        }

      
    }
}