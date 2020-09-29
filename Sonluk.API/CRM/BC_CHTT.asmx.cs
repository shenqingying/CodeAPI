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
    /// BC_CHTT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BC_CHTT : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Modify(string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_CHTT.Modify();
            }
            return -100;
        }
        [WebMethod]
        public int SelectMXIDbyDXM(string DXM, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_CHTT.SelectMXIDbyDXM(DXM);
            }
            return -100;
        }
        [WebMethod]
        public string SelectKUNAGbyTTID(int PMCHTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_CHTT.SelectKUNAGbyTTID(PMCHTTID);
            }
            return "-100";
        }
        [WebMethod]
        public CRM_WebMSG TongBuSAP_CH()
        {

            return models.BC_CHTT.TongBuSAP_CH();

        }
        [WebMethod]
        public List<CRM_BC_CHMX> SelectCHMXbyDXM(string DXM, string TPM, string ptoken)
        {
            List<CRM_BC_CHMX> node = new List<CRM_BC_CHMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_CHTT.SelectCHMXbyDXM(DXM,TPM).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_BC_CHMX> ReadMXbyParam(CRM_BC_CHMX model, string ptoken)
        {
            List<CRM_BC_CHMX> node = new List<CRM_BC_CHMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_CHTT.ReadMXbyParam(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_BC_CHMX> ReadDXMbyTPM(string TPM, string ptoken)
        {
            List<CRM_BC_CHMX> node = new List<CRM_BC_CHMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_CHTT.ReadDXMbyTPM(TPM).ToList();
            }
            return node;
        }

    }
}
