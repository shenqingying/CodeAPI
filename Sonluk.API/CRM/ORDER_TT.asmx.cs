using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// ORDER_TT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class ORDER_TT : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public int CreateTT(CRM_ORDER_TT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.CreateTT(model);
            }
            return -100;
        }
        [WebMethod]
        public int CreateMX(CRM_ORDER_MX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.CreateMX(model);
            }
            return -100;
        }
        [WebMethod]
        public int UpdateTT(CRM_ORDER_TT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.UpdateTT(model);
            }
            return -100;
        }
        [WebMethod]
        public int UpdateTT_KHinfo(CRM_ORDER_TT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.UpdateTT_KHinfo(model);
            }
            return -100;
        }
        [WebMethod]
        public int UpdateTT_BJ(CRM_ORDER_TT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.UpdateTT_BJ(model);
            }
            return -100;
        }
        [WebMethod]
        public int UpdateOrderIsactive(int ORDERTTID, int ISACTIVE, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.UpdateOrderIsactive(ORDERTTID, ISACTIVE);
            }
            return -100;
        }
        [WebMethod]
        public int UpdateOrder_SAPORDER(CRM_ORDER_TT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.UpdateOrder_SAPORDER(model);
            }
            return -100;
        }
        [WebMethod]
        public int UpdateOrder_LOCK(int ORDERTTID, int ISLOCK, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.UpdateOrder_LOCK(ORDERTTID, ISLOCK);
            }
            return -100;
        }
        [WebMethod]
        public int UpdateMX(CRM_ORDER_MX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.UpdateMX(model);
            }
            return -100;
        }
        [WebMethod]
        public int UpdateMX_WLinfo(CRM_ORDER_MX model, int STAFFID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.UpdateMX_WLinfo(model, STAFFID);
            }
            return -100;
        }
        [WebMethod]
        public int DeleteTT(int ORDERTTID, string which, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.DeleteTT(ORDERTTID, which);
            }
            return -100;
        }
        [WebMethod]
        public int AddPrintCount(int ORDERTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.AddPrintCount(ORDERTTID);
            }
            return -100;
        }
        [WebMethod]
        public int DeleteMX(int ORDERMXID, int XGR, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.DeleteMX(ORDERMXID, XGR);
            }
            return -100;
        }
        [WebMethod]
        public int DeleteMXbyFItem(CRM_ORDER_MX model, int STAFFID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.DeleteMXbyFItem(model, STAFFID);
            }
            return -100;
        }
        [WebMethod]
        public CRM_ORDER_TT ReadTTbyID(int ORDERTTID, string ptoken)
        {
            CRM_ORDER_TT node = new CRM_ORDER_TT();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.ReadTTbyID(ORDERTTID);
            }
            return node;

        }
        [WebMethod]
        public List<CRM_ORDER_TT> ReadTTbyParam(CRM_ORDER_TT model, int STAFFID, int forCopy, int isGun, string ptoken)
        {
            List<CRM_ORDER_TT> node = new List<CRM_ORDER_TT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.ReadTTbyParam(model, STAFFID, forCopy, isGun).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_ORDER_MX> ReadMXbyTTID(int ORDERTTID, string ptoken)
        {
            List<CRM_ORDER_MX> node = new List<CRM_ORDER_MX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.ReadMXbyTTID(ORDERTTID).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_ORDER_MX> ReadMXbyParam(CRM_ORDER_MX model, string ptoken)
        {
            List<CRM_ORDER_MX> node = new List<CRM_ORDER_MX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.ReadMXbyParam(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public CRM_ORDER_MX ReadMXbyMXID(int ORDERMXID, string ptoken)
        {
            CRM_ORDER_MX node = new CRM_ORDER_MX();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.ReadMXbyMXID(ORDERMXID);
            }
            return node;
        }
        [WebMethod]
        public MES_RETURN INSERT_DRF_SYNC(CRM_ORDER_DRF_SYNC model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_TT.INSERT_DRF_SYNC(model);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }

    }
}
