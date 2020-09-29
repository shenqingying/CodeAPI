using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_GC
    {
        private static readonly ISY_GC mesdetaAccess = MESDataAccess.CreateSY_GC();

        public IList<MES_SY_GC> read(MES_SY_GC model)
        {
            return mesdetaAccess.read(model);
        }

        public MES_RETURN delete(string GC)
        {
            return mesdetaAccess.delete(GC);
        }

        public MES_RETURN UPDATE(MES_SY_GC model)
        {
            return mesdetaAccess.UPDATE(model);
        }

        public MES_RETURN insert(MES_SY_GC model)
        {
            MES_RETURN mr = new MES_RETURN();
            if (mesdetaAccess.SELECT_COUNT(model) > 0)
            {
                mr.TYPE = "E";
                mr.MESSAGE = "已存在该工厂编号";
                return mr;
            }
            else
            {
                return mesdetaAccess.insert(model);
            }
        }

        public IList<MES_SY_GC> SELECT_BY_ROLE(MES_SY_GC model)
        {
            return mesdetaAccess.SELECT_BY_ROLE(model);
        }

        public MES_SY_GC_LAY_SELECT SELECT_LAY(int STAFFID)
        {
            return mesdetaAccess.SELECT_LAY(STAFFID);
        }
    }
}
