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
    /// MES_SYNC 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MES_SYNC : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public MES_RETURN MES_SYNC_GZZX(string GC, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.MES_SYNC.MES_SYNC_GZZX(GC);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public bool MES_PFDH_SYNC(string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.MES_SYNC.MES_PFDH_SYNC();
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public MES_RETURN MES_WLGROUP_SYNC(string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.MES_SYNC.MES_WLGROUP_SYNC();
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN MES_SYNC_WL(string GC, string WLGROUP, string WLH, int JLR, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.MES_SYNC.MES_SYNC_WL(GC, WLGROUP, WLH, JLR);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN MES_SYNC_KCDD(string GC, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.MES_SYNC.MES_SYNC_KCDD(GC);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN MES_SYNC_ALL()
        {
            return mesmodel.MES_SYNC.MES_SYNC_ALL();
        }
        [WebMethod]
        public MES_RETURN MES_PFDH_XFPC_SYNC()
        {
            MES_RETURN mr = mesmodel.MES_SYNC.MES_PFDH_XFPC_SYNC();
            MES_SY_CCGCRETRUN model_MES_SY_CCGCRETRUN = new MES_SY_CCGCRETRUN();
            model_MES_SY_CCGCRETRUN.LB = 2;
            model_MES_SY_CCGCRETRUN.CCGC = "MES_PFDH_XFPC_SYNC";
            model_MES_SY_CCGCRETRUN.TYPE = mr.TYPE;
            model_MES_SY_CCGCRETRUN.MESSAGE = mr.MESSAGE;
            mesmodel.SY_EXCEPTION.INSERT_CCGC(model_MES_SY_CCGCRETRUN);
            return mr;
        }
        [WebMethod]
        public MES_RETURN MES_SY_TPM_SYNC_AUTO()
        {
            MES_RETURN mr = mesmodel.MES_SYNC.MES_SY_TPM_SYNC_AUTO("", "");
            MES_SY_CCGCRETRUN model_MES_SY_CCGCRETRUN = new MES_SY_CCGCRETRUN();
            model_MES_SY_CCGCRETRUN.LB = 2;
            model_MES_SY_CCGCRETRUN.CCGC = "MES_SY_TPM_SYNC_AUTO";
            model_MES_SY_CCGCRETRUN.TYPE = mr.TYPE;
            model_MES_SY_CCGCRETRUN.MESSAGE = mr.MESSAGE;
            if (model_MES_SY_CCGCRETRUN.TYPE == "S")
            {
                model_MES_SY_CCGCRETRUN.MESSAGE = "IV_DATEST: /IV_DATEED: ";
            }
            mesmodel.SY_EXCEPTION.INSERT_CCGC(model_MES_SY_CCGCRETRUN);
            return mr;
        }
        [WebMethod]
        public MES_RETURN MES_SY_TPM_SYNC_AUTO_TIME(string IV_DATEST, string IV_DATEED)
        {
            MES_RETURN mr = mesmodel.MES_SYNC.MES_SY_TPM_SYNC_AUTO(IV_DATEST, IV_DATEED);
            MES_SY_CCGCRETRUN model_MES_SY_CCGCRETRUN = new MES_SY_CCGCRETRUN();
            model_MES_SY_CCGCRETRUN.LB = 2;
            model_MES_SY_CCGCRETRUN.CCGC = "MES_SY_TPM_SYNC_AUTO";
            model_MES_SY_CCGCRETRUN.TYPE = mr.TYPE;
            model_MES_SY_CCGCRETRUN.MESSAGE = mr.MESSAGE;
            if (model_MES_SY_CCGCRETRUN.TYPE == "S")
            {
                model_MES_SY_CCGCRETRUN.MESSAGE = "IV_DATEST:" + IV_DATEST + "/IV_DATEED:" + IV_DATEED;
            }
            mesmodel.SY_EXCEPTION.INSERT_CCGC(model_MES_SY_CCGCRETRUN);
            return mr;
        }
        [WebMethod]
        public MES_RETURN MES_PD_GD_SYNC_AUTO()
        {
            MES_RETURN mr = mesmodel.MES_SYNC.MES_PD_GD_SYNC_AUTO("", "");
            MES_SY_CCGCRETRUN model_MES_SY_CCGCRETRUN = new MES_SY_CCGCRETRUN();
            model_MES_SY_CCGCRETRUN.LB = 4;
            model_MES_SY_CCGCRETRUN.CCGC = "MES_PD_GD_SYNC_AUTO";
            model_MES_SY_CCGCRETRUN.TYPE = mr.TYPE;
            model_MES_SY_CCGCRETRUN.MESSAGE = mr.MESSAGE;
            if (model_MES_SY_CCGCRETRUN.TYPE == "S")
            {
                model_MES_SY_CCGCRETRUN.MESSAGE = "LOW: /HIGH: ";
            }
            mesmodel.SY_EXCEPTION.INSERT_CCGC(model_MES_SY_CCGCRETRUN);
            return mr;
        }
        [WebMethod]
        public MES_RETURN MES_PD_GD_SYNC_AUTO_TIME(string LOW, string HIGH)
        {
            MES_RETURN mr = mesmodel.MES_SYNC.MES_PD_GD_SYNC_AUTO(LOW, HIGH);
            MES_SY_CCGCRETRUN model_MES_SY_CCGCRETRUN = new MES_SY_CCGCRETRUN();
            model_MES_SY_CCGCRETRUN.LB = 4;
            model_MES_SY_CCGCRETRUN.CCGC = "MES_PD_GD_SYNC_AUTO";
            model_MES_SY_CCGCRETRUN.TYPE = mr.TYPE;
            model_MES_SY_CCGCRETRUN.MESSAGE = mr.MESSAGE;
            if (model_MES_SY_CCGCRETRUN.TYPE == "S")
            {
                model_MES_SY_CCGCRETRUN.MESSAGE = "LOW:" + LOW + "/HIGH:" + HIGH;
            }
            mesmodel.SY_EXCEPTION.INSERT_CCGC(model_MES_SY_CCGCRETRUN);
            return mr;
        }
        [WebMethod]
        public void SYNC_TB1()
        {
            MES_RETURN mr = new MES_RETURN();
            mr = rmsmodel.CRM_DRF.SYNC_DRFBILL();
            MES_SY_CCGCRETRUN model_MES_SY_CCGCRETRUN = new MES_SY_CCGCRETRUN();
            model_MES_SY_CCGCRETRUN.LB = 1;
            model_MES_SY_CCGCRETRUN.CCGC = "SYNC_DRFBILL";
            model_MES_SY_CCGCRETRUN.TYPE = mr.TYPE;
            model_MES_SY_CCGCRETRUN.MESSAGE = mr.MESSAGE;
            mesmodel.SY_EXCEPTION.INSERT_CCGC(model_MES_SY_CCGCRETRUN);

            mr = mesmodel.FB_QMP.SYNC_AUTO_CL();
        }
        [WebMethod]
        public void SYNC_TB2()
        {
            mesmodel.MES_SYNC.HR_KQ_KQINFO_AUTO_SYNC();
            mesmodel.MES_SYNC.HR_KQ_GSKQ_AUTO_INSERT();
        }
        [WebMethod]
        public void SYNC_TB3()
        {
            mesmodel.MES_SYNC.HR_KQ_DEPTKQ_AUTO_INSERT();
            mesmodel.MES_SYNC.MES_SYNC_ALL();
            MES_PD_GD_SYNC_AUTO();
            MES_PFDH_XFPC_SYNC();
            MES_SY_TPM_SYNC_AUTO();
        }
    }
}
