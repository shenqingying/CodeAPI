using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_SCDATE_TH
    {
        private static readonly ISY_SCDATE_TH mesdetaAccess = MESDataAccess.CreateSY_SCDATE_TH();
        public MES_RETURN INSERT(List<MES_SY_SCDATE_TH> model)
        {
            MES_RETURN rst = new MES_RETURN();
            for (int a = 0; a < model.Count; a++)
            {
                if (model[a].LAY_CHECKED == false)
                {
                    rst = mesdetaAccess.UPDATE(model[a], 2);
                }
                else
                {
                    rst = mesdetaAccess.INSERT(model[a]);
                }
            }
            return rst;
        }
        public MES_RETURN UPDATE(MES_SY_SCDATE_TH model, int LB)
        {
            return mesdetaAccess.UPDATE(model, LB);
        }
        public MES_SY_SCDATE_TH_SELECT SELECT(MES_SY_SCDATE_TH_SELECT_IN model, int LB)
        {
            return mesdetaAccess.SELECT(model, LB);
        }
        public MES_SY_SCDATE_TH_SELECT SELECT_BY_ROLE(MES_SY_SCDATE_TH_SELECT_IN model, int LB)
        {
            return mesdetaAccess.SELECT_BY_ROLE(model, LB);
        }
    }
}
