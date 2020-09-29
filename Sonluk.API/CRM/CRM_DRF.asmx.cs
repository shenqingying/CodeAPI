using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using Sonluk.Entities.DRF;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// CRM_DRF 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class CRM_DRF : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        MESModels mesmodel = new MESModels();
        [WebMethod]
        public CRM_DRF_RETURNMSG status(int account)
        {
            return models.CRM_DRF.status(account);
        }
        [WebMethod]
        public CRM_DRF_RETURNMSG setAuth(string auth, int account)
        {
            return models.CRM_DRF.setAuth(auth, account);
        }
        [WebMethod]
        public MES_RETURN SYNC_DRFBILL()
        {
            MES_RETURN mr = models.CRM_DRF.SYNC_DRFBILL();
            MES_SY_CCGCRETRUN model_MES_SY_CCGCRETRUN = new MES_SY_CCGCRETRUN();
            model_MES_SY_CCGCRETRUN.LB = 1;
            model_MES_SY_CCGCRETRUN.CCGC = "SYNC_DRFBILL";
            model_MES_SY_CCGCRETRUN.TYPE = mr.TYPE;
            model_MES_SY_CCGCRETRUN.MESSAGE = mr.MESSAGE;
            mesmodel.SY_EXCEPTION.INSERT_CCGC(model_MES_SY_CCGCRETRUN);
            return mr;
        }
        [WebMethod]
        public byte[] downloadPDF(string PDFPATH)
        {
            string map = Server.MapPath("~");
            return models.CRM_DRF.downloadPDF(PDFPATH, map);
        }
        [WebMethod]
        public byte[] SCREENSHOT(int shotlb)
        {
            string map = Server.MapPath("~");
            return models.CRM_DRF.SCREENSHOT(shotlb, map);
        }
        [WebMethod]
        public DRF_LATEST_RETURN latest()
        {
            return models.CRM_DRF.latest();
        }
        [WebMethod]
        public CRM_ORDER_DRF_USER_SELECT SELECT_USER_SYNC(CRM_ORDER_DRF_USER model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_DRF.SELECT_USER_SYNC(model);
            }
            else
            {
                CRM_ORDER_DRF_USER_SELECT rst = new CRM_ORDER_DRF_USER_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN DRFBILL_UPDATEMX_AGAIN(int ORDERTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_DRF.DRFBILL_UPDATEMX_AGAIN(ORDERTTID);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
    }
}
