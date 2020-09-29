using Sonluk.BusinessLogic.CRM;
using Sonluk.Entities.CRM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class MES_Login
    {
        CRM_Login CRM_LoginService = new CRM_Login();
        SY_GC SY_GCService = new SY_GC();
        public MES_LoginINFO Login(string name, string password, string OPENID, string WXDLCS, int PC, int WX, int GCID)
        {
            CRM_LoginInfo model_CRM_LoginInfo = CRM_LoginService.Login(name, password, OPENID, WXDLCS, PC, WX);
            MES_LoginINFO rst = new MES_LoginINFO();
            if (model_CRM_LoginInfo.TokenInfo.access_token != null)
            {

                //MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
                //model_MES_SY_GC.ID = GCID;
                //model_MES_SY_GC.STAFFID = model_CRM_LoginInfo.TokenInfo.STAFFID;
                //List<MES_SY_GC> model_count = SY_GCService.SELECT_BY_ROLE(model_MES_SY_GC).ToList();
                //if (model_count.Count > 0)
                //{
                //    rst.TokenInfo = model_CRM_LoginInfo.TokenInfo;
                //    rst.JURISDICTION_GROUP = model_CRM_LoginInfo.JURISDICTION_GROUP;
                //    MES_RETURN mr = new MES_RETURN();
                //    mr.TYPE = "S";
                //    mr.MESSAGE = "";
                //    rst.MES_RETURN = mr;
                //}
                //else
                //{
                //    MES_RETURN mr = new MES_RETURN();
                //    mr.TYPE = "E";
                //    mr.MESSAGE = "没有该工厂权限";
                //    rst.MES_RETURN = mr;
                //}
                rst.TokenInfo = model_CRM_LoginInfo.TokenInfo;
                rst.JURISDICTION_GROUP = model_CRM_LoginInfo.JURISDICTION_GROUP;
                MES_RETURN mr = new MES_RETURN();
                mr.TYPE = "S";
                mr.MESSAGE = "";
                rst.MES_RETURN = mr;
            }
            else
            {
                MES_RETURN mr = new MES_RETURN();
                mr.TYPE = "E";
                mr.MESSAGE = model_CRM_LoginInfo.TokenInfo.MESSAGE;
                rst.MES_RETURN = mr;
            }
            return rst;
        }
        public MES_LoginINFO Login_language(string name, string password, string OPENID, string WXDLCS, int PC, int WX, int GCID, int language)
        {
            CRM_LoginInfo model_CRM_LoginInfo = CRM_LoginService.Login_language(name, password, OPENID, WXDLCS, PC, WX, language);
            MES_LoginINFO rst = new MES_LoginINFO();
            if (model_CRM_LoginInfo.TokenInfo.access_token != null)
            {

                //MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
                //model_MES_SY_GC.ID = GCID;
                //model_MES_SY_GC.STAFFID = model_CRM_LoginInfo.TokenInfo.STAFFID;
                //List<MES_SY_GC> model_count = SY_GCService.SELECT_BY_ROLE(model_MES_SY_GC).ToList();
                //if (model_count.Count > 0)
                //{
                //    rst.TokenInfo = model_CRM_LoginInfo.TokenInfo;
                //    rst.JURISDICTION_GROUP = model_CRM_LoginInfo.JURISDICTION_GROUP;
                //    MES_RETURN mr = new MES_RETURN();
                //    mr.TYPE = "S";
                //    mr.MESSAGE = "";
                //    rst.MES_RETURN = mr;
                //}
                //else
                //{
                //    MES_RETURN mr = new MES_RETURN();
                //    mr.TYPE = "E";
                //    mr.MESSAGE = "没有该工厂权限";
                //    rst.MES_RETURN = mr;
                //}
                rst.TokenInfo = model_CRM_LoginInfo.TokenInfo;
                rst.JURISDICTION_GROUP = model_CRM_LoginInfo.JURISDICTION_GROUP;
                MES_RETURN mr = new MES_RETURN();
                mr.TYPE = "S";
                mr.MESSAGE = "";
                rst.MES_RETURN = mr;
            }
            else
            {
                MES_RETURN mr = new MES_RETURN();
                mr.TYPE = "E";
                mr.MESSAGE = model_CRM_LoginInfo.TokenInfo.MESSAGE;
                rst.MES_RETURN = mr;
            }
            return rst;
        }
    }
}
