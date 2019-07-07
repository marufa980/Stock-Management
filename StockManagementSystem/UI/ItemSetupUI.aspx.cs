using System;
using StockManagementSystem.BLL;
using StockManagementSystem.Models;

namespace StockManagementSystem.UI
{
    public partial class ItemSetupUI : System.Web.UI.Page
    {
        CategoryManager aCategoryManager=new CategoryManager();
        CompanyManager aCompanyManager = new CompanyManager();
         Item aItem = new Item();
        ItemManager aItemManager=new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryDropDownList.DataSource = aCategoryManager.GetAllCategoriesInfo();
                categoryDropDownList.DataTextField = "CategoryName";
                categoryDropDownList.DataValueField = "CategoryId";
                categoryDropDownList.DataBind();

                companyDropDownList.DataSource = aCompanyManager.GetAllCompanyInfo();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "CompanyId";
                companyDropDownList.DataBind();
            }
          

        }

        protected void ItemSaveButton_Click(object sender, EventArgs e)
        {
            aItem.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
            aItem.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            aItem.ItemName = itemNameTextBox.Text;
            aItem.ReorderLevel = Convert.ToInt32(reorderTextBox.Text);

            if (aItemManager.IsItemAllreadyExist(aItem))
            {
                messageLabel.Text = aItem.ItemName +" allready exist";
            }
            else
            {
                messageLabel.Text=aItemManager.SaveItemInfo(aItem);
            }
            
        }
    }
}