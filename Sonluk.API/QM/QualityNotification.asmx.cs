using Sonluk.API.Models;
using Sonluk.Entities.QM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.QM
{
    /// <summary>
    /// QualityNotification 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/QM/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class QualityNotification : System.Web.Services.WebService
    {
        QMModels models = new QMModels();

        [WebMethod]
        public int Read(string type)
        {
            return (models.QualityNotification.Read(type)).Count;
        }

        [WebMethod]
        public string ReadZ2()
        {
            string sn ="";
            foreach(QNInfo node in models.QualityNotification.ReadZ2())
            {
                sn = sn + node.SerialNumber+";";
            
            }

            return sn;
        }
    }
}
