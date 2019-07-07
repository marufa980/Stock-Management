using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.Gateway;
using StockManagementSystem.Models;

namespace StockManagementSystem.BLL
{
    public class StockOutManager
    {
        StockOutGateway aStockOutGateway=new StockOutGateway();
        public bool SaveStockOut(StockOut aStockOut)
        {
            if (aStockOutGateway.SaveStockOut(aStockOut)>0)
            {
                return true;
            }
            return false;

        }

        public List<StockOut> GetAllItemBetweenTwoDate(DateTime froDateTime, DateTime toDateTime)
        {
            return aStockOutGateway.GetAllItemBetweenTwoDate(froDateTime,toDateTime);
        }
    }
}