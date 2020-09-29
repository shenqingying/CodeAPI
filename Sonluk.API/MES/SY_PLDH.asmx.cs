using Sonluk.API.Models;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.MES
{
    /// <summary>
    /// SY_PLDH 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SY_PLDH : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public MES_SY_PLDH_SELECT SELECT_LIST(MES_SY_PLDH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_PLDH.SELECT_LIST(model);
            }
            else
            {
                MES_SY_PLDH_SELECT rst = new MES_SY_PLDH_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_SY_PLDH_SELECT SELECT(MES_SY_PLDH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_PLDH.SELECT(model);
            }
            else
            {
                MES_SY_PLDH_SELECT rst = new MES_SY_PLDH_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN PLDH_SBBH_INSERT(MES_SY_PLDH_SBBH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_PLDH.PLDH_SBBH_INSERT(model);
            }
            else
            {
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return child_MES_RETURN;
            }
        }
        [WebMethod]
        public MES_RETURN PLDH_SBBH_UPDATE(MES_SY_PLDH_SBBH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_PLDH.PLDH_SBBH_UPDATE(model);
            }
            else
            {
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return child_MES_RETURN;
            }
        }
        [WebMethod]
        public MES_SY_PLDH_SBBH_SELECT PLDH_SBBH_SELECT(MES_SY_PLDH_SBBH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_PLDH.PLDH_SBBH_SELECT(model);
            }
            else
            {
                MES_SY_PLDH_SBBH_SELECT rst = new MES_SY_PLDH_SBBH_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN INSERT_PLDH_PH(MES_SY_PLDH_PH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_PLDH_PH.INSERT(model);
            }
            else
            {
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return child_MES_RETURN;
            }
        }
        [WebMethod]
        public MES_SY_PLDH_PH_SELECT SELECT_PLDH_PH(MES_SY_PLDH_PH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_PLDH_PH.SELECT(model);
            }
            else
            {
                MES_SY_PLDH_PH_SELECT rst = new MES_SY_PLDH_PH_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_SY_PLDH_PH_SELECT SELECT_PLDH_PH_LB(MES_SY_PLDH_PH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_PLDH_PH.SELECT_LB(model);
            }
            else
            {
                MES_SY_PLDH_PH_SELECT rst = new MES_SY_PLDH_PH_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN INSERT(MES_SY_PLDH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_PLDH.INSERT(model);
            }
            else
            {
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return child_MES_RETURN;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE(MES_SY_PLDH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_PLDH.UPDATE(model);
            }
            else
            {
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return child_MES_RETURN;
            }
        }
    }
}
