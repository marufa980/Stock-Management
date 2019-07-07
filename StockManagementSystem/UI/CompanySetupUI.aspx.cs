using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;
using StockManagementSystem.Models;

namespace StockManagementSystem.UI
{
    public partial class CompanySetupUI1 : System.Web.UI.Page
    {

        CompanyManager aCompanyManager=new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            companyInfoGridView.DataSource = aCompanyManager.GetAllCompanyInfo();
            companyInfoGridView.DataBind();
        }

        protected void companySaveButton_Click(object sender, EventArgs e)
        {
            Company aCompany=new Company();
            aCompany.CompanyName = companyNameTextBox.Text;

            if (aCompanyManager.IsCompanyAllReadyExist(aCompany))
            {
                messageLabel.Text = aCompany.CompanyName+" Allready Exist ";
            }
            else
            {
                messageLabel.Text = "";
                messageLabel.Text=aCompanyManager.SaveCompanyInfo(aCompany);
                companyInfoGridView.DataSource = aCompanyManager.GetAllCompanyInfo();
                companyInfoGridView.DataBind();
                
            }
            
        }

        
    }
}