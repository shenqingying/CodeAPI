using Sonluk.API.Models;
using Sonluk.Entities.PS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.PS
{
    /// <summary>
    /// NetWork 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/PS/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class NetWork : System.Web.Services.WebService
    {
        PSModels models = new PSModels();

        [WebMethod]
        public NetworkRead read(string aufnr, string ptoken)
        {
            return models.NetWork.read(aufnr);
        }

        [WebMethod]
        public string confirm(Ps_work ps_work, Ps_staff ps_staff, string ptoken)
        {
            return models.NetWork.confirm(ps_work, ps_staff);
        }

        [WebMethod]
        public List<PS_SXXGOA> readXMXX(string PSPID, string POSID, string PSPIDPO, string POSIDPO, string ptoken)
        {
            return models.NetWork.readXMXX(PSPID, POSID, PSPIDPO, POSIDPO).ToList();
        }

        [WebMethod]
        public List<PS_wlXX> readwlXX(string MATNR, string MAKTX, string ptoken)
        {
            return models.NetWork.readwlXX(MATNR, MAKTX).ToList();
        }

        [WebMethod]
        public List<ZSL_PSS_OUT_NAME> GYSMC(string I_EBELN, string ptoken)
        {
            return models.NetWork.PS_OA_GYSMC(I_EBELN).ToList();
        }

        [WebMethod]
        public string StaffINFO(string INITS, string ptoken)
        {
            return models.NetWork.StaffINFO(INITS);
        }

        [WebMethod]
        public PS_ZPSFUG_Q_LJSJ NetWork_READ_main(string AUFNR, string ptoken)
        {
            return models.NetWork.NetWork_READ_main(AUFNR);
        }
    }
}
