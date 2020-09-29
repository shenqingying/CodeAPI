using Sonluk.DAFactory;
using Sonluk.Entities.KQ;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using Sonluk.IDataAccess.KQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class KQ_KQINFO
    {
        private static readonly IKQ_KQINFO IKQ_KQINFOdata = HRDataAccess.CreateIKQ_KQINFO();
        private static readonly IKQinfo IKQinfodata = KQDataAccess.CreateKQinfo();
        public int SELECT_MAX()
        {
            return IKQ_KQINFOdata.SELECT_MAX();
        }
        public MES_RETURN INSERT(HR_KQ_KQINFO model)
        {
            return IKQ_KQINFOdata.INSERT(model);
        }
        public MES_RETURN SYNC()
        {
            MES_RETURN rst = new MES_RETURN();
            HR_KQ_KQINFO model_HR_KQ_KQINFO = new HR_KQ_KQINFO();
            model_HR_KQ_KQINFO.Id = IKQ_KQINFOdata.SELECT_MAX();
            HR_KQ_KQINFO_SELECT rst_HR_KQ_KQINFO_SELECT = IKQinfodata.SELECT(model_HR_KQ_KQINFO);
            if (rst_HR_KQ_KQINFO_SELECT.MES_RETURN.TYPE == "S")
            {
                for (int a = 0; a < rst_HR_KQ_KQINFO_SELECT.HR_KQ_KQINFO_LIST.Count; a++)
                {
                    IKQ_KQINFOdata.INSERT(rst_HR_KQ_KQINFO_SELECT.HR_KQ_KQINFO_LIST[a]);
                    rst.TYPE = "S";
                }
            }
            else
            {
                rst = rst_HR_KQ_KQINFO_SELECT.MES_RETURN;
            }
            return rst;
        }
        public HR_KQ_KQINFO_SELECT SELECT(HR_KQ_KQINFO model)
        {
            return IKQ_KQINFOdata.SELECT(model);
        }
    }
}
