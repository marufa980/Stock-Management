using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using StockManagementSystem.Gateway;
using StockManagementSystem.Models;

namespace StockManagementSystem.BLL
{
    public class CompanyManager
    {
        CompanyGateway aCompanyGateway=new CompanyGateway();
        public List<Company> GetAllCompanyInfo()
        {
            return aCompanyGateway.GetAllCompanyInfo();
        }

        public string SaveCompanyInfo(Company aCompany)
        {
            if (aCompanyGateway.SaveCompanyInfo(aCompany)>0)
            {
                return "Saved";
            }
            return "Not Saved";

        }

        public bool IsCompanyAllReadyExist(Company aCompany)
        {
            if (aCompanyGateway.IsCompanyAllReadyExist(aCompany) > 0)
            {
                return true;
            }
            return false;
        }
    }
}