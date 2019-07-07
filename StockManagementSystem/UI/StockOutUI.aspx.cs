using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;
using StockManagementSystem.Models;

namespace StockManagementSystem.UI
{
    public partial class StockOutUI : System.Web.UI.Page
    {
        CompanyManager aCompanyManager = new CompanyManager();
        ItemManager aItemManager = new ItemManager();
        StockOutManager aStockOutManager=new StockOutManager();
        List<StockOut> stockOuts = new List<StockOut>();

        protected void Page_Load(object sender, EventArgs e)
        {
            reorderLevelTextBox.Text = String.Empty;
            availableQuantityTextBox.Text = String.Empty;

            if (!IsPostBack)
            {
                companyDropDownList.DataSource = aCompanyManager.GetAllCompanyInfo();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "CompanyId";
                companyDropDownList.DataBind();
                ListItem seletedItemCom = new ListItem("Select Company", "-1");
                companyDropDownList.Items.Insert(0, seletedItemCom);


                itemDropDownList.Enabled = false;

            }


        }

        
        protected void addButton_Click(object sender, EventArgs e)
        {

            StockOut aStockOut = new StockOut();
            

            aStockOut.CompanyId = Convert.ToInt32(companyDropDownList.SelectedItem.Value);
            aStockOut.ItemId = Convert.ToInt32(itemDropDownList.SelectedItem.Value);

            aStockOut.CompanyName = companyDropDownList.SelectedItem.Text;
            aStockOut.ItemName = itemDropDownList.SelectedItem.Text;
            aStockOut.StockOutQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text);

            Item aItem = new Item();
            aItem = aItemManager.GetItemInfo(aStockOut.ItemId);


            if (aItem.AvailableQuantity>=aStockOut.StockOutQuantity)
            {
                if (ViewState["StockOutItems"] != null)
                {
                    stockOuts = (List<StockOut>)ViewState["StockOutItems"];
                }

                if (stockOuts != null)
                {
                    foreach (var item in stockOuts)
                    {
                        if (item.ItemId == aStockOut.ItemId)
                        {
                            item.StockOutQuantity += aStockOut.StockOutQuantity;
                            goto Next;
                        }
                    }

                }

                stockOuts.Add(aStockOut);

            Next:

                ViewState["StockOutItems"] = stockOuts;


                stockOutGridView.DataSource = stockOuts;
                stockOutGridView.DataBind();

                companyDropDownList.SelectedIndex = 0;
                itemDropDownList.SelectedIndex = 0;
                itemDropDownList.Enabled = false;
                stockOutQuantityTextBox.Text = String.Empty;


            }

            else
            {
                messageLabel.Text = "Stock Out Quantity is larger than Available Quantity";

                companyDropDownList.SelectedIndex = 0;
                itemDropDownList.SelectedIndex = 0;
                itemDropDownList.Enabled = false;
            }



        }

        protected void companyDropDownList_TextChanged(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex == 0)
            {

                itemDropDownList.Enabled = false;
            }
            else
            {
                itemDropDownList.Enabled = true;

                itemDropDownList.DataSource = aItemManager.GetAllItemsInfoUnderCompany(Convert.ToInt32(companyDropDownList.SelectedValue));
                itemDropDownList.DataTextField = "ItemName";
                itemDropDownList.DataValueField = "ItemId";
                itemDropDownList.DataBind();

                ListItem seletedItemItems = new ListItem("Select Item", "-1");
                itemDropDownList.Items.Insert(0, seletedItemItems);

            }
        }

        protected void itemDropDownList_TextChanged(object sender, EventArgs e)
        {
            Item aItem = new Item();
            if (itemDropDownList.SelectedIndex == 0)
            {
                reorderLevelTextBox.Text = String.Empty;
                availableQuantityTextBox.Text = String.Empty;
            }
            else
            {
                aItem = aItemManager.GetItemInfo(Convert.ToInt32(itemDropDownList.SelectedValue));

                reorderLevelTextBox.Text = aItem.ReorderLevel.ToString();
                availableQuantityTextBox.Text = aItem.AvailableQuantity.ToString();

                itemIdHiddenField.Value = aItem.ItemId.ToString();
                availableQuantityHiddenField.Value = aItem.AvailableQuantity.ToString();
            }


        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            List<StockOut> sOuts=new List<StockOut>();
            sOuts = (List<StockOut>) ViewState["StockOutItems"];

            if (sOuts != null)
            {
                foreach (var stockItem in sOuts)
                {
                    stockItem.Flag = "sell";
                    stockItem.StockOutDate =DateTime.Now;
                    if (aStockOutManager.SaveStockOut(stockItem))
                    {
                        messageLabel.Text = "saved";

                        Item aItem=new Item();
                        aItem = aItemManager.GetItemInfo(stockItem.ItemId);
                        int updatedValue = aItem.AvailableQuantity - stockItem.StockOutQuantity;

                        aItemManager.UpdateAvailabelQuantity(stockItem.ItemId,updatedValue);

                        stockOutGridView.DataSource = null;
                        stockOutGridView.DataBind();
                        ViewState["StockOutItems"] = null;
                    }
                    else
                    {
                        messageLabel.Text = "not saved";
                    }
                }
            }
            else
            {
                messageLabel.Text = "please first select";
            }
           
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            List<StockOut> sOuts = new List<StockOut>();
            sOuts = (List<StockOut>)ViewState["StockOutItems"];

            if (sOuts!=null)
            {
                foreach (var stockItem in sOuts)
                {
                    stockItem.Flag = "damage";
                    stockItem.StockOutDate = DateTime.Now;
                    if (aStockOutManager.SaveStockOut(stockItem))
                    {
                        messageLabel.Text = "saved";

                        Item aItem = new Item();
                        aItem = aItemManager.GetItemInfo(stockItem.ItemId);
                        int updatedValue = aItem.AvailableQuantity - stockItem.StockOutQuantity;

                        aItemManager.UpdateAvailabelQuantity(stockItem.ItemId, updatedValue);

                        stockOutGridView.DataSource = null;
                        stockOutGridView.DataBind();
                        ViewState["StockOutItems"] = null;
                    }
                    else
                    {
                        messageLabel.Text = "not saved";
                    }
                }
            }
            else
            {
                messageLabel.Text = "please first select";
            }

        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            List<StockOut> sOuts = new List<StockOut>();
            sOuts = (List<StockOut>)ViewState["StockOutItems"];
            if (sOuts!=null)
            {
                foreach (var stockItem in sOuts)
                {
                    stockItem.Flag = "lost";
                    stockItem.StockOutDate = DateTime.Now;
                    if (aStockOutManager.SaveStockOut(stockItem))
                    {
                        messageLabel.Text = "saved";

                        Item aItem = new Item();
                        aItem = aItemManager.GetItemInfo(stockItem.ItemId);
                        int updatedValue = aItem.AvailableQuantity - stockItem.StockOutQuantity;

                        aItemManager.UpdateAvailabelQuantity(stockItem.ItemId, updatedValue);

                        stockOutGridView.DataSource = null;
                        stockOutGridView.DataBind();
                        ViewState["StockOutItems"] = null;
                    }
                    else
                    {
                        messageLabel.Text = "not saved";
                    }
                }
            }

            else
            {
                messageLabel.Text = "please first select";
            }
           

        }

        

      
    }
}