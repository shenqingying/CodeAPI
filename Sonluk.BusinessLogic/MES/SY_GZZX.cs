using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_GZZX
    {
        private static readonly ISY_GZZX mesdetaAccess = MESDataAccess.CreateSY_GZZX();
        public MES_RETURN INSERT(MES_SY_GZZX model, int ISAUTO)
        {
            return mesdetaAccess.INSERT(model, ISAUTO);
        }

        public MES_RETURN DELETE(MES_SY_GZZX model)
        {
            return mesdetaAccess.DELETE(model);
        }

        public MES_RETURN UPDATE(MES_SY_GZZX model, int ISAUTO)
        {
            return mesdetaAccess.UPDATE(model, ISAUTO);
        }

        public IList<MES_SY_GZZX> SELECT(MES_SY_GZZX model)
        {
            return mesdetaAccess.SELECT(model);
        }

        public int SELECT_COUNT(string GZZXBH, string GC)
        {
            return mesdetaAccess.SELECT_COUNT(GZZXBH, GC);
        }

        public IList<MES_SY_GZZX> SELECT_BY_ROLE(MES_SY_GZZX model)
        {
            return mesdetaAccess.SELECT_BY_ROLE(model);
        }

        public MES_SY_GZZX_GW_LIST SELECT_GZZX_GW(MES_SY_GZZX model)
        {
            return mesdetaAccess.SELECT_GZZX_GW(model);
        }
        public List<MES_SY_GZZX> SELECT_LB(MES_SY_GZZX model)
        {
            return mesdetaAccess.SELECT_LB(model);
        }
    }
}
