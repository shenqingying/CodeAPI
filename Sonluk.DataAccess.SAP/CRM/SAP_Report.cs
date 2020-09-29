using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.CRM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.CRM
{
    public class SAP_Report : ISAP_Report
    {

        public IList<SAP_Invoice> Invoice(List<SAP_KH> sapsn, SAP_Invoice_Param model)
        {
            IList<SAP_Invoice> nodes = new List<SAP_Invoice>();


            try
            {
                IRfcFunction func = RFC.Function("ZSD_SO_READ");
                IRfcTable i_table = func.GetTable("ET_SO");
                for (int i = 0; i < sapsn.Count; i++)
                {
                    i_table.Append();
                    i_table.SetValue("KUNAG", sapsn[i].KUNNR);
                }
                func.SetValue("ET_SO", i_table);

                func.SetValue("I_TYPE", model.I_TYPE);
                func.SetValue("I_YEAR", model.I_YEAR);
                func.SetValue("I_QUAR_LOW", model.I_QUAR_LOW);
                func.SetValue("I_QUAR_HIGH", model.I_QUAR_HIGH);

                RFC.Invoke(func, false);
                IRfcTable KH_table = func.GetTable("ET_SO");
                if (KH_table.RowCount > 0)
                {
                    for (int i = 0; i < KH_table.RowCount; i++)
                    {
                        SAP_Invoice node = new SAP_Invoice();
                        KH_table.CurrentIndex = i;
                        node.VKBUR = KH_table.GetString("VKBUR");
                        node.BEZEI_BU = KH_table.GetString("BEZEI_BU");
                        node.VKGRP = KH_table.GetString("VKGRP");
                        node.BEZEI = KH_table.GetString("BEZEI");
                        node.KUNNR1 = KH_table.GetString("KUNNR1");
                        node.NAME1 = KH_table.GetString("NAME1");
                        node.TASK = Convert.ToDouble(KH_table.GetString("TASK"));
                        node.TASK1 = Convert.ToDouble(KH_table.GetString("TASK1"));
                        node.JZ = Convert.ToDouble(KH_table.GetString("JZ"));
                        node.JZ2 = Convert.ToDouble(KH_table.GetString("JZ2"));
                        node.JZ1 = Convert.ToDouble(KH_table.GetString("JZ1"));
                        nodes.Add(node);
                    }

                }


            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }


            return nodes;


        }



        public IList<SAP_ReportInfo> AC(string dateStart, string dateEnd, string customer)
        {
            IList<SAP_ReportInfo> nodes = new List<SAP_ReportInfo>();
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

                    SAP_ReportInfo node = new SAP_ReportInfo();
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

        public IList<SAP_ReportInfo> SHFH(string customer, string dateStart, string dateEnd)
        {
            IList<SAP_ReportInfo> nodes = new List<SAP_ReportInfo>();
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

                    SAP_ReportInfo node = new SAP_ReportInfo();
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
                    node.JE = table.GetDecimal("JE");
                    node.Unit2 = table.GetString("UNIT");
                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<SAP_ReportInfo> ZKMX(string customer, string dateStart, string dateEnd)
        {
            IList<SAP_ReportInfo> nodes = new List<SAP_ReportInfo>();
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

                    SAP_ReportInfo node = new SAP_ReportInfo();
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

        public string SAP_CPFL(string I_MATNR)
        {
            IRfcFunction func = RFC.Function("ZSD_GET_CPFL");
            func.SetValue("I_MATNR", I_MATNR);

            string SAP_CPFL = "";
            try
            {
                RFC.Invoke(func, false);
                SAP_CPFL = func.GetString("O_ZHWGG");

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return SAP_CPFL;
        }
        public SAP_RWJDInfo SAP_RWJD(string customer, string year, string dateStart, string dateEnd)
        {
            IRfcFunction func = RFC.Function("ZSD_GET_RWJD");
            func.SetValue("I_KUNNR", customer);
            func.SetValue("I_YEAR", year);
            func.SetValue("I_START", dateStart);
            func.SetValue("I_END", dateEnd);

            SAP_RWJDInfo node = new SAP_RWJDInfo();
            try
            {
                RFC.Invoke(func, false);
                node.Task1 = func.GetDecimal("O_TASK");
                node.Task2 = func.GetDecimal("O_TASK1");
                node.Jz1 = func.GetDecimal("O_JZ3");
                node.Jz2 = func.GetDecimal("O_JZ4");

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }
        public SAP_RWXSInfo SAP_RWXS(string customer, string dateStart, string dateEnd)
        {
            IRfcFunction func = RFC.Function("ZSD_GET_RWJD1");
            func.SetValue("I_KUNNR", customer);
            func.SetValue("I_START", dateStart);
            func.SetValue("I_END", dateEnd);

            SAP_RWXSInfo node = new SAP_RWXSInfo();
            try
            {
                RFC.Invoke(func, false);
                node.Jz1 = func.GetDecimal("O_JZ3");
                node.Jz2 = func.GetDecimal("O_JZ4");

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }
        /// <summary>
        /// 经销商区域促销活动，获取月均销售和数量
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="year"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        public SAP_RWJD2Info SAP_RWJD2(string customer, string dateStart, string dateEnd, string[] MATNR)
        {
            IRfcFunction func = RFC.Function("ZSD_GET_RWJD2");
            func.SetValue("I_KUNNR", customer);
            func.SetValue("I_START", dateStart);
            func.SetValue("I_END", dateEnd);
            IRfcTable i_table = func.GetTable("ET_MATNR");
            for (int i = 0; i < i_table.Count; i++)
            {
                i_table.Append();
                i_table.SetValue("MATNR", MATNR[i]);
            }


            SAP_RWJD2Info node = new SAP_RWJD2Info();
            try
            {
                RFC.Invoke(func, false);
                node.YJXS = func.GetDecimal("O_JZ3");
                node.YJSL = func.GetDecimal("O_SL3");

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public IList<ZSD_JXSKP> GET_JXSKP(string STARTDATE, string ENDDATE, IList<ZSD_JXSKP> data)
        {

            ZSD_JXSKP_RETURN rst = new ZSD_JXSKP_RETURN();
            List<ZSD_JXSKP> child_ES_ZSD_JXSKP = new List<ZSD_JXSKP>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();

            try
            {
                IRfcFunction func = RFC.Function("ZSD_GET_JXSKP");
                func.SetValue("I_START", STARTDATE);
                func.SetValue("I_END", ENDDATE);

                IRfcTable i_table_IT_ITEMDATA = func.GetTable("IT_ITEM");
                for (int i = 0; i < data.Count; i++)
                {
                    i_table_IT_ITEMDATA.Append();
                    i_table_IT_ITEMDATA.SetValue("KUNNR", data[i].KUNNR);
                    i_table_IT_ITEMDATA.SetValue("MATNR", data[i].MATNR);
                }
                func.SetValue("IT_ITEM", i_table_IT_ITEMDATA);



                RFC.Invoke(func, true);

                IRfcTable table = func.GetTable("IT_ITEM");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ZSD_JXSKP node = new ZSD_JXSKP();
                    node.KUNNR = table.GetString("KUNNR");
                    node.MATNR = table.GetString("MATNR");
                    node.KPJE = table.GetString("KPJE");
                    node.KPSL = table.GetString("KPSL");
                    node.ZHWGG1 = table.GetString("ZHWGG1");
                    child_ES_ZSD_JXSKP.Add(node);
                }



                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");

                //rst.MES_RETURN = child_MES_RETURN;
                //rst.ES_ZSD_JXSKP = child_ES_ZSD_JXSKP;

            }
            catch (Exception e)
            {
                throw e;
            }
            return child_ES_ZSD_JXSKP;


        }


    }
}
