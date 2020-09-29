using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// MSG_INVOICE 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MSG_INVOICE : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_MSG_INVOICE model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_INVOICE.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_MSG_INVOICE model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_INVOICE.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_MSG_INVOICEList> ReadByParam(CRM_MSG_INVOICEParam model, string ptoken)
        {
            List<CRM_MSG_INVOICEList> node = new List<CRM_MSG_INVOICEList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_INVOICE.ReadByParam(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public int Delete(int INVOICEID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_INVOICE.Delete(INVOICEID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_MSG_INVOICEList> ReadByKHID(int KHID, string ptoken)
        {
            List<CRM_MSG_INVOICEList> node = new List<CRM_MSG_INVOICEList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_INVOICE.ReadByKHID(KHID).ToList();
            }
            return node;
        }
        [WebMethod]
        public int AddCount(int INVOICEID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_INVOICE.AddCount(INVOICEID);
            }
            return -100;
        }


    }
}
