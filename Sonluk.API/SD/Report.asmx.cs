using Sonluk.API.Models;
using Sonluk.Entities.SD;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.SD
{
    /// <summary>
    /// Report 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/SD/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Report : System.Web.Services.WebService
    {
        SDModels models = new SDModels();

        [WebMethod]
        public List<ReportInfo> AC(string dateStart, string dateEnd, string customer)
        {
            return models.Report.AC(dateStart, dateEnd, customer).ToList();
        }

        [WebMethod]
        public List<ReportInfo> SO(string customerPOStart, string customerPOEnd, string dateStart, string dateEnd, string materialStart, string materialEnd)
        {
            return models.Report.SO(customerPOStart, customerPOEnd, dateStart, dateEnd, materialStart, materialEnd).ToList();
        }

        [WebMethod]
        public List<ReportInfo> SH(string customerPOStart, string customerPOEnd, string dateStart, string dateEnd, string materialStart, string materialEnd)
        {
            return models.Report.SH(customerPOStart, customerPOEnd, dateStart, dateEnd, materialStart, materialEnd).ToList();
        }

        [WebMethod]
        public List<ReportInfo> SHFH(string customer, string dateStart, string dateEnd)
        {
            return models.Report.SHFH(customer, dateStart, dateEnd).ToList();
        }

        [WebMethod]
        public List<ReportInfo> ZKMX(string customer, string dateStart, string dateEnd)
        {
            return models.Report.ZKMX(customer, dateStart, dateEnd).ToList();
        }
    }
}
