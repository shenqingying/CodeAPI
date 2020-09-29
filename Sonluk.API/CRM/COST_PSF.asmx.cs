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
    /// COST_PSF 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_PSF : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_COST_PSF model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_PSF.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_PSF model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_PSF.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_PSF> ReadByParam(CRM_COST_PSF model, int STAFFID, string ptoken)
        {
            List<CRM_COST_PSF> node = new List<CRM_COST_PSF>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_PSF.ReadByParam(model, STAFFID).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_PSF> ReportWLGS(CRM_COST_PSF model, string ptoken)
        {
            List<CRM_COST_PSF> node = new List<CRM_COST_PSF>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_PSF.ReportWLGS(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_COST_PSF> ReportJXS(CRM_COST_PSF model, string ptoken)
        {
            List<CRM_COST_PSF> node = new List<CRM_COST_PSF>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_PSF.ReportJXS(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_COST_PSF> Read_Unconnected(CRM_COST_PSF model, string ptoken)
        {
            List<CRM_COST_PSF> node = new List<CRM_COST_PSF>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_PSF.Read_Unconnected(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public int Delete(int PSFID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_PSF.Delete(PSFID);
            }
            return -100;

        }
        [WebMethod]
        public int AddPrintCount(int PSFID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_PSF.AddPrintCount(PSFID);
            }
            return -100;
        }



    }
}
