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
    /// KQ_GZRL 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KQ_GZRL : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_KQ_GZRL model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_GZRL.Create(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Update(CRM_KQ_GZRL model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_GZRL.Update(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Delete(int BBID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_GZRL.Delete(BBID);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_KQ_GZRL> Read(string MS,int BBID,string ptoken)
        {
            List<CRM_KQ_GZRL> node = new List<CRM_KQ_GZRL>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_GZRL.Read(MS,BBID).ToList();
            }
            return node;
            
        }
        //[WebMethod]
        //public CRM_KQ_GZRL ReadByMS(string MS,string ptoken)
        //{
        //    CRM_KQ_GZRL node = new CRM_KQ_GZRL();
           
        //    if (models.CRM_Login.ValidateToken(ptoken))
        //    {
        //        return models.KQ_GZRL.ReadByMS(MS);
        //    }
        //    return node;
        //}
        //[WebMethod]
        //public CRM_KQ_GZRL ReadByBBID(int BBID,string ptoken)
        //{
        //    CRM_KQ_GZRL node = new CRM_KQ_GZRL();

        //    if (models.CRM_Login.ValidateToken(ptoken))
        //    {
        //        return models.KQ_GZRL.ReadByBBID(BBID);
        //    }
        //    return node;
            
        //}
    }
}
