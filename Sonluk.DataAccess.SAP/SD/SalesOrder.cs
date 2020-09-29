using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using Sonluk.Entities.SD;
using Sonluk.IDataAccess.SD;
using Sonluk.Entities.MM;
using Sonluk.DataAccess.SAP.Utility;

namespace Sonluk.DataAccess.SAP.SD
{
    public class SalesOrder : ISalesOrder
    {
        public string Create(SOInfo node)
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
            foreach (SOItemInfo item in node.Items)
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

        public IList<SOItemInfo> Read(SOKeywordInfo node)
        {
            IList<SOItemInfo> children= new List<SOItemInfo>();
            IRfcFunction func = RFC.Function("ZSOQUERYTEXT");

            func.SetValue("VBELN", node.Number);
            func.SetValue("POSNR", node.Item);
            func.SetValue("POTAG", node.ProcessingRecordsStatus);
            func.SetValue("ERDATB", node.StartDate);
            func.SetValue("ERDATE", node.Date);
            func.SetValue("AEDATB",node.StartChangedDate);
            func.SetValue("AEDATE", node.ChangedDate);
            func.SetValue("WERKS", node.Plant);
            func.SetValue("ERNAM", node.Creator);
            func.SetValue("SYDATUMB", node.StartCurrentDate);
            func.SetValue("SYDATUME", node.CurrentDate);


            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("ZSOPOI");

                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    SOItemInfo child = new SOItemInfo();
                    child.SONumber = table.GetString("VBELN");
                    child.Number = table.GetInt("POSNR");
                    child.MatlDesc = table.GetString("ZZMAKTX");
                    child.Date = table.GetString("ERDAT");
                    child.ChangedDate = table.GetString("AEDAT");
                    child.Plant = table.GetString("WERKS");
                    child.ReqDate = table.GetString("EDATU");
                    child.Creator = table.GetString("ERNAM");
                    child.Remarks = table.GetString("ZMMEMO");
                    child.RequestPallet = table.GetString("TPGB");
                    child.RequestSpecific = table.GetString("TSCG");
                    child.RequestShrinkFilm  = table.GetString("RSM");
                    child.RequestRemarks = table.GetString("DDBZ");
                    if (!table.GetString("GSTRP").Equals("0000-00-00"))
                        child.StartDate = table.GetString("GSTRP");
                    child.ProcType = table.GetString("BESKZ");
                    child.DelivStatus= table.GetString("LFSTA");
                    child.Status = table.GetString("TXT04");
                    child.StatusDesc = table.GetString("TXT30");
                    child.Vendor = table.GetString("LIFNR_PO");
                    child.Type = table.GetString("AUART");
                    children.Add(child);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return children;
        }

        public string ProcessingRecords(SOItemInfo node)
        {
            IRfcFunction func = RFC.Function("ZSOPOUPDATE");
            func.SetValue("VBELN", node.SONumber);
            func.SetValue("POSNR", node.Number);
            func.SetValue("ZMMEMO", node.Remarks);
            func.SetValue("POTAG", node.ProcessingRecordsStatus);
            func.SetValue("DELETE", node.ProcessingRecordsDelete);
            string code = "0";
            try
            {
                RFC.Invoke(func, true);
                code = func.GetString("OKCODE");
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return code;
        }

        public IList<CustomTextInfo> CustomText(string serialNumber, int item, string matlGroup)
        {
            IList<CustomTextInfo> nodes = new List<CustomTextInfo>();
            IRfcFunction func = RFC.Function("ZSD_TEXT_READ");

            func.SetValue("SALESORDER", serialNumber);
            func.SetValue("ITEM", item);
            func.SetValue("MATKL", matlGroup);

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

    }
}
