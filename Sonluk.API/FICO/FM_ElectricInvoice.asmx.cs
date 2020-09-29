using Sonluk.API.Models;
using Sonluk.Entities.FICO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.FICO
{
    /// <summary>
    /// FM_ElectricInvoice 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class FM_ElectricInvoice : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(FICO_FM_ElectricInvoice model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.FM_ElectricInvoice.Create(model);
            }
            return -100;

        }

        [WebMethod]
        public int Update(FICO_FM_ElectricInvoice model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.FM_ElectricInvoice.Update(model);
            }
            return -100;

        }

        [WebMethod]
        public List<FICO_FM_ElectricInvoice> ReadByParam(FICO_FM_ElectricInvoice model,  string ptoken)
        {
            List<FICO_FM_ElectricInvoice> node = new List<FICO_FM_ElectricInvoice>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.FM_ElectricInvoice.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int ReadBySCAN(FICO_FM_ElectricInvoice model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.FM_ElectricInvoice.ReadBySCAN(model);
            }
            return -100;

        }

        [WebMethod]
        public int Delete(int ID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.FM_ElectricInvoice.Delete(ID);
            }
            return -100;

        }
    }
}
