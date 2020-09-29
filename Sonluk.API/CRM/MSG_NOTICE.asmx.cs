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
    /// MSG_NOTICE 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MSG_NOTICE : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int CreateTT(CRM_MSG_NOTICETT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_NOTICE.CreateTT(model);
            }
            return -100;

        }
        [WebMethod]
        public int CreateMX(CRM_MSG_NOTICEMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_NOTICE.CreateMX(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_MSG_NOTICETTList> ReadTT(CRM_MSG_NOTICETTParam model, string ptoken)
        {
            List<CRM_MSG_NOTICETTList> node = new List<CRM_MSG_NOTICETTList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_NOTICE.ReadTT(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public CRM_MSG_NOTICETTList ReadTTbyTTID(int NOTICETTID, string ptoken)
        {
            CRM_MSG_NOTICETTList node = new CRM_MSG_NOTICETTList();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_NOTICE.ReadTTbyTTID(NOTICETTID);
            }
            return node;
        }
        [WebMethod]
        public List<CRM_MSG_NOTICEMXList_KH> ReadMXbyTTID_KH(int NOTICETTID, string ptoken)
        {
            List<CRM_MSG_NOTICEMXList_KH> node = new List<CRM_MSG_NOTICEMXList_KH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_NOTICE.ReadMXbyTTID_KH(NOTICETTID).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_MSG_NOTICEMXList_STAFF> ReadMXbyTTID_STAFF(int NOTICETTID, string ptoken)
        {
            List<CRM_MSG_NOTICEMXList_STAFF> node = new List<CRM_MSG_NOTICEMXList_STAFF>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_NOTICE.ReadMXbyTTID_STAFF(NOTICETTID).ToList();
            }
            return node;
        }
        [WebMethod]
        public int UpdateTT(CRM_MSG_NOTICETT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_NOTICE.UpdateTT(model);
            }
            return -100;

        }
        [WebMethod]
        public int UpdateIsactive(int NOTICETTID, int ISACTIVE, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_NOTICE.UpdateIsactive(NOTICETTID, ISACTIVE);
            }
            return -100;
        }
        [WebMethod]
        public int UpdateMX(CRM_MSG_NOTICEMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_NOTICE.UpdateMX(model);
            }
            return -100;

        }
        [WebMethod]
        public int DeleteTT(int NOTICETTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_NOTICE.DeleteTT(NOTICETTID);
            }
            return -100;

        }
        [WebMethod]
        public int DeleteMX(int NOTICEMXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_NOTICE.DeleteMX(NOTICEMXID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_MSG_NOTICETTList> ReadBySTAFFID(int STAFFID, int USERLX, string ptoken)
        {
            List<CRM_MSG_NOTICETTList> node = new List<CRM_MSG_NOTICETTList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_NOTICE.ReadBySTAFFID(STAFFID, USERLX).ToList();
            }
            return node;
        }
        [WebMethod]
        public int AddCount(int NOTICETTID, int USERID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_NOTICE.AddCount(NOTICETTID, USERID);
            }
            return -100;
        }
        [WebMethod]
        public List<CRM_MSG_NOTICEMX> ReadMXbyParam(CRM_MSG_NOTICEMX model, string ptoken)
        {
            List<CRM_MSG_NOTICEMX> node = new List<CRM_MSG_NOTICEMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.MSG_NOTICE.ReadMXbyParam(model).ToList();
            }
            return node;
        }






    }
}
