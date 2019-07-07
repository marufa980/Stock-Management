using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.Gateway;
using StockManagementSystem.Models;

namespace StockManagementSystem.BLL
{
    public class ItemManager
    {
        ItemGateway aItemGateway=new ItemGateway();

        public bool IsItemAllreadyExist(Item aItem)
        {
            if (aItemGateway.IsItemAllreadyExist(aItem)>0)
            {
                return true;
            }
            return false;

        }
        public string SaveItemInfo(Item aItem)
        {
            if (aItemGateway.SaveItemInfo(aItem)>0)
            {
                return "saved";
            }
            return "not saved";
        }

        public List<Item> GetAllItemsInfoUnderCompany(int companyId)
        {
            return aItemGateway.GetAllItemsInfoUnderCompany(companyId);
        }

        public Item GetItemInfo(int itemId)
        {
            return aItemGateway.GetItemInfo(itemId);
        }


        public bool UpdateAvailabelQuantity(int itemId,int aQuantity)
        {
            if (aItemGateway.UpdateAvailabelQuantity(itemId, aQuantity) > 0)
            {
                return true;
            }
            return false;
        }

        public List<ItemSummaryVM> GetAllItemSummary()
        {
            return aItemGateway.GetAllItemSummary();
        }

        public List<ItemSummaryVM> GetAllItemSummaryByCategory(int categoryId)
        {
            return aItemGateway.GetAllItemSummaryByCategory(categoryId);
        }
        public List<ItemSummaryVM> GetAllItemSummaryByCompany(int companyId)
        {
            return aItemGateway.GetAllItemSummaryByCompany(companyId);
        }
        public List<ItemSummaryVM> GetAllItemSummaryByCompanyAndCategory(int companyId,int categoryId)
        {
            return aItemGateway.GetAllItemSummaryByCompanyAndCategory(companyId,categoryId);
        }
    }
}