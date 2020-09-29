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
    /// HG_DICT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HG_DICT : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public int Create(CRM_HG_DICT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_DICT.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_HG_DICT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_DICT.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(int DICID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_DICT.Delete(DICID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_HG_DICT> Read(int TYPEID, int FID, string ptoken)
        {
            List<CRM_HG_DICT> node = new List<CRM_HG_DICT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_DICT.Read(TYPEID, FID).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_HG_DICT> ReadByParam(CRM_HG_DICT model, int STAFFID, string ptoken)
        {
            List<CRM_HG_DICT> node = new List<CRM_HG_DICT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_DICT.ReadByParam(model, STAFFID).ToList();
            }
            return node;
        }
        [WebMethod]
        public int ReadByDICNAME(string DICNAME, int typeID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_DICT.ReadByDICNAME(DICNAME, typeID);
            }
            return -100;

        }
        [WebMethod]
        public int ReadByDICNAMEandFID(string DICNAME, int typeID, int FID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_DICT.ReadByDICNAMEandFID(DICNAME, typeID, FID);
            }
            return -100;

        }
        [WebMethod]
        public CRM_HG_DICT ReadByDICID(int DICID, string ptoken)
        {
            CRM_HG_DICT node = new CRM_HG_DICT();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_DICT.ReadByDICID(DICID);
            }
            return node;

        }



    }
}
