using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.SD;
using Sonluk.IDataAccess.SD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.SD
{
    public class Report:IReport
    {
        public IList<ReportInfo> AC(string dateStart, string dateEnd, string customer)
        {
            IList<ReportInfo> nodes = new List<ReportInfo>();
            IRfcFunction func = RFC.Function("ZRFC_AC_REPORT");

            func.SetValue("I_DATE1", dateStart);
            func.SetValue("I_DATE2", dateEnd);
            func.SetValue("I_KUNNR", customer);

            try
            {
                RFC.Invoke(func, false);
                string customerName = func.GetString("O_NAME1");
                IRfcTable table = func.GetTable("O_ACB");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ReportInfo node = new ReportInfo();
                    node.Customer = customer;
                    node.CustomerName = customerName;
                    node.Date = table.GetString("DAT");
                    node.Delivery = table.GetString("NBR");
                    node.Type = table.GetString("TYP");
                    node.Payable = table.GetDecimal("ARA");
                    node.Receivable = table.GetDecimal("RAA");
                    node.Balance = table.GetDecimal("BAA");
                    node.Invoice = table.GetString("INV");
                    node.Currency = table.GetString("CURR");
                    node.Remark = table.GetString("MARK");
                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<ReportInfo> SO(string customerPOStart, string customerPOEnd, string dateStart, string dateEnd, string materialStart, string materialEnd)
        {
            IList<ReportInfo> nodes = new List<ReportInfo>();
            IRfcFunction func = RFC.Function("ZRFC_SO_REPORT");
            func.SetValue("I_BSTNK", customerPOStart);
            func.SetValue("I_BSTNK1", customerPOEnd);
            func.SetValue("I_APDAT", dateStart);
            func.SetValue("I_APDAT1", dateEnd);
            func.SetValue("I_MATNR", materialStart);
            func.SetValue("I_MATNR1", materialEnd);

            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("O_SOREP");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ReportInfo node = new ReportInfo();
                    node.Customer = table.GetString("KUNNR");
                    node.CustomerName = table.GetString("NAME1");
                    node.CustomerPO = table.GetString("BSTKD");
                    node.Date = table.GetString("ERDAT");
                    node.SalesOrder = table.GetString("VBELN");
                    node.SalesOrderItem = table.GetString("POSNR");
                    node.Material = table.GetString("MABNR");
                    node.MaterialDescription = table.GetString("ARKTX");
                    node.Quantity = table.GetDecimal("KWMENG");
                    node.Unit = table.GetString("VRKME");
                    node.UnitDescription = table.GetString("MSEHT");
                    node.Price = table.GetDecimal("PRICE");
                    node.Amount = table.GetDecimal("AMOUNT");
                    node.Currency = table.GetString("CURR");
                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<ReportInfo> SH(string customerPOStart, string customerPOEnd, string dateStart, string dateEnd, string materialStart, string materialEnd)
        {
            IList<ReportInfo> nodes = new List<ReportInfo>();
            IRfcFunction func = RFC.Function("ZRFC_SH_REPORT");
            func.SetValue("I_BSTNK", customerPOStart);
            func.SetValue("I_BSTNK1", customerPOEnd);
            func.SetValue("I_APDAT", dateStart);
            func.SetValue("I_APDAT1", dateEnd);
            func.SetValue("I_MATNR", materialStart);
            func.SetValue("I_MATNR1", materialEnd);

            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("O_SHREP");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ReportInfo node = new ReportInfo();
                    node.Customer = table.GetString("KUNNR");
                    node.CustomerName = table.GetString("NAME1");
                    node.CustomerPO = table.GetString("BSTKD");
                    node.Date = table.GetString("ERDAT");
                    node.SalesOrder = table.GetString("VBELN");
                    node.SalesOrderItem = table.GetString("POSNR");
                    node.Material = table.GetString("MABNR");
                    node.MaterialDescription = table.GetString("ARKTX");
                    node.Quantity = table.GetDecimal("KWMENG");
                    node.Delivery = table.GetString("VBELN1");
                    node.DeliveryItem = table.GetString("POSNR1");
                    node.DeliveryDate = table.GetString("ERDAT1");
                    node.QuantityDelivered = table.GetDecimal("LFIMG");
                    node.Unit = table.GetString("VRKME");
                    node.UnitDescription = table.GetString("MSEHT");
                    node.Price = table.GetDecimal("PRICE");
                    node.Amount = table.GetDecimal("AMOUNT");
                    node.Currency = table.GetString("CURR");
                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<ReportInfo> SHFH(string customer, string dateStart, string dateEnd)
        {
            IList<ReportInfo> nodes = new List<ReportInfo>();
            IRfcFunction func = RFC.Function("ZRFC_SHFH_REPORT");
            func.SetValue("I_KUNNR1", customer);
            func.SetValue("I_APDAT", dateStart);
            func.SetValue("I_APDAT1", dateEnd);

            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("O_SHREP");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ReportInfo node = new ReportInfo();
                    node.Customer = table.GetString("KUNNR");
                    node.CustomerName = table.GetString("NAME1");
                    node.CustomerPO = table.GetString("BSTKD");
                    node.Date = table.GetString("ERDAT");
                    node.SalesOrder = table.GetString("VBELN");
                    node.SalesOrderItem = table.GetString("POSNR");
                    node.Material = table.GetString("MABNR");
                    node.MaterialDescription = table.GetString("ARKTX");
                    node.Quantity = table.GetDecimal("KWMENG");
                    node.Delivery = table.GetString("VBELN1");
                    node.DeliveryItem = table.GetString("POSNR1");
                    node.DeliveryDate = table.GetString("ERDAT1");
                    node.QuantityDelivered = table.GetDecimal("LFIMG");
                    node.Unit = table.GetString("VRKME");
                    node.UnitDescription = table.GetString("MSEHT");
                    node.Price = table.GetDecimal("PRICE");
                    node.Amount = table.GetDecimal("AMOUNT");
                    node.Currency = table.GetString("CURR");
                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<ReportInfo> ZKMX(string customer, string dateStart, string dateEnd)
        {
            IList<ReportInfo> nodes = new List<ReportInfo>();
            IRfcFunction func = RFC.Function("ZRFC_ZKMX_REPORT");

            func.SetValue("I_KUNNR", customer);
            func.SetValue("I_DATE1", dateStart);
            func.SetValue("I_DATE2", dateEnd);
            

            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("O_ACB");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ReportInfo node = new ReportInfo();
                    node.Customer = table.GetString("KUNNR");
                    node.SalesOrganization = table.GetString("VKORG");
                    node.Date = table.GetString("ERDAT");
                    node.SalesOrder = table.GetString("VBELN");
                    node.DistributionChannel = table.GetString("VTWEG");
                    node.CustomerName = table.GetString("NAME1");
                    node.IncreaseDiscount = table.GetDecimal("ZKRLJE");
                    node.AvailableDiscount = table.GetDecimal("JYJE");
                    node.DecreaseDiscount = table.GetDecimal("ZKFFJE");
                    node.SalesOrderDiscount = table.GetDecimal("ZKDFFJE");
                    node.Type = table.GetString("ZTYPE");
                    node.DocumentChangeNumber = table.GetString("CHANGENR");
                    node.Remark = table.GetString("TEXT");
                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }
    }
}
