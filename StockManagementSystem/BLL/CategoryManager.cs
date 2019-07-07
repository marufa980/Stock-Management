using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.Gateway;
using StockManagementSystem.Models;

namespace StockManagementSystem.BLL
{
    public class CategoryManager
    {
        CategoryGateway aCategoryGateway=new CategoryGateway();
        public List<Category> GetAllCategoriesInfo()
        {
            return aCategoryGateway.GetAllCategoryInfo();
        }

        public string SaveCategoryInfo(Category aCategory)
        {
            if (aCategoryGateway.SaveCategoryInfo(aCategory)>0)
            {
                return "Saved";
            }

            return "Not Saved";
        }

        public bool IsCategoryAllreadyExist(Category aCategory)
        {
            if (aCategoryGateway.IsCategoryAllreadyExist(aCategory) > 0)
            {
                return true;
            }
            return false;
        }

        public Category GetCategoryInfo(int categoryId)
        {

            return aCategoryGateway.GetCategoryInfo(categoryId);

        }
        public string UpdateCategoryInfo(Category aCategory)
        {
            if (aCategoryGateway.UpdateCategoryInfo(aCategory)>0)
            {
                return "Updated";
            }
            return "Not Updated";
        }
    }
}