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
    public class XZGL_FLFA
    {
        private static readonly IXZGL_FLFA IXZGL_FLFAdata = HRDataAccess.CreateXZGL_FLFA();
        private static readonly IXZGL_FLFAMX IXZGL_FLFAMXdata = HRDataAccess.CreateXZGL_FLFAMX();
        public MES_RETURN INSERT(HR_XZGL_FLFA model)
        {
            MES_RETURN rst = IXZGL_FLFAdata.INSERT(model);
            if (rst.TYPE == "S")
            {
                if (model.HR_XZGL_FLFAMX == null)
                {

                }
                else
                {
                    for (int a = 0; a < model.HR_XZGL_FLFAMX.Count; a++)
                    {
                        model.HR_XZGL_FLFAMX[a].FLFAID = rst.TID;
                        IXZGL_FLFAMXdata.INSERT(model.HR_XZGL_FLFAMX[a]);
                    }
                }
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_FLFA model, int LB)
        {
            return IXZGL_FLFAdata.UPDATE(model, LB);
        }
        public HR_XZGL_FLFA_SELECT SELECT(HR_XZGL_FLFA model)
        {
            return IXZGL_FLFAdata.SELECT(model);
        }
    }
}
