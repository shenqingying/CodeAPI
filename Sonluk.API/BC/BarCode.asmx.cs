using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Sonluk.API.Models;
using System.Drawing;
using Sonluk.Entities.BC;
using Sonluk.Entities.LE;
using System.Web.Script.Serialization;
using Sonluk.Entities.MES;

namespace Sonluk.API.BC
{
    /// <summary>
    /// BarCode 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BarCode : System.Web.Services.WebService
    {

        BCModels models = new BCModels();
        LETRAModels lemodels = new LETRAModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public Byte[] CreateBarCode(string code, string format, int width, int height, int pure)
        {
            return models.BarCode.CreateBarCode(code, format, width, height, pure);
        }

        [WebMethod]
        public string ZBCFUN_TBM_ZFTH(string srwlm, string tgwlm, string fcode)
        {
            return models.BarCode.ZBCFUN_TBM_ZFTH(srwlm, tgwlm, fcode);
        }

        [WebMethod]
        public ZSL_BCS007 ZBCFUN_MAT_GET(string matnr)
        {
            return models.BarCode.ZBCFUN_MAT_GET(matnr);
        }

        [WebMethod]
        public PickingtaskInfo ZBCFUN_CKGDP_DISPLAY(string IV_CJRQ, string IV_LGNUM)
        {
            return models.BarCode.ZBCFUN_CKGDP_DISPLAY(IV_CJRQ, IV_LGNUM);
        }

        //[WebMethod]
        //public bool SFLTBS(string matnr)
        //{
        //    return models.BarCode.SFLTBS(matnr);
        //}

        [WebMethod]
        public ScreenInfo ScreenInfoRead(int ID)
        {
            return lemodels.Screen.Read(ID);
        }

        [WebMethod]
        public int ScreenInfoUpdate(ScreenInfo node)
        {
            return lemodels.Screen.Update(node);
        }

        [WebMethod]
        public List<ScreenInfo> ScreenInfoReadALL()
        {
            return lemodels.Screen.Read().ToList();
        }

        [WebMethod]
        public List<ZSL_BCS107> ZBCFUN_LTPM_READ(string IV_LGNUM, string IV_JPD, string IV_CJRQ_S, string IV_CJRQ_E, string IV_VBELN)
        {
            return models.BarCode.ZBCFUN_LTPM_READ(IV_LGNUM, IV_JPD, IV_CJRQ_S, IV_CJRQ_E, IV_VBELN).ToList();
        }

        [WebMethod]
        public List<ZSL_BCS107> PickingListREAD(string IV_LGNUM, string IV_JPD, string IV_CJRQ_S, string IV_CJRQ_E, string IV_VBELN)
        {
            return models.BarCode.PickingListREAD(IV_LGNUM, IV_JPD, IV_CJRQ_S, IV_CJRQ_E, IV_VBELN).ToList();
        }

        [WebMethod]
        public string ZBCFUN_WLZS_READ_JSON(string IV_WLM)
        {
            string rtn = "";
            JavaScriptSerializer jss = new JavaScriptSerializer();

            TrackInfo ti = models.BarCode.ZBCFUN_WLZS_READ(IV_WLM);

            if (ti.ET_RETURN.Count == 0)
            {
                rtn = jss.Serialize(ti.ES_109);
            }
            else
            {
                rtn = jss.Serialize(ti.ET_RETURN);
            }

            return rtn;
        }

        [WebMethod]
        public TrackInfo ZBCFUN_WLZS_READ(string IV_WLM)
        {
            TrackInfo ti = models.BarCode.ZBCFUN_WLZS_READ(IV_WLM);

            return ti;
        }
        [WebMethod]
        public MODEL_ZBCFUN_CUS_GET GET_ZBCFUN_CUS_GET(string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.BarCode.GET_ZBCFUN_CUS_GET();
            }
            else
            {
                MODEL_ZBCFUN_CUS_GET rst = new MODEL_ZBCFUN_CUS_GET();
                List<ZSL_BCST100> child_ET_RETURN = new List<ZSL_BCST100>();
                ZSL_BCST100 child = new ZSL_BCST100();
                child.Message = "ptoken不正确，请重新登录！";
                child_ET_RETURN.Add(child);
                rst.ET_RETURN = child_ET_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MODEL_ZBCFUN_DLV_GET GET_ZBCFUN_DLV_GET(string IV_DATE, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.BarCode.GET_ZBCFUN_DLV_GET(IV_DATE, "Z");
            }
            else
            {
                MODEL_ZBCFUN_DLV_GET rst = new MODEL_ZBCFUN_DLV_GET();
                List<ZSL_BCST100> child_ET_RETURN = new List<ZSL_BCST100>();
                ZSL_BCST100 child = new ZSL_BCST100();
                child.Message = "ptoken不正确，请重新登录！";
                child_ET_RETURN.Add(child);
                rst.ET_RETURN = child_ET_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MODEL_ZBCFUN_DLV_GET GET_ZBCFUN_DLV_GET_CRM(string IV_DATE, string IV_SYS, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.BarCode.GET_ZBCFUN_DLV_GET(IV_DATE, IV_SYS);
            }
            else
            {
                MODEL_ZBCFUN_DLV_GET rst = new MODEL_ZBCFUN_DLV_GET();
                List<ZSL_BCST100> child_ET_RETURN = new List<ZSL_BCST100>();
                ZSL_BCST100 child = new ZSL_BCST100();
                child.Message = "ptoken不正确，请重新登录！";
                child_ET_RETURN.Add(child);
                rst.ET_RETURN = child_ET_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MODEL_ZBCFUN_MAT_GET GET_ZBCFUN_MAT_GET(string IV_DATUM, string IV_MTART, string IV_MATNR, string IV_ZSBS, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.BarCode.GET_ZBCFUN_MAT_GET(IV_DATUM, IV_MTART, IV_MATNR, IV_ZSBS);
            }
            else
            {
                MODEL_ZBCFUN_MAT_GET rst = new MODEL_ZBCFUN_MAT_GET();
                List<ZSL_BCST100> child_ET_RETURN = new List<ZSL_BCST100>();
                ZSL_BCST100 child = new ZSL_BCST100();
                child.Message = "ptoken不正确，请重新登录！";
                child_ET_RETURN.Add(child);
                rst.ET_RETURN = child_ET_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MODEL_ZBCFUN_ORT_GET GET_ZBCFUN_ORT_GET(string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.BarCode.GET_ZBCFUN_ORT_GET();
            }
            else
            {
                MODEL_ZBCFUN_ORT_GET rst = new MODEL_ZBCFUN_ORT_GET();
                List<ZSL_BCST100> child_ET_RETURN = new List<ZSL_BCST100>();
                ZSL_BCST100 child = new ZSL_BCST100();
                child.Message = "ptoken不正确，请重新登录！";
                child_ET_RETURN.Add(child);
                rst.ET_RETURN = child_ET_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MODEL_ZBCFUN_TM_READ GET_ZBCFUN_TM_READ(string IV_AUFNR, string IV_KZBEW, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.BarCode.GET_ZBCFUN_TM_READ(IV_AUFNR, IV_KZBEW);
            }
            else
            {
                MODEL_ZBCFUN_TM_READ rst = new MODEL_ZBCFUN_TM_READ();
                List<ZSL_BCT100> child_ZSL_BCT100 = new List<ZSL_BCT100>();
                RETURN_MSG child_RETURN_MSG = new RETURN_MSG();
                child_RETURN_MSG.MESSAGE = "ptoken不正确，请重新登录！";
                rst.ET_TM = child_ZSL_BCT100;
                rst.RETURN_MSG = child_RETURN_MSG;
                return rst;
            }
        }
        [WebMethod]
        public MODEL_ZBCFUN_THLOG_READ GET_ZBCFUN_THLOG_READ(string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.BarCode.GET_ZBCFUN_THLOG_READ();
            }
            else
            {
                MODEL_ZBCFUN_THLOG_READ rst = new MODEL_ZBCFUN_THLOG_READ();
                List<ZSL_BCT108> child_ET_THLOG = new List<ZSL_BCT108>();
                RETURN_MSG child_RETURN_MSG = new RETURN_MSG();
                child_RETURN_MSG.MESSAGE = "ptoken不正确，请重新登录！";
                rst.ET_THLOG = child_ET_THLOG;
                rst.RETURN_MSG = child_RETURN_MSG;
                return rst;
            }
        }

        [WebMethod]
        public MODEL_ZBCFUN_DLV_GET GET_ZBCFUN_DLV_GET2(string KHmodeldata, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.BarCode.GET_ZBCFUN_DLV_GET2(KHmodeldata);
            }
            else
            {
                MODEL_ZBCFUN_DLV_GET rst = new MODEL_ZBCFUN_DLV_GET();
                List<ZSL_BCST100> child_ET_RETURN = new List<ZSL_BCST100>();
                ZSL_BCST100 child = new ZSL_BCST100();
                child.Message = "ptoken不正确，请重新登录！";
                child_ET_RETURN.Add(child);
                rst.ET_RETURN = child_ET_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MODEL_ZBCFUN_POITEM_READ GET_ZBCFUN_POITEM_READ(string IV_EBELN, string IV_EBELP, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.BarCode.GET_ZBCFUN_POITEM_READ(IV_EBELN, IV_EBELP);
            }
            else
            {
                MODEL_ZBCFUN_POITEM_READ rst = new MODEL_ZBCFUN_POITEM_READ();
                List<ZSL_BCST100> child_ET_RETURN = new List<ZSL_BCST100>();
                ZSL_BCST100 child = new ZSL_BCST100();
                child.Type = "E";
                child.Message = "ptoken不正确，请重新登录！";
                child_ET_RETURN.Add(child);
                rst.ET_RETURN = child_ET_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public ZSL_BCST100 GET_ZBCFUN_PO_RECEIPT(string IV_CKDJH, string IV_KZBEW, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.BarCode.GET_ZBCFUN_PO_RECEIPT(IV_CKDJH, IV_KZBEW);
            }
            else
            {

                ZSL_BCST100 child = new ZSL_BCST100();
                child.Type = "E";
                child.Message = "ptoken不正确，请重新登录！";
                return child;
            }
        }


        [WebMethod]
        public MODEL_ZBCFUN_JHD_READ JHD_READ(string VBELN, string ptoken)
        {

            MODEL_ZBCFUN_JHD_READ node = new MODEL_ZBCFUN_JHD_READ();
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.BarCode.JHD_READ(VBELN);
            }
            return node;
        }


        [WebMethod]
        public MES_RETURN JHD_UPDATE(List<ZSL_BCT110> model, string ptoken)
        {

            MES_RETURN node = new MES_RETURN();
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.BarCode.JHD_UPDATE(model);
            }
            return node;
        }


        [WebMethod]
        public MODEL_ZBCFUN_JHZ_READ JHZ_READ(MODEL_ZBCFUN_JHZ_READ model, string ptoken)
        {
            MODEL_ZBCFUN_JHZ_READ node = new MODEL_ZBCFUN_JHZ_READ();
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.BarCode.JHZ_READ(model);
            }
            return node;
        }




    }
}
