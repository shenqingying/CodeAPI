using Sonluk.BusinessLogic.KQ;
using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class TM_CZR
    {
        KQinfo KQinfoService = new KQinfo();
        private static readonly ITM_CZR mesdetaAccess = MESDataAccess.CreateTM_CZR();
        public MES_RETURN INSERT(MES_TM_CZR model)
        {
            MES_RETURN mr = new MES_RETURN();
            if (string.IsNullOrEmpty(model.CZRGH))
            {
                model.CZRGH = "";
            }
            if (model.CZRGH != "")
            {
                model.CZRNAME = KQinfoService.GET_STAFFNAME_BYGH(model.CZRGH);
            }
            if (model.CZRNAME == "")
            {
                mr.TYPE = "E";
                mr.MESSAGE = "请检查输入工号";
                return mr;
            }
            else
            {
                return mesdetaAccess.INSERT(model);
            }
        }

        public MES_TM_CZR_SELECT_CZR_NOW SELECT_CZR_NOW(MES_TM_CZR model)
        {
            return mesdetaAccess.SELECT_CZR_NOW(model);
        }

        public MES_RETURN UPDATE_LEAVE(int ID)
        {
            return mesdetaAccess.UPDATE_LEAVE(ID);
        }

        public MES_RETURN UPDATE_GW(MES_TM_CZR model)
        {
            return mesdetaAccess.UPDATE_GW(model);
        }

        public MES_SY_CZR_BYGH GET_RYNAME(string GH)
        {
            MES_SY_CZR_BYGH rst = new MES_SY_CZR_BYGH();
            rst.NAME = KQinfoService.GET_STAFFNAME_BYGH(GH);
            rst.GH = GH;
            return rst;
        }
    }
}
