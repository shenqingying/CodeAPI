using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Sonluk.API.Models;
using Sonluk.Entities.LE;
using Sonluk.Entities.Common;
using System.IO;

namespace Sonluk.API.LE
{
    /// <summary>
    /// OutboundDelivery 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/LE/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class OutboundDelivery : System.Web.Services.WebService
    {

        LEModels models = new LEModels();


        [WebMethod]
        public List<DeliveryInfo> Read(DeliveryInfo keyowrds)
        {
            return models.OutboundDelivery.Read(keyowrds).ToList();
        }

        [WebMethod]
        public List<DeliveryItemInfo> ItemRead(string serialNumber)
        {
            return models.OutboundDelivery.ItemRead(serialNumber).ToList();
        }

        [WebMethod]
        public byte[] Export(List<DeliveryInfo> nodes)
        {
            return models.OutboundDelivery.Export(nodes).ToArray();
        }

        [WebMethod]
        public int UnLoad(int minSales, string deliveryNumberSet, string salesRange)
        {
            return models.OutboundDelivery.UnLoad(minSales, deliveryNumberSet, salesRange);
        }

    }
}
