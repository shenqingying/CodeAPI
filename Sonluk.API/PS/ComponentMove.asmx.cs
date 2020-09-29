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
    /// ComponentMove 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/PS/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class ComponentMove : System.Web.Services.WebService
    {
        PSModels models = new PSModels();
        [WebMethod]
        public string Component_ljds(ZSL_PSS_INC_CGDS i_in, string ptoken)
        {
            return models.ComponentMove.Component_ljds(i_in);
        }

        [WebMethod]
        public PS_ZPSFUG_Q_CGDS Component_DSXX(string I_NPLNR, string ptoken)
        {
            return models.ComponentMove.Component_DSXX(I_NPLNR);
        }
        [WebMethod]
        public List<ComponentCM> ComponentCM_GET(string IV_VERIF, string ptoken)
        {
            return models.ComponentMove.ComponentCM_GET(IV_VERIF).ToList();
        }
        [WebMethod]
        public string ComponentPutAway(PS_componentputaway ps_componentputaway, string ptoken)
        {
            return models.ComponentMove.ComponentPutAway(ps_componentputaway);
        }
        [WebMethod]
        public PS_ZPSFUG_Q_CMCC ComponentInventory_CM(string I_VERIF, string ptoken)
        {
            return models.ComponentMove.ComponentInventory_CM(I_VERIF);
        }
        [WebMethod]
        public PS_ZPSFUG_Q_WLCC ComponentInventory_Network(string I_AUFNR, string ptoken)
        {
            return models.ComponentMove.ComponentInventory_Network(I_AUFNR);
        }

        [WebMethod]
        public List<ZSL_PSS_OUT_WLCC> Network_OA(string I_AUFNR, string ptoken)
        {
            ZSL_PSS_OUT_WLCC child = new ZSL_PSS_OUT_WLCC();
            child = models.ComponentMove.ComponentInventory_Network(I_AUFNR).T_OUT;
            List<ZSL_PSS_OUT_WLCC> ps = new List<ZSL_PSS_OUT_WLCC>();
            ps.Add(child);
            return ps;
        }
        [WebMethod]
        public PS_ZPSFUG_Q_LJXJ ComponentSoldout_read(string I_SENUM, string I_ZROWSNUM, string ptoken)
        {
            return models.ComponentMove.ComponentSoldout_read(I_SENUM, I_ZROWSNUM);
        }
        [WebMethod]
        public PS_MSG ComponentSoldout(ZSL_PSS_INC_LJXJ ps_i, string ptoken)
        {
            return models.ComponentMove.ComponentSoldout(ps_i);
        }
        [WebMethod]
        public PS_MSG ComponentMoving_all(ZSL_PSS_INC_LJYC i_in, string ptoken)
        {
            return models.ComponentMove.ComponentMoving_all(i_in);
        }
    }
}
