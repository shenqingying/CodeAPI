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
    /// BC_FXCH 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BC_FXCH : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public int TTCreate(CRM_BC_FXCHTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_FXCH.TTCreate(model);
            }
            return -100;
        }

        [WebMethod]
        public int MXCreate(CRM_BC_FXCHMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_FXCH.MXCreate(model);
            }
            return -100;
        }

        [WebMethod]
        public int TTDelete(int FXCHTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_FXCH.TTDelete(FXCHTTID);
            }
            return -100;
        }

        [WebMethod]
        public int MXDelete(int FXCHMXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_FXCH.MXDelete(FXCHMXID);
            }
            return -100;
        }

        [WebMethod]
        public int MXDeleteByDXM(string DXM, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_FXCH.MXDeleteByDXM(DXM);
            }
            return -100;
        }

        [WebMethod]
        public List<CRM_BC_FXCHTTList> ReadTTbyParam(CRM_BC_FXCHParam model, string ptoken)
        {

            List<CRM_BC_FXCHTTList> node = new List<CRM_BC_FXCHTTList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_FXCH.ReadTTbyParam(model).ToList();
            }
            return node;
        }

        [WebMethod]
        public CRM_BC_FXCHTTList ReadTTbyTTID(int FXCHTTID, string ptoken)
        {
            CRM_BC_FXCHTTList node = new CRM_BC_FXCHTTList();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_FXCH.ReadTTbyTTID(FXCHTTID);
            }
            return node;
        }

        [WebMethod]
        public List<CRM_BC_FXCHTTList> Report(CRM_BC_FXCHParam model, string ptoken)
        {
            List<CRM_BC_FXCHTTList> node = new List<CRM_BC_FXCHTTList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_FXCH.Report(model).ToList();
            }
            return node;
        }

        [WebMethod]
        public List<CRM_BC_FXCHMX> ReadMXbyTTID(int FXCHTTID, string ptoken)
        {

            List<CRM_BC_FXCHMX> node = new List<CRM_BC_FXCHMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_FXCH.ReadMXbyTTID(FXCHTTID).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_BC_FXCHMX> ReadMXbyParam(CRM_BC_FXCHMX model, string ptoken)
        {

            List<CRM_BC_FXCHMX> node = new List<CRM_BC_FXCHMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_FXCH.ReadMXbyParam(model).ToList();
            }
            return node;
        }
        

        [WebMethod]
        public int ReadCountByDXM(string DXM, string TPM, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_FXCH.ReadCountByDXM(DXM, TPM);
            }
            return -100;
        }

        [WebMethod]
        public int Verify_IfHaveKHRight(int STAFFID, string CRMID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_FXCH.Verify_IfHaveKHRight(STAFFID, CRMID);
            }
            return -100;
        }

        [WebMethod]
        public int Verify_IfHaveCHRight(int STAFFID, string DXM, string TPM, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_FXCH.Verify_IfHaveCHRight(STAFFID, DXM, TPM);
            }
            return -100;
        }






    }
}
