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
    /// HD_ZDF 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HD_ZDF : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_HD_ZDF model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_ZDF.Create(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Update(CRM_HD_ZDF model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_ZDF.Update(model);
            }
            return -100;
           
        }
        [WebMethod]
        public int Delete(int ZDFID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_ZDF.Delete(ZDFID);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_HD_ZDFList> Read(CRM_HD_ZDF_PARAMS model,string ptoken)
        {
            List<CRM_HD_ZDFList> node = new List<CRM_HD_ZDFList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_ZDF.Read(model).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public CRM_HD_ZDF ReadByZDFID(int ZDFID, string ptoken)
        {
            CRM_HD_ZDF node = new CRM_HD_ZDF();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_ZDF.ReadByZDFID(ZDFID);
            }
            return node;

        }
        [WebMethod]
        public List<CRM_HD_ZDFList> ReadBySTAFFID(CRM_HD_ZDF_PARAMS model, string ptoken)
        {
            List<CRM_HD_ZDFList> node = new List<CRM_HD_ZDFList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_ZDF.ReadBySTAFFID(model).ToList();
            }
            return node;

        }
    }
}
