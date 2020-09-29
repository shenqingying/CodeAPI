using Sonluk.API.Models;
using Sonluk.Entities.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.MM
{
    /// <summary>
    /// ScheduleRequisition 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/MM")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class ScheduleRequisition : System.Web.Services.WebService
    {
        MMModels models = new MMModels();

        [WebMethod]
        public string Create(ScheReqInfo node)
        {
            return models.ScheduleRequisition.Create(node);
        }

        [WebMethod]
        public List<ScheReqInfo> Select(ScheReqInfo keyword)
        {
            return models.ScheduleRequisition.Read(keyword).ToList();
        }

        [WebMethod]
        public ScheReqInfo Read(string serialNumber)
        {
            return models.ScheduleRequisition.Read(serialNumber);
        }

        [WebMethod]
        public bool Update(ScheReqInfo node)
        {
            return models.ScheduleRequisition.Update(node);
        }

        [WebMethod]
        public bool UpdateStatus(string serialNumber, string account, string status, string releaseCode, string comments)
        {
            return models.ScheduleRequisition.Update(serialNumber, account, status, releaseCode, comments);
        }

        [WebMethod]
        public bool Delete(string serialNumber)
        {
            return models.ScheduleRequisition.Delete(serialNumber);
        }

        [WebMethod]
        public List<ScheduleLineInfo> ItemRead(ScheReqInfo keyword)
        {
            return models.ScheduleRequisition.ItemRead(keyword).ToList();
        }

        [WebMethod]
        public bool ItemStatus(List<ScheduleLineInfo> nodes, int status, string comments)
        {
            return models.ScheduleRequisition.ItemStatus(nodes, status, comments);
        }

        [WebMethod]
        public List<ScheDelivDestInfo> DeliveryDestination()
        {
            return models.ScheduleRequisition.DeliveryDestination().ToList();
        }

    }
}
