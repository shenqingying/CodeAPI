//-3: 驳回
//-2:生产驳回
//-1:未提交
//0:待审批
//1:待同步
//2:已同步
using Sonluk.DAFactory;
using Sonluk.Entities.MM;
using Sonluk.IDataAccess.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MM
{
    public class ScheduleRequisition
    {
        private static readonly IScheduleRequisition detaAccess = DataAccess.CreateScheduleRequisition();

        public string Create(ScheReqInfo node)
        {
            DateTime now = DateTime.Now;
            node.Date = now.ToString("yyyyMMdd");
            node.Time = now.ToString("HHmmss");
            return detaAccess.Create(node);
        }

        public string Create(IList<ScheReqInfo> nodes)
        {

            string serialNumbers = "";
            foreach (ScheReqInfo node in nodes)
            {
                serialNumbers = serialNumbers + " " + detaAccess.Create(node);
            }
            return serialNumbers;
        }

        public IList<ScheReqInfo> Read(ScheReqInfo keyword)
        {
            return detaAccess.Read(keyword);
        }

        public ScheReqInfo Read(string serialNumber)
        {
            return detaAccess.Read(serialNumber);
        }

        public bool Update(ScheReqInfo node)
        {
            return detaAccess.Update(node);
        }

        public bool Update(string serialNumber, string account, string status, string releaseCode, string comments)
        {
            ScheReqInfo node = Read(serialNumber);
            DateTime now = DateTime.Now;
            bool success = true;
            switch (status)
            {
                case "PPCtrl-Rejected":
                case "PPCtrl-Release":
                    {
                        node.NodePPCtrlDate = now.ToString("yyyyMMdd");
                        node.NodePPCtrlTime = now.ToString("HHmmss");
                        node.NodePPCtrl = account;
                        break;
                    }
                case "Pur-Rejected":
                case "Pur-Release":
                    {
                        node.NodePurDate = now.ToString("yyyyMMdd");
                        node.NodePurTime = now.ToString("HHmmss");
                        node.NodePur = account;
                        break;
                    }
                case "PurCtrl-Sync":
                    {
                        success = Sync(serialNumber, releaseCode);
                        node.NodePurCtrlDate = now.ToString("yyyyMMdd");
                        node.NodePurCtrlTime = now.ToString("HHmmss");
                        node.NodePurCtrl = account;
                        break;
                    }
            }
            node.NodeComments = comments;
            node.Status = status;
            node.Items = new List<ScheduleLineInfo>();
            if (success)
                success = detaAccess.Update(node);
            return success;
        }

        public bool Delete(string serialNumber)
        {
            return detaAccess.Delete(serialNumber);
        }

        public bool Sync(string serialNumber, string releaseCode)
        {

            ScheReqInfo posr = Read(serialNumber);
            bool success = false;

            IDictionary<string, List<ScheduleLineInfo>> poDictionary = new Dictionary<string, List<ScheduleLineInfo>>();
            foreach (ScheduleLineInfo item in posr.Items)
            {
                if (!poDictionary.ContainsKey(item.Number))
                {
                    poDictionary.Add(item.Number, new List<ScheduleLineInfo>());
                }
                poDictionary[item.Number].Add(item);
            }

            PurchaseOrder pobl = new PurchaseOrder();

            foreach (KeyValuePair<string, List<ScheduleLineInfo>> lines in poDictionary)
            {
                POInfo po = new POInfo();
                po.Header = new POHeaderInfo();
                po.Header.Number = lines.Key;
                po.Header.ReleaseCode = releaseCode;
                po.Items = new List<POItemInfo>();

                // Add by xsw
                POInfo poold = pobl.Read(po.Header.Number);

                //////////////////////////////////////////////

                IDictionary<int, int> indexDictionary = new Dictionary<int, int>();
                int index = 0;
                foreach (ScheduleLineInfo line in lines.Value)
                {
                    if (!indexDictionary.ContainsKey(line.Item))
                    {
                        indexDictionary.Add(line.Item, index++);
                        po.Items.Add(new POItemInfo());
                        po.Items[indexDictionary[line.Item]].Number = line.Item;

                        //Add by xsw
                        foreach (POItemInfo poitem in poold.Items)
                        { 
                            if(poitem.Number == line.Item)
                            {
                                po.Items[indexDictionary[line.Item]].Banfn = poitem.Banfn;
                                po.Items[indexDictionary[line.Item]].Bnfpo = poitem.Bnfpo;
                            }
                        }                 
                        ////////////////////////////////////////////

                        po.Items[indexDictionary[line.Item]].Schedule = new List<ScheduleLineInfo>();

                    }
                    po.Items[indexDictionary[line.Item]].Schedule.Add(line);
                }
                success = pobl.UpdateSchedule(po);

            }
            return success;
        }

        public IList<ScheduleLineInfo> ItemRead(ScheReqInfo keyword)
        {
            return detaAccess.ItemRead(keyword);
        }

        public bool ItemStatus(IList<ScheduleLineInfo> nodes, int status, string comments)
        {
            return detaAccess.ItemStatus(nodes, status,comments);
        }

        public IList<ScheDelivDestInfo> DeliveryDestination()
        {
            return detaAccess.DeliveryDestination();
        }

    }
}
