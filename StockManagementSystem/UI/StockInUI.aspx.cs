using System;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;
using StockManagementSystem.Models;

namespace StockManagementSystem.UI
{
    public partial class StockInUI : System.Web.UI.Page
    { 
        CompanyManager aCompanyManager=new CompanyManager();
        ItemManager aItemManager=new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            reoderLevelTextBox.Text = String.Empty;
            avilableQuantityTextBox.Text = String.Empty;
            
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = aCompanyManager.GetAllCompanyInfo();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "CompanyId";
                companyDropDownList.DataBind();
                ListItem seletedItemCom=new ListItem("Select Company","-1");
                companyDropDownList.Items.Insert(0,seletedItemCom);
             
 
                itemDropDownList.Enabled = false;

            }
         
         

        }

        protected void stockInSaveButton_Click(object sender, EventArgs e)
        {
           
           
                 int itemId = Convert.ToInt32(itemIdHiddenField.Value);
                 int availableQuantity = Convert.ToInt32(availableQuantityHiddenField.Value) + Convert.ToInt32(stockInQuantityTextBox.Text);

                 if (aItemManager.UpdateAvailabelQuantity(itemId, availableQuantity))
                 {
                     messageLabel.Text = "saved";

                     stockInQuantityTextBox.Text=String.Empty;
                     
                     itemIdHiddenField.Value = null;
                     availableQuantityHiddenField.Value = string.Empty;
                     companyDropDownList.SelectedIndex = 0;
                     itemDropDownList.SelectedIndex = 0;
                     itemDropDownList.Enabled = false;
                 }
                 else
                 {
                     messageLabel.Text = "not saved";
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
                reoderLevelTextBox.Text =String.Empty;
                avilableQuantityTextBox.Text =String.Empty;
            }
            else
            {
                aItem = aItemManager.GetItemInfo(Convert.ToInt32(itemDropDownList.SelectedValue));

                reoderLevelTextBox.Text = aItem.ReorderLevel.ToString();
                avilableQuantityTextBox.Text = aItem.AvailableQuantity.ToString();

                itemIdHiddenField.Value = aItem.ItemId.ToString();
                availableQuantityHiddenField.Value = aItem.AvailableQuantity.ToString();
            }
          
        }


       

       

     

       

        
    }
}