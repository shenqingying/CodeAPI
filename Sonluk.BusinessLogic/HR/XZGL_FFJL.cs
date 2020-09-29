using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class XZGL_FFJL
    {
        private static readonly IXZGL_FFJL IXZGL_FFJLdata = HRDataAccess.CreateXZGL_FFJL();
        private static readonly IXZGL_FFJLMX IXZGL_FFJLMXdata = HRDataAccess.CreateXZGL_FFJLMX();
        private static readonly ISY_MYINFO ISY_MYINFOdata = HRDataAccess.CreateSY_MYINFO();
        public MES_RETURN INSERT(HR_XZGL_FFJL model)
        {
            return IXZGL_FFJLdata.INSERT(model);
        }
        public HR_XZGL_FFJL_SELECT SELECT(HR_XZGL_FFJL model, int LB)
        {
            return IXZGL_FFJLdata.SELECT(model, LB);
        }
        public MES_RETURN UPDATE(HR_XZGL_FFJL model, int LB)
        {
            HR_XZGL_FFJL model_HR_XZGL_FFJL = new HR_XZGL_FFJL();
            model_HR_XZGL_FFJL.FFJLID = model.FFJLID;
            MES_RETURN rst = new MES_RETURN();
            if (LB == 2)
            {
                int isffnow = 0;
                HR_XZGL_FFJL_SELECT rst_HR_XZGL_FFJL_SELECT = IXZGL_FFJLdata.SELECT_ISFFNOWCOUNT();
                if (rst_HR_XZGL_FFJL_SELECT.MES_RETURN.TYPE != "S")
                {
                    return rst;
                }
                isffnow = Convert.ToInt32(rst_HR_XZGL_FFJL_SELECT.DATALIST.Rows[0][0].ToString());
                if (isffnow > 0)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "有发放记录正在发放计算中，不允许多条数据同时计算！请稍微重试！";
                    return rst;
                }
                rst = IXZGL_FFJLdata.UPDATE(model_HR_XZGL_FFJL, 3);
                if (rst.TYPE != "S")
                {
                    return rst;
                }
                HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                model_HR_XZGL_FFJLMX.FFJLID = model.FFJLID;
                model_HR_XZGL_FFJLMX.MYPW = model.MYPW;
                rst = IXZGL_FFJLMXdata.FORMULA_JS(model_HR_XZGL_FFJLMX, 1);
                if (rst.TYPE != "S")
                {
                    IXZGL_FFJLdata.UPDATE(model_HR_XZGL_FFJL, 4);
                    return rst;
                }
            }
            rst = IXZGL_FFJLdata.UPDATE(model, LB);
            if (LB == 2)
            {
                rst = IXZGL_FFJLdata.UPDATE(model_HR_XZGL_FFJL, 4);
                if (rst.TYPE != "S")
                {
                    return rst;
                }
            }
            return rst;
        }

        public MES_RETURN ZQMONTH_UPDATE(HR_XZGL_FFJL model)
        {
            return IXZGL_FFJLdata.ZQMONTH_UPDATE(model);
        }
        public HR_XZGL_FFJL_SELECT ZQMONTH_SELECT(HR_XZGL_FFJL model)
        {
            return IXZGL_FFJLdata.ZQMONTH_SELECT(model);
        }
        public HR_XZGL_FFJL_SELECT ZQMONTH_SELECT_LB(HR_XZGL_FFJL model)
        {
            return IXZGL_FFJLdata.ZQMONTH_SELECT_LB(model);
        }
        //public MES_RETURN MYPW_ISTRUE(string MYPW, int STAFFID)
        //{
        //    MES_RETURN rst = new MES_RETURN();
        //    rst = ISY_MYINFOdata.JM_ISTRUE(MYPW, STAFFID);
        //    if (rst.TYPE == "S")
        //    {
        //        HR_SY_MYINFO_SELECT rst_HR_SY_MYINFO_SELECT = new HR_SY_MYINFO_SELECT();
        //        HR_SY_MYINFO model_HR_SY_MYINFO = new HR_SY_MYINFO();
        //        model_HR_SY_MYINFO.MYPW = MYPW;
        //        model_HR_SY_MYINFO.STAFFID = STAFFID;
        //        model_HR_SY_MYINFO.MYLB = 3;
        //        rst_HR_SY_MYINFO_SELECT = ISY_MYINFOdata.SELECT(model_HR_SY_MYINFO, 2);
        //        if (rst_HR_SY_MYINFO_SELECT.MES_RETURN.TYPE == "S")
        //        {
        //            if (rst_HR_SY_MYINFO_SELECT.DATALIST.Rows.Count > 0)
        //            {
        //                rst.TYPE = "S";
        //                rst.MESSAGE = rst_HR_SY_MYINFO_SELECT.DATALIST.Rows[0]["MYINFO"].ToString();
        //                return rst;
        //            }
        //            else
        //            {
        //                rst.TYPE = "E";
        //                rst.MESSAGE = "请检查密钥是否存在！";
        //                return rst;
        //            }
        //        }
        //        else
        //        {
        //            return rst_HR_SY_MYINFO_SELECT.MES_RETURN;
        //        }
        //    }
        //    else
        //    {
        //        return rst;
        //    }
        //}
    }
}
