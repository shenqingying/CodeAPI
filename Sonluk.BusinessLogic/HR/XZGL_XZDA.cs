using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class XZGL_XZDA
    {
        private static readonly IXZGL_XZDA IXZGL_XZDAdata = HRDataAccess.CreateXZGL_XZDA();
        private static readonly ISY_MYINFO ISY_MYINFOdata = HRDataAccess.CreateSY_MYINFO();
        public MES_RETURN INSERT(HR_XZGL_XZDA model)
        {
            return IXZGL_XZDAdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_XZGL_XZDA model, int LB)
        {
            return IXZGL_XZDAdata.UPDATE(model, LB);
        }
        public HR_XZGL_XZDA_SELECT SELECT(HR_XZGL_XZDA model)
        {
            HR_XZGL_XZDA_SELECT rst = new HR_XZGL_XZDA_SELECT();
            //MES_RETURN child_MES_RETURN = new MES_RETURN();
            //child_MES_RETURN = ISY_MYINFOdata.JM_ISTRUE(model.MYPW, model.STAFFID);
            //if (child_MES_RETURN.TYPE == "S")
            //{
            //    rst = IXZGL_XZDAdata.SELECT(model);
            //}
            //else
            //{
            //    rst.MES_RETURN = child_MES_RETURN;
            //}
            rst = IXZGL_XZDAdata.SELECT(model);
            return rst;
        }
        public HR_XZGL_XZDA_SELECT SELECT_ALL(HR_XZGL_XZDA model, int LB)
        {
            HR_XZGL_XZDA_SELECT rst = new HR_XZGL_XZDA_SELECT();
            //MES_RETURN child_MES_RETURN = new MES_RETURN();
            //child_MES_RETURN = ISY_MYINFOdata.JM_ISTRUE(model.MYPW, model.STAFFID);
            //if (child_MES_RETURN.TYPE == "S")
            //{
            //    rst = IXZGL_XZDAdata.SELECT_ALL(model, LB);
            //}
            //else
            //{
            //    rst.MES_RETURN = child_MES_RETURN;
            //}
            rst = IXZGL_XZDAdata.SELECT_ALL(model, LB);
            return rst;
        }
        public HR_XZGL_XZDA_SELECT SELECT_NOMY(HR_XZGL_XZDA model, int LB)
        {
            return IXZGL_XZDAdata.SELECT_ALL(model, LB);
        }
        public MES_RETURN AUTO_ADD_TO_FFJLMX(HR_XZGL_XZDA model)
        {
            return IXZGL_XZDAdata.AUTO_ADD_TO_FFJLMX(model);
        }
    }
}
