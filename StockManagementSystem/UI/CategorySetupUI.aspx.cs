using System;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;
using StockManagementSystem.Models;

namespace StockManagementSystem.UI
{
    public partial class CategorySetupUI : System.Web.UI.Page
    {
        CategoryManager aCategoryManager=new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            categorySetupGridView.DataSource = aCategoryManager.GetAllCategoriesInfo();
            categorySetupGridView.DataBind();

            updateButton.Enabled = false;
        }


        protected void categorySaveButton_Click(object sender, EventArgs e)
        {
           Category aCategory=new Category();
            aCategory.CategoryName = categoryNameTextBox.Text;

            if (aCategoryManager.IsCategoryAllreadyExist(aCategory))
            {
                categoryMessageLabel.Text = aCategory.CategoryName+" Allready Exist ";
            }
            else
            {
                categoryMessageLabel.Text = "";
                categoryMessageLabel.Text=aCategoryManager.SaveCategoryInfo(aCategory);
                categorySetupGridView.DataSource = aCategoryManager.GetAllCategoriesInfo();
                categorySetupGridView.DataBind();

            }
        }

        protected void updateLink_OnClick(object sender, EventArgs e)

        {
        
            categoryIdHiddenField.Value= Convert.ToInt32((sender as LinkButton).CommandArgument).ToString();

            Category aCategory = new Category();
            aCategory=aCategoryManager.GetCategoryInfo(Convert.ToInt32(categoryIdHiddenField.Value));
            categoryNameTextBox.Text = aCategory.CategoryName;
            updateButton.Enabled = true;

        }

      

        protected void updateButton_Click1(object sender, EventArgs e)
        {
            Category aCategory = new Category();
            aCategory.CategoryId = Convert.ToInt32(categoryIdHiddenField.Value);
            aCategory.CategoryName = categoryNameTextBox.Text;
            categoryMessageLabel.Text = aCategoryManager.UpdateCategoryInfo(aCategory);

            categoryIdHiddenField.Value = null;
            categorySetupGridView.DataSource = aCategoryManager.GetAllCategoriesInfo();
            categorySetupGridView.DataBind();
        }
       

    }
}