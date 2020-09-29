using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.MM;
using Sonluk.IDataAccess.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.MM
{
    public class ScheduleRequisition : IScheduleRequisition
    {
        public string Create(ScheReqInfo node)
        {
            IRfcFunction func = RFC.Function("ZPO_SCHE_REQ_CREATE");
            IRfcStructure importStruc = func.GetStructure("SCHE_REQ");

            importStruc.SetValue("REMARK", node.Remark);
            importStruc.SetValue("CREATOR", node.Creator);
            importStruc.SetValue("CREATE_DATE", node.Date);
            importStruc.SetValue("CREATE_TIME", node.Time);
            importStruc.SetValue("STATUS", node.Status);

            IRfcTable importTable = func.GetTable("ITEMS");
            int index = 0;
            foreach (ScheduleLineInfo item in node.Items)
            {
                importTable.Append(1);
                importTable.CurrentIndex = index++;
                importTable.SetValue("PURCHASEORDER", item.Number);
                importTable.SetValue("ITEM", item.Item);
                importTable.SetValue("LINE", item.Line);
                importTable.SetValue("SALESORDER", item.SalesOrder);
                importTable.SetValue("SO_ITEM", item.SOItem);
                importTable.SetValue("MATERIAL", item.Material);
                importTable.SetValue("MATL_DESC", item.MaterialDescription);
                importTable.SetValue("INITIAL_QUANTITY", item.InitialQuantity);
                importTable.SetValue("QUANTITY", item.Quantity);
                importTable.SetValue("INITIAL_DELIV_DATE", item.InitialDate);
                importTable.SetValue("DELIVERY_DATE", item.Date);
                importTable.SetValue("DELIVERY_DEST_ID", item.DestinationID);
                importTable.SetValue("VENDOR", item.Vendor);
                importTable.SetValue("PUR_GROUP", item.PurGroup);
                importTable.SetValue("STATUS", item.Status);

            }

            string serialNumber = "";
            try
            {
                RFC.Invoke(func, false);
                serialNumber = func.GetString("SN");

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return serialNumber;
        }

        public ScheReqInfo Read(string serialNumber)
        {
            IRfcFunction func = RFC.Function("ZPO_SCHE_REQ_READ");
            func.SetValue("SN", serialNumber);

            ScheReqInfo node = new ScheReqInfo();
            try
            {
                RFC.Invoke(func, false);

                IRfcStructure struc = func.GetStructure("SCHE_REQ");
                node.SerialNumber = struc.GetString("SN");

                node.Remark = struc.GetString("REMARK");
                node.Creator = struc.GetString("CREATOR");
                node.Date = struc.GetString("CREATE_DATE");
                node.Time = struc.GetString("CREATE_TIME");
                node.NodePPCtrl = struc.GetString("NODE_PPCTRL");
                if (!struc.GetString("NODE_PPCTRL_DATE").Equals("0000-00-00"))
                {
                    node.NodePPCtrlDate = struc.GetString("NODE_PPCTRL_DATE");
                    node.NodePPCtrlTime = struc.GetString("NODE_PPCTRL_TIME");
                }  
                node.NodePur = struc.GetString("NODE_PUR");
                if (!struc.GetString("NODE_PUR_DATE").Equals("0000-00-00"))
                {
                    node.NodePurDate = struc.GetString("NODE_PUR_DATE");
                    node.NodePurTime = struc.GetString("NODE_PUR_TIME");
                }                    
                node.NodePurCtrl = struc.GetString("NODE_PURCTRL");
                if (!struc.GetString("NODE_PURCTRL_DATE").Equals("0000-00-00"))
                {
                    node.NodePurCtrlDate = struc.GetString("NODE_PURCTRL_DATE");
                    node.NodePurCtrlTime = struc.GetString("NODE_PURCTRL_TIME");
                }
                node.NodeComments = struc.GetString("NODE_COMMENTS");
                node.Status = struc.GetString("STATUS");
                node.StatusDescription = StatusDescription(node.Status);

                node.Items = new List<ScheduleLineInfo>();
                IRfcTable table = func.GetTable("ITEMS");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ScheduleLineInfo child = new ScheduleLineInfo();
                    child.Number = table.GetString("PURCHASEORDER");
                    child.Item = table.GetInt("ITEM");
                    child.Line = table.GetInt("LINE");
                    child.SerialNumber = table.GetString("SN");
                    child.SalesOrder = table.GetString("SALESORDER");
                    child.SOItem = table.GetInt("SO_ITEM");
                    child.Material = table.GetString("MATERIAL");
                    child.MaterialDescription = table.GetString("MATL_DESC");
                    child.InitialQuantity = table.GetDecimal("INITIAL_QUANTITY");
                    child.Quantity = table.GetDecimal("QUANTITY");
                    child.InitialDate = table.GetString("INITIAL_DELIV_DATE");
                    child.Date = table.GetString("DELIVERY_DATE");
                    child.Destination = table.GetString("DELIVERY_DEST");
                    child.DestinationID = table.GetString("DELIVERY_DEST_ID");
                    child.Vendor = table.GetString("VENDOR");
                    child.Releaser = table.GetString("RELEASER");
                    if (!table.GetString("RELEASE_DATE").Equals("0000-00-00"))
                        child.ReleaseDate = table.GetString("RELEASE_DATE") + " " + table.GetString("RELEASE_TIME");
                    child.PurGroup = table.GetString("PUR_GROUP");
                    child.Status = table.GetInt("STATUS");
                    child.StatusDescription = ItemStatusDescription(child.Status);

                    node.Items.Add(child);
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public IList<ScheReqInfo> Read(ScheReqInfo keyword)
        {
            IRfcFunction func = RFC.Function("ZPO_SCHE_REQ_SELECT");
            func.SetValue("SN", keyword.SerialNumber);
            func.SetValue("SALESORDER", keyword.SalesOrder);
            func.SetValue("ITEM", keyword.SOItem);
            func.SetValue("MATERIAL", keyword.Material);
            func.SetValue("PUR_GROUP", keyword.PurGroup);
            func.SetValue("START_DATE", keyword.Date);
            func.SetValue("END_DATE", keyword.EndDate);
            func.SetValue("CREATOR", keyword.Creator);
            func.SetValue("STATUS", keyword.Status);

            IList<ScheReqInfo> nodes = new List<ScheReqInfo>();
            try
            {
                RFC.Invoke(func, false);

                IRfcTable table = func.GetTable("SCHE_REQ");

                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ScheReqInfo node = new ScheReqInfo();
                    node.SerialNumber = table.GetString("SN");
                    node.Remark = table.GetString("REMARK");
                    node.Creator = table.GetString("CREATOR");
                    node.Date = table.GetString("CREATE_DATE") + " " + table.GetString("CREATE_TIME");
                    node.NodePPCtrl = table.GetString("NODE_PPCTRL");
                    if (!table.GetString("NODE_PPCTRL_DATE").Equals("0000-00-00"))
                        node.NodePPCtrlDate = table.GetString("NODE_PPCTRL_DATE") + " " + table.GetString("NODE_PPCTRL_TIME");
                    node.NodePur = table.GetString("NODE_PUR");
                    if (!table.GetString("NODE_PUR_DATE").Equals("0000-00-00"))
                        node.NodePurDate = table.GetString("NODE_PUR_DATE") + " " + table.GetString("NODE_PUR_TIME");
                    node.NodePurCtrl = table.GetString("NODE_PURCTRL");
                    if (!table.GetString("NODE_PURCTRL_DATE").Equals("0000-00-00"))
                        node.NodePurCtrlDate = table.GetString("NODE_PURCTRL_DATE") + " " + table.GetString("NODE_PURCTRL_TIME");
                    node.NodeComments = table.GetString("NODE_COMMENTS");
                    node.Status = table.GetString("STATUS");
                    node.StatusDescription = StatusDescription(node.Status);
                    nodes.Add(node);
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;

        }

        public bool Update(ScheReqInfo node)
        {
            IRfcFunction func = RFC.Function("ZPO_SCHE_REQ_UPDATE");
            IRfcStructure importStruc = func.GetStructure("SCHE_REQ");
            importStruc.SetValue("SN", node.SerialNumber);
            importStruc.SetValue("REMARK", node.Remark);
            importStruc.SetValue("CREATOR", node.Creator);
            importStruc.SetValue("CREATE_DATE", node.Date);
            importStruc.SetValue("CREATE_TIME", node.Time);
            importStruc.SetValue("NODE_PPCTRL", node.NodePPCtrl);
            importStruc.SetValue("NODE_PPCTRL_DATE", node.NodePPCtrlDate);
            importStruc.SetValue("NODE_PPCTRL_TIME", node.NodePPCtrlTime);
            importStruc.SetValue("NODE_PUR", node.NodePur);
            importStruc.SetValue("NODE_PUR_DATE", node.NodePurDate);
            importStruc.SetValue("NODE_PUR_TIME", node.NodePurTime);
            importStruc.SetValue("NODE_PURCTRL", node.NodePurCtrl);
            importStruc.SetValue("NODE_PURCTRL_DATE", node.NodePurCtrlDate);
            importStruc.SetValue("NODE_PURCTRL_TIME", node.NodePurCtrlTime);
            importStruc.SetValue("NODE_COMMENTS", node.NodeComments);
            importStruc.SetValue("STATUS", node.Status);

            IRfcTable importTable = func.GetTable("ITEMS");
            int index = 0;
            foreach (ScheduleLineInfo item in node.Items)
            {
                importTable.Append(1);
                importTable.CurrentIndex = index++;
                importTable.SetValue("PURCHASEORDER", item.Number);
                importTable.SetValue("ITEM", item.Item);
                importTable.SetValue("SN", item.SerialNumber);
                importTable.SetValue("LINE", item.Line);
                importTable.SetValue("SALESORDER", item.SalesOrder);
                importTable.SetValue("SO_ITEM", item.SOItem);
                importTable.SetValue("MATERIAL", item.Material);
                importTable.SetValue("MATL_DESC", item.MaterialDescription);
                importTable.SetValue("INITIAL_QUANTITY", item.InitialQuantity);
                importTable.SetValue("QUANTITY", item.Quantity);
                importTable.SetValue("INITIAL_DELIV_DATE", item.InitialDate);
                importTable.SetValue("DELIVERY_DATE", item.Date);
                importTable.SetValue("DELIVERY_DEST_ID", item.DestinationID);
                importTable.SetValue("PUR_GROUP", item.PurGroup);
                importTable.SetValue("VENDOR", item.Vendor);
                importTable.SetValue("STATUS", item.Status);

            }

            bool code = false;
            try
            {
                RFC.Invoke(func, false);
                code = true;

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return code;
        }

        public bool Delete(string serialNumber)
        {
            IRfcFunction func = RFC.Function("ZPO_SCHE_REQ_DELETE");
            func.SetValue("SN", serialNumber);

            bool code = false;
            try
            {
                RFC.Invoke(func, true);
                if (func.GetInt("SUCCESS") > 0)
                    code = true;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return code;
        }

        public IList<ScheduleLineInfo> ItemRead(ScheReqInfo keyword)
        {
            IRfcFunction func = RFC.Function("ZPO_SCHE_REQ_LINE_SELECT");
            func.SetValue("SN", keyword.SerialNumber);
            func.SetValue("SALESORDER", keyword.SalesOrder);
            func.SetValue("ITEM", keyword.SOItem);
            func.SetValue("MATERIAL", keyword.Material);
            func.SetValue("PUR_GROUP", keyword.PurGroup);
            func.SetValue("START_DATE", keyword.Date);
            func.SetValue("END_DATE", keyword.EndDate);
            func.SetValue("CREATOR", keyword.Creator);
            func.SetValue("START_SYNC_DATE", keyword.NodePurCtrlDate);
            func.SetValue("END_SYNC_DATE", keyword.NodePurCtrlEndDate);
            func.SetValue("STATUS", keyword.Status);

            IList<ScheduleLineInfo> nodes = new List<ScheduleLineInfo>();
            try
            {
                RFC.Invoke(func, false);

                IRfcTable table = func.GetTable("ITEMS");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ScheduleLineInfo child = new ScheduleLineInfo();
                    child.Number = table.GetString("PURCHASEORDER");
                    child.Item = table.GetInt("ITEM");
                    child.Line = table.GetInt("LINE");
                    child.SerialNumber = table.GetString("SN");
                    child.SalesOrder = table.GetString("SALESORDER");
                    child.SOItem = table.GetInt("SO_ITEM");
                    child.Material = table.GetString("MATERIAL");
                    child.MaterialDescription = table.GetString("MATL_DESC");
                    child.InitialQuantity = table.GetDecimal("INITIAL_QUANTITY");
                    child.Quantity = table.GetDecimal("QUANTITY");
                    child.InitialDate = table.GetString("INITIAL_DELIV_DATE");
                    child.Date = table.GetString("DELIVERY_DATE");
                    child.Destination = table.GetString("DELIVERY_DEST");
                    child.DestinationID = table.GetString("DELIVERY_DEST_ID");
                    child.Vendor = table.GetString("VENDOR");
                    child.Releaser = table.GetString("RELEASER");
                    child.ReleaseDate = table.GetString("RELEASE_DATE");
                    child.ReleaseTime = table.GetString("RELEASE_TIME");
                    child.PurGroup = table.GetString("PUR_GROUP");
                    child.Status = table.GetInt("STATUS");
                    child.StatusDescription = ItemStatusDescription(child.Status);

                    nodes.Add(child);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public bool ItemStatus(IList<ScheduleLineInfo> nodes, int status,string comments)
        {
            IRfcFunction func = RFC.Function("ZPO_SCHE_REQ_LINE_STATUS");
            func.SetValue("COMMENTS", comments);
            func.SetValue("STATUS", status);
            IRfcTable importTable = func.GetTable("ITEMS");
            int index = 0;
            DateTime now = DateTime.Now;
            foreach (ScheduleLineInfo item in nodes)
            {
                importTable.Append(1);
                importTable.CurrentIndex = index++;
                importTable.SetValue("PURCHASEORDER", item.Number);
                importTable.SetValue("ITEM", item.Item);
                importTable.SetValue("LINE", item.Line);
                importTable.SetValue("SN", item.SerialNumber);
                importTable.SetValue("RELEASER", item.Releaser);
                importTable.SetValue("RELEASE_DATE", now.ToString("yyyyMMdd"));
                importTable.SetValue("RELEASE_TIME", now.ToString("HHmmss"));
            }

            bool success = false;
            try
            {
                RFC.Invoke(func, false);
                success = true;

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return success;
        }

        private string StatusDescription(string status)
        {
            string statusDescription = "";
            switch (status)
            {
                case "PPCtrl-Rejected": statusDescription = "驳回"; break;
                case "PP-Draft": statusDescription = "未提交"; break;
                case "PP-Release": statusDescription = "提交"; break;
                case "Pur-Rejected": statusDescription = "退回"; break;
                case "PPCtrl-Release": statusDescription = "批准"; break;
                case "Pur-Release": statusDescription = "确认"; break;
                case "PurCtrl-Sync": statusDescription = "同步"; break;
            }

            return statusDescription;
        }

        private string ItemStatusDescription(int status)
        {
            string statusDescription = "";
            switch (status)
            {
                case -1: statusDescription = "退回"; break;
                case 0: statusDescription = "待确认"; break;
                case 1: statusDescription = "待同步"; break;
                case 2: statusDescription = "已同步"; break;
                case 3: statusDescription = "被覆盖"; break;
            }

            return statusDescription;
        }

        public IList<ScheDelivDestInfo> DeliveryDestination()
        {
            IRfcFunction func = RFC.Function("ZPO_DELIV_DEST_READ");

            IList<ScheDelivDestInfo> nodes = new List<ScheDelivDestInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("DESTINATION");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ScheDelivDestInfo node = new ScheDelivDestInfo();
                    node.ID = table.GetInt("ID");
                    node.Destination = table.GetString("DESTINATION");
                    node.Status = table.GetInt("Status");
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
