using System;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;

namespace StockManagementSystem.UI
{
    public partial class SearchAndViewItemsSummaryUI : System.Web.UI.Page
    {
        CompanyManager aCompanyManager=new CompanyManager();
        CategoryManager aCategoryManager=new CategoryManager();
        ItemManager aItemManager=new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                companyDropDownList.DataSource = aCompanyManager.GetAllCompanyInfo();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "CompanyId";
                companyDropDownList.DataBind();

                ListItem aListItem=new ListItem("Select Company","-1");
                companyDropDownList.Items.Insert(0,aListItem);

                categoryDropDownList.DataSource = aCategoryManager.GetAllCategoriesInfo();
                categoryDropDownList.DataTextField = "CategoryName";
                categoryDropDownList.DataValueField = "CategoryId";
                categoryDropDownList.DataBind();

                ListItem listItem=new ListItem("Select Category","-1");
                categoryDropDownList.Items.Insert(0,listItem);
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex == 0 & categoryDropDownList.SelectedIndex == 0)
            {
                itemSummaryGridView.DataSource = aItemManager.GetAllItemSummary();
                itemSummaryGridView.DataBind();
                
            }
            else if (companyDropDownList.SelectedIndex >0 & categoryDropDownList.SelectedIndex == 0)
            {
                itemSummaryGridView.DataSource = aItemManager.GetAllItemSummaryByCompany(Convert.ToInt32(companyDropDownList.SelectedValue));
                itemSummaryGridView.DataBind();
            }

            else if (companyDropDownList.SelectedIndex== 0 & categoryDropDownList.SelectedIndex >0)
            {
                itemSummaryGridView.DataSource = aItemManager.GetAllItemSummaryByCategory(Convert.ToInt32(categoryDropDownList.SelectedValue));
                itemSummaryGridView.DataBind();
            }
            else
            {
                itemSummaryGridView.DataSource = aItemManager.GetAllItemSummaryByCompanyAndCategory(Convert.ToInt32(companyDropDownList.SelectedValue), Convert.ToInt32(categoryDropDownList.SelectedValue));
                itemSummaryGridView.DataBind();
            }
          

        }

       
    }
}