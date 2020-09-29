using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_PFDH_CHILD
    {
        private static readonly ISY_PFDH_CHILD mesdetaAccess = MESDataAccess.CreateSY_PFDH_CHILD();
        public MES_RETURN INSERT(MES_SY_PFDH_CHILD model)
        {
            return mesdetaAccess.INSERT(model);
        }
        public MES_RETURN INSERT_LIST(List<MES_SY_PFDH_CHILD> model)
        {
            MES_RETURN rst_MES_RETURN = new MES_RETURN();
            if (model.Count > 0)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    rst_MES_RETURN = mesdetaAccess.INSERT(model[i]);
                }
            }
            else
            {
                rst_MES_RETURN.TYPE = "E";
                rst_MES_RETURN.MESSAGE = "无传入数据！";
            }
            return rst_MES_RETURN;
        }
        public MES_RETURN DELETE(MES_SY_PFDH_CHILD model, int LB)
        {
            return mesdetaAccess.DELETE(model, LB);
        }
        public MES_SY_PFDH_CHILD_SELECT SELECT(MES_SY_PFDH_CHILD model)
        {
            return mesdetaAccess.SELECT(model);
        }
    }
}
