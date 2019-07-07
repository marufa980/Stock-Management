using System;
using System.Collections.Generic;
using StockManagementSystem.BLL;
using StockManagementSystem.Models;

namespace StockManagementSystem.UI
{
    public partial class ViewSalesBetweenTwoDateUI : System.Web.UI.Page
    {
        StockOutManager aStockOutManager=new StockOutManager();

      

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void viewSalesSearchButton_Click(object sender, EventArgs e)
        {
            

            DateTime from = Convert.ToDateTime(fromDateTextBox.Text);
            DateTime to = Convert.ToDateTime(toDateTextBox.Text);

            if (from<=to)
            {

                salesSummaryGridView.DataSource = aStockOutManager.GetAllItemBetweenTwoDate(from, to); 
                salesSummaryGridView.DataBind();

            }


            else
            {
                salesSummaryGridView.DataSource = null;
                salesSummaryGridView.DataBind();
                messageLabel.Text = "From Date must be equal or smaller than To Date";
            }
        }

       
    }
}