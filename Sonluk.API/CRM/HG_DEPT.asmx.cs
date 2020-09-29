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
    /// HG_DEPT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HG_DEPT : System.Web.Services.WebService
    {
         RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
         [WebMethod]
        public int Create(CRM_HG_DEPT model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_DEPT.Create(model);
            }
            return -100;
            
        }
         [WebMethod]
         public int Update(CRM_HG_DEPT model, string ptoken)
         {
             if (models.CRM_Login.ValidateToken(ptoken))
             {
                 return models.HG_DEPT.Update(model);
             }
             return -100;
             
         }
          [WebMethod]
         public int Delete(int DEPID, string ptoken)
         {
             if (models.CRM_Login.ValidateToken(ptoken))
             {
                 return models.HG_DEPT.Delete(DEPID);
             }
             return -100;
             
         }
         [WebMethod]
          public List<CRM_HG_DEPT> Read(string ptoken)
          {
              List<CRM_HG_DEPT> node = new List<CRM_HG_DEPT>();
              if (models.CRM_Login.ValidateToken(ptoken))
              {
                  return models.HG_DEPT.Read().ToList();
              }
              return node;
              
          }
         [WebMethod]
         public CRM_HG_DEPTList ReadByDEPID(int DEPID, string ptoken)
         {
             CRM_HG_DEPTList node = new CRM_HG_DEPTList();
             if (models.CRM_Login.ValidateToken(ptoken))
             {
                 return models.HG_DEPT.ReadByDEPID(DEPID);
             }
             return node;
             
         }
        [WebMethod]
         public CRM_HG_DEPT ReadByName(string DEPNAME,string ptoken)
         {
             CRM_HG_DEPT node = new CRM_HG_DEPT();
             if (models.CRM_Login.ValidateToken(ptoken))
             {
                 return models.HG_DEPT.ReadByName(DEPNAME);
             }
             return node;
             
         }

        [WebMethod]
        public List<CRM_HG_DEPT> ReadByStaffid(int STAFFID, string ptoken)
        {
            List<CRM_HG_DEPT> node = new List<CRM_HG_DEPT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_DEPT.ReadByStaffid(STAFFID).ToList();
            }
            return node;

        }

    }
}
