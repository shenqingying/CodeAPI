using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;

namespace Sonluk.DataAccess.SAP.CRM
{

    public class SAP_ORDER : ISAP_ORDER
    {

       public IList<SAP_CompanyInfo> ShipToParty(string serialNumber, string salesOrganization, string distributionChannel, string division)
        {
            IRfcFunction func = RFC.Function("ZRFC_GET_ADRE");

            func.SetValue("I_KUNNR", serialNumber);
            func.SetValue("I_VKORG", salesOrganization);
            func.SetValue("I_VTWEG", distributionChannel);
            func.SetValue("I_SPART", division);

            IList<SAP_CompanyInfo> nodes = new List<SAP_CompanyInfo>();
            try
            {
                RFC.Invoke(func, false);
                string salesOffices = func.GetString("O_REGI");
                IRfcTable table = func.GetTable("O_KNVP");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    SAP_CompanyInfo node = new SAP_CompanyInfo();
                    node.SerialNumber = table.GetString("KUNN2");
                    node.Address = table.GetString("KNREF");
                    node.SalesOffices = salesOffices;

                    nodes.Add(node);
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;

        }

       public decimal SAP_Price(string serialNumber, string customer, string salesOrganization, string distributionChannel)
       {
           IRfcFunction func = RFC.Function("ZRFC_GET_PRICE1");

           func.SetValue("I_MATNR", serialNumber);
           func.SetValue("I_KUNNR", customer);
           func.SetValue("I_VKORG", salesOrganization);
           func.SetValue("I_VTWEG", distributionChannel);

           decimal SAP_Price = -1;
           try
           {
               RFC.Invoke(func, false);
               SAP_Price = func.GetDecimal("O_KBETR");
           }
           catch (Exception e)
           {
               throw new ApplicationException(e.Message);
           }

           return SAP_Price;
       }

       public SAP_DiscountInfo SAP_Discount(string customer)
       {
           IRfcFunction func = RFC.Function("ZRFC_GET_ZK");
           func.SetValue("I_KUNNR", customer);

           SAP_DiscountInfo node = new SAP_DiscountInfo();
           try
           {
               RFC.Invoke(func, false);
               node.Available = func.GetDecimal("O_KOMXWRT");
               node.Rate = func.GetDecimal("O_KBETR");

           }
           catch (Exception e)
           {
               throw new ApplicationException(e.Message);
           }

           return node;
       }

       public decimal SAP_Balance(string customer)
       {
           IRfcFunction func = RFC.Function("ZSD_GET_YE");
   
           func.SetValue("I_KUNNR", customer);


           decimal SAP_Balance = -1;
           try
           {
               RFC.Invoke(func, false);
               SAP_Balance = func.GetDecimal("O_YE");
           }
           catch (Exception e)
           {
               throw new ApplicationException(e.Message);
           }

           return SAP_Balance;
       }

       public string Create(SAP_SOInfo node)
       {
           IRfcFunction func = RFC.Function("ZRFC_SO_CREATE");

           func.SetValue("I_VKORG", node.Header.SalesOrganization);
           func.SetValue("I_VTWEG", node.Header.DistributionChannel);
           func.SetValue("I_SPART", node.Header.Division);
           func.SetValue("I_KUNRG", node.Header.SoldToParty);
           func.SetValue("I_KUNN2", node.Header.ShipToParty);
           func.SetValue("I_BSTKD", node.Header.CustomerPO);
           func.SetValue("I_BSTDK", node.Header.CustomerPODate);

           IRfcTable importTable = func.GetTable("I_ITEM");
           int index = 0;
           foreach (SAP_SOItemInfo item in node.Items)
           {
               importTable.Append(1);
               importTable.CurrentIndex = index++;
               importTable.SetValue("MATNR", item.Material);
               importTable.SetValue("ZMENG", item.Quantity);
               importTable.SetValue("UM", item.SalesUnit);
           }

           string serialNumber = "";
           try
           {
               RFC.Invoke(func, false);
               if (func.GetString("O_REN").Equals("S"))
                   serialNumber = func.GetString("O_VBELN");
           }
           catch (Exception e)
           {
               throw new ApplicationException(e.Message);
           }

           return serialNumber;
       }


    }
}
