using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.DAFactory;
using Sonluk.Entities.SD;
using Sonluk.IDataAccess.SD;
using Sonluk.Entities.MM;

namespace Sonluk.BusinessLogic.SD
{
    public class SalesOrder
    {
        private static readonly ISalesOrder detaAccess = SDDataAccess.CreateSalesOrder();

        public string Create(SOInfo node)
        {
            return detaAccess.Create(node);
        }

        public IList<SOItemInfo> Read(SOKeywordInfo keyword)
        {
            return detaAccess.Read(keyword);
        }

        public string ProcessingRecords(SOItemInfo node)
        {
            if (node.ProcessingRecordsStatus.Equals("0"))
            {
                node.ProcessingRecordsStatus = "2";
                node.ProcessingRecordsDelete = "1";

            }
            else
            {
                node.ProcessingRecordsDelete = "0";
            }
            return detaAccess.ProcessingRecords(node);
        }

        public string ProcessingRecords(List<SOItemInfo> nodes)
        {
            string message = "";
            int i = 1;
            foreach (SOItemInfo node in nodes)
            {
                message = message + i + ":" + ProcessingRecords(node) + "\n";
                i++;
            }
            return message;
        }

        public IList<CustomTextInfo> CustomText(string serialNumber, string matlGroup)
        {
            return CustomText(serialNumber, 0, matlGroup);
        }

        public IList<CustomTextInfo> CustomText(string serialNumber, int item, string matlGroup)
        {
            return detaAccess.CustomText(serialNumber, item, matlGroup);
        }


    }
}
