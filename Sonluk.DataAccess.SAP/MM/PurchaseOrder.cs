using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using Sonluk.Entities.MM;
using Sonluk.Entities.SD;
using Sonluk.IDataAccess.MM;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.BC;

namespace Sonluk.DataAccess.SAP.MM
{
    public class PurchaseOrder : IPurchaseOrder
    {
        public POInfo Read(string serialNumber)
        {
            POInfo node = new POInfo();
            IRfcFunction func = RFC.Function("ZPO_READ");
            func.SetValue("PURCHASEORDER", serialNumber);
            POHeaderInfo header = new POHeaderInfo();
            List<POItemInfo> children = new List<POItemInfo>();
            try
            {
                RFC.Invoke(func, false);

                IRfcStructure struc = func.GetStructure("HEADER");
                header.Number = struc.GetString("EBELN");
                header.Company = struc.GetString("BUKRS");
                header.Category = struc.GetString("BSTYP");
                header.Type = struc.GetString("BSART");
                header.ControlIndicator = struc.GetString("BSAKZ");
                header.DeletionIndicator = struc.GetString("LOEKZ");
                header.Status = struc.GetString("STATU");
                header.CreateDate = struc.GetString("AEDAT");
                header.Creator = struc.GetString("ERNAM");
                header.ItemInterval = struc.GetString("PINCR");
                header.LastItem = struc.GetString("LPONR");
                header.Vendor = struc.GetString("LIFNR");
                header.Language = struc.GetString("SPRAS");
                header.PaymentTerms = struc.GetString("ZTERM");
                header.PurOrg = struc.GetString("EKORG");
                header.PurGroup = struc.GetString("EKGRP");
                header.VendorSales = struc.GetString("VERKF");
                header.VendorTelephone = struc.GetString("TELF1");
                header.Date = struc.GetString("BEDAT");
                header.TotalValue = struc.GetString("RLWRT");
                header.Currency = struc.GetString("WAERS");

                IRfcTable table = func.GetTable("ITEMS");
                IRfcTable accountAssign = func.GetTable("ACCOUNT_ASSIGNMENTS");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    accountAssign.CurrentIndex = i;

                    POItemInfo child = new POItemInfo();
                    child.PONumber = table.GetString("EBELN");
                    child.Number = table.GetInt("EBELP");
                    child.Plant = table.GetString("WERKS");
                    child.Material = table.GetString("MATNR");
                    child.MaterialDescription = table.GetString("TXZ01");
                    child.MatlGroup = table.GetString("MATKL");
                    child.Quantity = table.GetDecimal("MENGE");
                    child.BaseUOM = table.GetString("MEINS");
                    child.DeleteInd = table.GetString("LOEKZ");
                    child.StgeLoc = table.GetString("LGORT");
                    child.NetPrice = table.GetDecimal("NETPR");
                    child.PriceUnit = table.GetDecimal("PEINH");
                    child.NetValue = table.GetDecimal("NETWR");
                    child.CrossVlaue = table.GetDecimal("BRTWR");
                    child.TaxCode = table.GetString("MWSKZ");

                    child.Banfn = table.GetString("BANFN");
                    child.Bnfpo = table.GetInt("BNFPO");

                    child.SDDoc = accountAssign.GetString("VBELN");
                    child.SDocItem = accountAssign.GetInt("VBELP");

                    children.Add(child);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            node.Header = header;
            node.Items = children;
            return node;
        }

        public IList<POItemInfo> Read(POKeywordInfo keyword)
        {
            IList<POItemInfo> nodes = new List<POItemInfo>();
            IRfcFunction func = RFC.Function("ZPO_SELECT");
            func.SetValue("BSART", keyword.Type);
            func.SetValue("LIFNR", keyword.Vendor);
            func.SetValue("PSDATE", keyword.StartDate);
            func.SetValue("PEDATE", keyword.Date);
            func.SetValue("EBELN", keyword.Number);
            func.SetValue("EBELP", keyword.Item);
            func.SetValue("MATNR", keyword.Material);
            func.SetValue("TXZ01", keyword.MaterialDescription);
            func.SetValue("DSDATE", keyword.StartDelivDate);
            func.SetValue("DEDATE", keyword.DelivDate);
            func.SetValue("STYPE", keyword.Status);
            func.SetValue("MATKL", keyword.MatlGroup);
            func.SetValue("VBELN", keyword.SDDoc);
            func.SetValue("VBELP", keyword.SDocItem);
            func.SetValue("EKGRP", keyword.PurGroup);
            func.SetValue("SDATE", keyword.DisplayGRDate);
            func.SetValue("FRGGR", keyword.ReleaseGroup);
            func.SetValue("SFLAG", keyword.DisplayMRDate);
            func.SetValue("PRINT", keyword.DisplayPrintMinCost);
            func.SetValue("WERKS", keyword.Werks);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("ITEMS");

                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    POItemInfo node = new POItemInfo();
                    node.PONumber = table.GetString("EBELN");
                    node.Number = table.GetInt("EBELP");
                    node.Line = table.GetInt("ETENR");
                    node.Plant = table.GetString("WERKS");
                    node.Date = table.GetString("BEDAT");
                    node.Material = table.GetString("MATNR");
                    node.MaterialDescription = table.GetString("TXZ01");
                    node.Quantity = table.GetDecimal("MENGE");
                    node.DelivQty = table.GetDecimal("WEMNG");
                    node.BaseUOM = table.GetString("MEINS");
                    node.SDDoc = table.GetString("VBELN");
                    node.SDocItem = table.GetInt("VBELP");
                    node.DelivDate = table.GetString("EINDT");
                    node.SubjToR = table.GetString("FRGRL");
                    node.DeleteInd = table.GetString("LOEKZ");
                    node.CustChngStatus = table.GetString("AESKD");
                    node.Remarks = table.GetString("ZMMEMO");
                    node.OldMatl = table.GetString("BISMT");
                    node.MatlGroup = table.GetString("MATKL");
                    node.PurGroup = table.GetString("EKGRP");
                    if (!string.IsNullOrEmpty(table.GetString("NPLNR")))
                    {
                        node.Aufnr = table.GetString("NPLNR").Substring(2, table.GetString("NPLNR").Length - 2);
                    }
                    
                    if (table.GetString("ELIKZ").Equals("X"))
                    {
                        node.NoMoreGR = "交货已清";
                    }
                    else
                    {
                        node.NoMoreGR = "交货未清";
                    }

                    if (!table.GetString("BUDAT").Equals("0000-00-00"))
                        node.PstngDate = table.GetString("BUDAT");
                    if (!table.GetString("BLDAT").Equals("0000-00-00"))
                        node.DocDate = table.GetString("BLDAT");
                    if (!table.GetString("EDATU").Equals("0000-00-00"))
                        node.ReqDate = table.GetString("EDATU");

                    node.StgeLoc = table.GetString("LGORT");
                    node.Vendor = table.GetString("LIFNR");

                    if (!table.GetString("PRINT_DATE").Equals("0000-00-00"))
                    {
                        node.PrintDate = table.GetString("PRINT_DATE");
                        node.PrintTime = table.GetString("PRINT_TIME");

                    }
                    node.DelivDest = table.GetString("DELIVERY_DEST");
                    node.DelivDestID = table.GetInt("DELIVERY_DEST_ID");
                    node.DelivDate_M = table.GetString("EINDT_M");
                    node.Quantity_M = table.GetString("MENGE_M");
                    node.PcsInCtn = table.GetInt("XZS");
                    node.PlantName = table.GetString("NAME1");
                    node.PcsInPal = table.GetInt("TSL");
                    node.Status = table.GetInt("STATUS")==1?true:false;
                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<POItemInfo> Read(SOKeywordInfo keyword)
        {
            IList<POItemInfo> nodes = new List<POItemInfo>();
            IRfcFunction func = RFC.Function("ZPO_READ_SO");

            func.SetValue("VBELN", keyword.Number);
            func.SetValue("VBELP", keyword.Item);
            func.SetValue("MATNR", keyword.Material);
            func.SetValue("FRGGR", keyword.ReleaseGroup);

            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("ITEMS");

                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    POItemInfo node = new POItemInfo();
                    node.PONumber = table.GetString("EBELN");
                    node.Number = table.GetInt("EBELP");
                    node.Line = table.GetInt("ETENR");
                    node.Plant = table.GetString("WERKS");
                    node.Date = table.GetString("BEDAT");
                    node.Material = table.GetString("MATNR");
                    node.MaterialDescription = table.GetString("TXZ01");
                    node.Quantity = table.GetDecimal("MENGE");
                    node.DelivQty = table.GetDecimal("WEMNG");
                    node.BaseUOM = table.GetString("MEINS");
                    node.SDDoc = table.GetString("VBELN");
                    node.SDocItem = table.GetInt("VBELP");
                    node.DelivDate = table.GetString("EINDT");
                    node.SubjToR = table.GetString("FRGRL");
                    node.DeleteInd = table.GetString("LOEKZ");
                    node.CustChngStatus = table.GetString("AESKD");
                    node.Remarks = table.GetString("ZMMEMO");
                    node.OldMatl = table.GetString("BISMT");
                    node.MatlGroup = table.GetString("MATKL");
                    node.PurGroup = table.GetString("EKGRP");
                    if (table.GetString("ELIKZ").Equals("X"))
                    {
                        node.NoMoreGR = "交货已清";
                    }
                    else
                    {
                        node.NoMoreGR = "交货未清";
                    }

                    if (!table.GetString("BUDAT").Equals("0000-00-00"))
                        node.PstngDate = table.GetString("BUDAT");
                    if (!table.GetString("BLDAT").Equals("0000-00-00"))
                        node.DocDate = table.GetString("BLDAT");
                    if (!table.GetString("EDATU").Equals("0000-00-00"))
                        node.ReqDate = table.GetString("EDATU");
                    node.StgeLoc = table.GetString("LGORT");
                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public string ResetRelease(string number, string releaseCode)
        {
            IRfcFunction func = RFC.Function("BAPI_PO_RESET_RELEASE");
            func.SetValue("PURCHASEORDER", number);
            func.SetValue("PO_REL_CODE", releaseCode);
            func.SetValue("USE_EXCEPTIONS", "");
            string code = "";
            try
            {
                RFC.Invoke(func, true);
                if (func.GetString("REL_INDICATOR_NEW").Equals("X"))
                {
                    code = "X";
                }
                else
                {
                    IRfcTable returnTable = func.GetTable("RETURN");
                    returnTable.CurrentIndex = 0;
                    code = returnTable.GetString("CODE");
                    //Console.WriteLine("RR:" + returnTable.GetString("MESSAGE"));
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return code;
        }

        public string Release(string number, string releaseCode)
        {
            IRfcFunction func = RFC.Function("BAPI_PO_RELEASE");
            func.SetValue("PURCHASEORDER", number);
            func.SetValue("PO_REL_CODE", releaseCode);
            func.SetValue("USE_EXCEPTIONS", "");
            string code = "";
            try
            {
                RFC.Invoke(func, true);
                if (func.GetString("REL_STATUS_NEW").Equals("X"))
                {
                    code = "X";
                }
                else
                {
                    IRfcTable returnTable = func.GetTable("RETURN");
                    returnTable.CurrentIndex = 0;
                    code = returnTable.GetString("CODE");
                    //Console.WriteLine("R:" + returnTable.GetString("MESSAGE"));
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return code;
        }

        public string UpdateDeliveryDate(POItemInfo node)
        {

            IRfcFunction func = RFC.Function("BAPI_PO_CHANGE");
            func.SetValue("PURCHASEORDER", node.PONumber);
            IRfcTable rfcTable = func.GetTable("POSCHEDULE");
            rfcTable.Append(1);
            rfcTable.CurrentIndex = 0;
            rfcTable.SetValue("PO_ITEM", node.Number);
            rfcTable.SetValue("SCHED_LINE", node.Line);
            rfcTable.SetValue("DEL_DATCAT_EXT", "D");
            rfcTable.SetValue("DELIVERY_DATE", node.DelivDate.Replace("-", ""));

            IRfcTable rfcTableX = func.GetTable("POSCHEDULEX");
            rfcTableX.Append(1);
            rfcTableX.CurrentIndex = 0;
            rfcTableX.SetValue("PO_ITEM", node.Number);
            rfcTableX.SetValue("PO_ITEMX", "X");
            rfcTableX.SetValue("SCHED_LINE", node.Line);
            rfcTableX.SetValue("SCHED_LINEX", "X");
            rfcTableX.SetValue("DEL_DATCAT_EXT", "X");
            rfcTableX.SetValue("DELIVERY_DATE", "X");

            string code = "";
            try
            {
                RFC.Invoke(func, true);
                IRfcTable returnTable = func.GetTable("RETURN");
                returnTable.CurrentIndex = 0;
                code = returnTable.GetString("NUMBER");

                //for (int i = 0; i < returnTable.RowCount; i++)
                //{
                //    returnTable.CurrentIndex = i;
                //    Console.WriteLine("U:" + returnTable.GetString("MESSAGE"));
                //}
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return code;
        }

        public string UpdateSchedule(POInfo node)
        {

            IRfcFunction func = RFC.Function("BAPI_PO_CHANGE");
            func.SetValue("PURCHASEORDER", node.Header.Number);
            IRfcTable rfcTable = func.GetTable("POSCHEDULE");
            IRfcTable rfcTableX = func.GetTable("POSCHEDULEX");

            int index=0;
            foreach (POItemInfo item in node.Items)
            {
                foreach (ScheduleLineInfo line in item.Schedule)
                {
                    rfcTable.Append(1);
                    rfcTable.CurrentIndex = index;
                    rfcTable.SetValue("PO_ITEM", item.Number);
                    rfcTable.SetValue("SCHED_LINE", line.Line);
                    rfcTable.SetValue("QUANTITY", line.Quantity);
                    rfcTable.SetValue("DEL_DATCAT_EXT", "D");
                    rfcTable.SetValue("DELIVERY_DATE",line.Date.Replace("-",""));
                    rfcTable.SetValue("DELETE_IND", line.Delete);

                    // Add by xsw
                    rfcTable.SetValue("PREQ_NO", item.Banfn);
                    rfcTable.SetValue("PREQ_ITEM", item.Bnfpo);
                    ///////////////////////////////////////////////
                    
                    rfcTableX.Append(1);
                    rfcTableX.CurrentIndex = index++;
                    rfcTableX.SetValue("PO_ITEM", item.Number);
                    rfcTableX.SetValue("PO_ITEMX", "X");
                    rfcTableX.SetValue("SCHED_LINE", line.Line);
                    rfcTableX.SetValue("SCHED_LINEX", "X");
                    rfcTableX.SetValue("QUANTITY", "X");
                    rfcTableX.SetValue("DEL_DATCAT_EXT", "X");
                    rfcTableX.SetValue("DELIVERY_DATE", "X");
                    rfcTableX.SetValue("DELETE_IND", "X");

                    // Add by xsw
                    rfcTableX.SetValue("PREQ_NO", "X");
                    rfcTableX.SetValue("PREQ_ITEM", "X");
                    ///////////////////////////////////////////////
                }
            }

            string code = "";
            try
            {
                RFC.Invoke(func, true);
                IRfcTable returnTable = func.GetTable("RETURN");
                returnTable.CurrentIndex = 0;
                code = returnTable.GetString("NUMBER");

                //for (int i = 0; i < returnTable.RowCount; i++)
                //{
                //    returnTable.CurrentIndex = i;
                //    Console.WriteLine("U:" + returnTable.GetString("MESSAGE"));
                //}
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return code;
        }

        public IList<POItemHistoryInfo> History(string number, int itemNumber)
        {
            IList<POItemHistoryInfo> nodes = new List<POItemHistoryInfo>();
            IRfcFunction func = RFC.Function("ZVDPOHIS");
            func.SetValue("EBELN", number);
            func.SetValue("EBELP", itemNumber);

            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("TEKBE");

                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    POItemHistoryInfo node = new POItemHistoryInfo();
                    node.PONumber = table.GetString("EBELN");
                    node.Number = table.GetInt("EBELP");
                    node.PocessID = table.GetString("VGABE");
                    node.FiscalYear = table.GetInt("GJAHR");
                    node.MatDoc = table.GetString("BELNR");
                    node.AccDocItemCount = table.GetInt("BUZEI");
                    node.HistType = table.GetString("BEWTP");
                    node.MoveType = table.GetString("BWART");
                    node.PstngDate = table.GetString("BUDAT");
                    node.Quantity = table.GetDouble("MENGE");
                    node.QtyInPriceUnit = table.GetDouble("BPMNG");
                    node.ValLocCurr = table.GetString("DMBTR");
                    node.ValDocCurr = table.GetString("WRBTR");
                    node.Currency = table.GetString("WAERS");
                    node.GRIRValLocCurr = table.GetString("AREWR");
                    node.BlockedQty = table.GetDouble("WESBS");
                    node.GRBlockedQty = table.GetDouble("BPWES");
                    node.DbCrInd = table.GetString("SHKZG");                   


                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public bool UpdatePrintDate(string number, string date, string time)
        {
            IRfcFunction func = RFC.Function("ZPO_PRINT_DATE_UPDATE");
            func.SetValue("PURCHASEORDER", number);
            func.SetValue("DATE", date);
            func.SetValue("TIME", time);
            bool code = false;
            try
            {
                RFC.Invoke(func, true);
                code = true;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return code;
        }

        public IList<CustomTextInfo> CustomText(string serialNumber, int item)
        {
            IList<CustomTextInfo> nodes = new List<CustomTextInfo>();
            IRfcFunction func = RFC.Function("ZPO_TEXT_READ");

            func.SetValue("PURCHASEORDER", serialNumber);
            func.SetValue("ITEM", item);

            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("TEXT_LINE");

                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    CustomTextInfo node = new CustomTextInfo();
                    node.ID = table.GetString("TDID");
                    node.Title = table.GetString("TDTEXT");
                    node.Content = table.GetString("TDLINE");
                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<ScheduleLineInfo> Schedule(string serialNumber, int item)
        {
            IList<ScheduleLineInfo> nodes = new List<ScheduleLineInfo>();
            IRfcFunction func = RFC.Function("ZPO_SCHEDULE_LINE_READ");

            func.SetValue("PURCHASEORDER", serialNumber);
            func.SetValue("ITEM", item);

            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("SCHEDULE_LINE");

                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ScheduleLineInfo node = new ScheduleLineInfo();
                    node.Number = table.GetString("EBELN");
                    node.Item = table.GetInt("EBELP");
                    node.Line = table.GetInt("ETENR");
                    node.Date = table.GetString("EINDT");
                    node.Quantity = table.GetDecimal("MENGE");
                    node.PrevQty = table.GetDecimal("AMENG");
                    node.GRQTY = table.GetDecimal("WAMNG");
                    node.IssuedQty = table.GetDecimal("WAMNG");
                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }


        public string ZBCFUN_RKBS_CHANGE(string IV_TPM, string IV_MODE, string IV_USER)
        {
            IRfcFunction func = RFC.Function("ZBCFUN_RKBS_CHANGE");
            func.SetValue("IV_TPM", IV_TPM);
            func.SetValue("IV_MODE", IV_MODE);
            func.SetValue("IV_USER", IV_USER);
           
            string rtn = "";
            try
            {
                RFC.Invoke(func, true);

                //返回消息
                IRfcTable ET_RETURN = func.GetTable("ET_RETURN");
                for (int i = 0; i < ET_RETURN.RowCount; i++)
                {
                    ET_RETURN.CurrentIndex = i;
                    rtn = rtn + ET_RETURN.GetString("MESSAGE") + "\r\n";
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return rtn;
        }
        public string ZMMFUN_GCDZ_READ(string werks)
        {            
            IRfcFunction func = RFC.Function("ZMMFUN_GCDZ_READ");
            func.SetValue("IV_WERKS", werks);
            try
            {
                RFC.Invoke(func, true);
                return func.GetString("EV_GCDZ");
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
           
        }
        public ZMMFUN_PURBS_READ ZMMFUN_PURBS_READ(List<ZSL_BCS303_CT> IT_PURCT)
        {
            ZMMFUN_PURBS_READ rst = new ZMMFUN_PURBS_READ();
            rst.MES_RETURN   = new Entities.MES.MES_RETURN();
            rst.ZSL_BCS303_BS = new List<ZSL_BCS303_BS>();
            ZSL_BCS303_BS zsl_bcs303_bs = new ZSL_BCS303_BS();
            IRfcFunction func = RFC.Function("ZMMFUN_PURBS_READ");
            IRfcTable i_table = func.GetTable("IT_PURCT");

            for (int i = 0; i < IT_PURCT.Count; i++)
            {
                i_table.Append();
                i_table.SetValue("WERKS", IT_PURCT[i].Werks);
                i_table.SetValue("LGORT", IT_PURCT[i].Lgort);
                i_table.SetValue("MBLNR", IT_PURCT[i].Mblnr);
                i_table.SetValue("MJAHR", IT_PURCT[i].Mjahr);
                i_table.SetValue("ZEILE", IT_PURCT[i].Zeile);
                i_table.SetValue("EBELN", IT_PURCT[i].Ebeln);
                i_table.SetValue("EBELP", IT_PURCT[i].Ebelp);
                i_table.SetValue("LIFNR", IT_PURCT[i].Lifnr);
                i_table.SetValue("BUDAT_ST", IT_PURCT[i].Budat_st);
                i_table.SetValue("BUDAT_ED", IT_PURCT[i].Budat_ed);
                i_table.SetValue("MATNR", IT_PURCT[i].Matnr);
                i_table.SetValue("CHARG", IT_PURCT[i].Charg);
                i_table.SetValue("CPUDT_ST", IT_PURCT[i].Cpudt_st);
                i_table.SetValue("CPUDT_ED", IT_PURCT[i].Cpudt_ed);
                i_table.SetValue("CPUTM_ST", IT_PURCT[i].Cputm_st);
                i_table.SetValue("CPUTM_ED", IT_PURCT[i].Cputm_ed);
            }          
            try
            {
                RFC.Invoke(func, true);
                IRfcTable res_table = func.GetTable("ET_PURBS");
                for (int i = 0; i < res_table.RowCount; i++)
                {
                    res_table.CurrentIndex = i;
                    ZSL_BCS303_BS node = new ZSL_BCS303_BS();
                    node.Mblnr = res_table.GetString("MBLNR");
                    node.Mjahr = res_table.GetString("MJAHR");
                    node.Zeile = res_table.GetString("ZEILE");
                    node.Line_id = res_table.GetString("LINE_ID");
                    node.Matnr = res_table.GetString("MATNR");
                    node.Maktx = res_table.GetString("MAKTX");
                    node.Matkl = res_table.GetString("MATKL");
                    node.Wldl = res_table.GetString("WLDL");
                    node.Mtart = res_table.GetString("MTART");
                    node.Dcxh = res_table.GetString("DCXH");
                    node.Dcdj = res_table.GetString("DCDJ");
                    node.Werks = res_table.GetString("WERKS");
                    node.Lgort = res_table.GetString("LGORT");
                    node.Lgobe = res_table.GetString("LGOBE");
                    node.Ebeln = res_table.GetString("EBELN");
                    node.Ebelp = res_table.GetString("EBELP");
                    node.Charg = res_table.GetString("CHARG");
                    node.Licha = res_table.GetString("LICHA");
                    node.Lifnr = res_table.GetString("LIFNR");
                    node.Sortl = res_table.GetString("SORTL");
                    node.Budat = res_table.GetString("BUDAT");
                    node.Wwbs = res_table.GetString("WWBS");
                    node.Zsbs = res_table.GetString("ZSBS");
                    node.Xcbs = res_table.GetString("XCBS");
                    node.Gy = res_table.GetString("GY");
                    node.Sbh = res_table.GetString("SBH");
                    node.Clcj = res_table.GetString("CLCJ");
                    node.Xs = res_table.GetString("XS");
                    node.Menge = res_table.GetString("MENGE");
                    node.Meins = res_table.GetString("MEINS");
                    node.Mat_kdauf = res_table.GetString("MAT_KDAUF");
                    node.Mat_kdpos = res_table.GetString("MAT_KDPOS");
                    node.Wempf = res_table.GetString("WEMPF");
                    node.Bwart = res_table.GetString("BWART");
                    node.Lfbnr = res_table.GetString("LFBNR");
                    node.Lfpos = res_table.GetString("LFPOS");
                    node.Lfbja = res_table.GetString("LFBJA");
                    rst.ZSL_BCS303_BS.Add(node);
                }
              
               
                IRfcTable table_CT_RETURN = func.GetTable("CT_RETURN");
                table_CT_RETURN.CurrentIndex = 0;
                rst.MES_RETURN.TYPE = table_CT_RETURN.GetString("TYPE");
                rst.MES_RETURN.MESSAGE = table_CT_RETURN.GetString("MESSAGE");
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
               
            }
            return rst;
        }
        public StorageIdentification GetRKBSPrint(string CGXM, string TPM, string GYS, int TS, int XS, int SL, string mode, string ltbs)
        {
            StorageIdentification l_si = new StorageIdentification();
            l_si.Zsl_bcs104 = new List<ZSL_BCS104>();
            l_si.ET_RETURN = "";

            IRfcFunction func = RFC.Function("ZBCFUN_PRT_007");
            func.SetValue("IV_CGXM", CGXM);
            //func.SetValue("IV_TPM", TPM);
            func.SetValue("IV_GYS", GYS);
            func.SetValue("IV_TS", TS);
            func.SetValue("IV_XS", XS);
            func.SetValue("IV_SL", SL);
            func.SetValue("IV_MODE", mode);
            func.SetValue("IV_LTBS", ltbs);

            string[] la_tpm = TPM.Split(Environment.NewLine.ToCharArray());
            
            //传入托盘码
            IRfcTable IT_TPM = func.GetTable("IT_TPM");
            for (int i = 0; i < la_tpm.Length; i++)
            {
                if (la_tpm[i].Trim()!="")
                { 
                    IT_TPM.Append();
                    IT_TPM.SetValue("TPM", la_tpm[i]);
                }
            }
            func.SetValue("IT_TPM", IT_TPM);

            try
            {
                RFC.Invoke(func, false);
                l_si.IdentificationPDF = func.GetByteArray("EV_PDF_BIN");
                //IRfcStructure struc = func.GetStructure("ET_RETURN");

                IRfcTable ET_TPM = func.GetTable("ET_TPM");

                for (int i = 0; i < ET_TPM.RowCount; i++)
                {
                    ET_TPM.CurrentIndex = i;

                    ZSL_BCS104 node = new ZSL_BCS104();
                    node.Tpm = ET_TPM.GetString("TPM");
                    node.Sl = ET_TPM.GetInt("SL");
                    node.Scsl = ET_TPM.GetInt("SCSL");
                    node.Zbtxs = ET_TPM.GetInt("ZBTXS");
                    node.Ztxh = ET_TPM.GetInt("ZTXH");
                    node.Zts = ET_TPM.GetInt("ZTS");
                    node.Cjrq = ET_TPM.GetString("CJRQ");
                    node.Cjsj = ET_TPM.GetString("CJSJ");
                    node.Cjr = ET_TPM.GetString("CJR");
                    node.Flg = ET_TPM.GetString("FLG");
                    l_si.Zsl_bcs104.Add(node);
                }

                //返回消息
                IRfcTable ET_RETURN = func.GetTable("ET_RETURN");
                for (int i = 0; i < ET_RETURN.RowCount; i++)
                {
                    ET_RETURN.CurrentIndex = i;
                    l_si.ET_RETURN = l_si.ET_RETURN + ET_RETURN.GetString("MESSAGE") + "\r\n"; 
                }
            }
            catch (Exception e)
            {
                l_si.ET_RETURN = l_si.ET_RETURN + e.Message;
                throw new ApplicationException(e.Message);
            }
            return l_si;
        }

        public StorageIdentification GetRKBSZHPrint(int GLTS, string DYFS, string USER, string MODE, int FS, IList<ZSL_BCS104> itemNodes)
        {
            StorageIdentification l_si = new StorageIdentification();
            l_si.Zsl_bcs104 = new List<ZSL_BCS104>();
            l_si.ET_RETURN = "";

            IRfcFunction func = RFC.Function("ZBCFUN_ZHZYL_READ");
            func.SetValue("IV_GLTS", GLTS);
            func.SetValue("IV_DYFS", DYFS);
            func.SetValue("IV_USER", USER);
            func.SetValue("IV_MODE", MODE);
            //func.SetValue("IV_FS", FS);

            //string[] la_list = PLIST.Split(Environment.NewLine.ToCharArray());

            //传入行项目信息
            IRfcTable IT_LIST = func.GetTable("CT_BCS104");
            foreach (ZSL_BCS104 pi in itemNodes)
            {
                IT_LIST.Append();
                IT_LIST.SetValue("TPM", pi.Tpm);
                IT_LIST.SetValue("SL", pi.Sl);
                IT_LIST.SetValue("SCSL", pi.Scsl);
                IT_LIST.SetValue("zbtxs", pi.Zbtxs);
                IT_LIST.SetValue("ztxh", pi.Ztxh);
                IT_LIST.SetValue("zts", pi.Zts);
                IT_LIST.SetValue("cjrq", pi.Cjrq);
                IT_LIST.SetValue("cjr", pi.Cjr);
                IT_LIST.SetValue("cjsj", pi.Cjsj);
                IT_LIST.SetValue("flg", pi.Flg);
                IT_LIST.SetValue("ebeln", pi.Ebeln);
                IT_LIST.SetValue("ebelp", Convert.ToInt32(pi.Ebelp));
                IT_LIST.SetValue("eindt", pi.Eindt);
                IT_LIST.SetValue("matnr", pi.Matnr);
                IT_LIST.SetValue("txz01", pi.Txz01);
                IT_LIST.SetValue("zsl", pi.Zsl);
                IT_LIST.SetValue("wssl", pi.Wssl);
                IT_LIST.SetValue("meins", pi.Meins);
                IT_LIST.SetValue("vbeln", pi.Vbeln);
                IT_LIST.SetValue("vbelp", pi.Vbelp);
                IT_LIST.SetValue("yglts", pi.Yglts);
                IT_LIST.SetValue("zj", pi.Zj);
                IT_LIST.SetValue("zhm", pi.Zhm);                
                IT_LIST.SetValue("zxs", pi.Zxs);
                IT_LIST.SetValue("CGXM", pi.Ebeln + pi.Ebelp.ToString().PadLeft(5, '0') + Environment.NewLine.ToString());
            }

            func.SetValue("CT_BCS104", IT_LIST);

            try
            {
                RFC.Invoke(func, false);
                l_si.IdentificationPDF = func.GetByteArray("EV_PDF_BIN");

                IRfcTable ET_TPM = func.GetTable("CT_BCS104");

                for (int i = 0; i < ET_TPM.RowCount; i++)
                {
                    ET_TPM.CurrentIndex = i;

                    ZSL_BCS104 node = new ZSL_BCS104();                    										
    
                    node.Tpm = ET_TPM.GetString("TPM");
                    node.Sl = ET_TPM.GetInt("SL");
                    node.Scsl = ET_TPM.GetInt("SCSL");
                    node.Zbtxs = ET_TPM.GetInt("ZBTXS");
                    node.Ztxh = ET_TPM.GetInt("ZTXH");
                    node.Zts = ET_TPM.GetInt("ZTS");
                    node.Cjrq = ET_TPM.GetString("CJRQ");
                    node.Cjsj = ET_TPM.GetString("CJSJ");
                    node.Cjr = ET_TPM.GetString("CJR");
                    node.Flg = ET_TPM.GetString("FLG");
                    node.Ebeln = ET_TPM.GetString("EBELN");
                    node.Ebelp = ET_TPM.GetInt("EBELP").ToString();
                    node.Eindt = ET_TPM.GetString("EINDT");
                    node.Matnr = ET_TPM.GetString("MATNR");
                    node.Txz01 = ET_TPM.GetString("TXZ01");
                    node.Zsl = ET_TPM.GetInt("ZSL");
                    node.Wssl = ET_TPM.GetInt("WSSL");
                    node.Meins = ET_TPM.GetString("MEINS");
                    node.Vbeln = ET_TPM.GetString("VBELN");
                    node.Vbelp = ET_TPM.GetString("VBELP");
                    node.Yglts = ET_TPM.GetInt("YGLTS");
                    node.Zj = ET_TPM.GetString("ZJ");
                    node.Zhm = ET_TPM.GetString("ZHM");
                    node.Zxs = ET_TPM.GetInt("ZXS");
                    l_si.Zsl_bcs104.Add(node);
                }

                //返回消息
                IRfcTable ET_RETURN = func.GetTable("CT_RETURN");
                for (int i = 0; i < ET_RETURN.RowCount; i++)
                {
                    ET_RETURN.CurrentIndex = i;
                    l_si.ET_RETURN = l_si.ET_RETURN + ET_RETURN.GetString("MESSAGE") + "\r\n";
                }
            }
            catch (Exception e)
            {
                l_si.ET_RETURN = l_si.ET_RETURN + e.Message;
                throw new ApplicationException(e.Message);
            }
            return l_si;
        }
    }
}
