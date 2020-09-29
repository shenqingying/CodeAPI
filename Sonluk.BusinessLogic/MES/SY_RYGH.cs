using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_RYGH
    {
        private static readonly ISY_RYGH data_ISY_RYGH = MESDataAccess.CreateISY_RYGH();
        public MES_RETURN INSERT_GS(MES_SY_RYGH_GS model)
        {
            return data_ISY_RYGH.INSERT_GS(model);
        }
        public MES_SY_RYGH_GS_SELECT SELECT_GS(MES_SY_RYGH_GS model)
        {
            return data_ISY_RYGH.SELECT_GS(model);
        }
        public MES_RETURN INSERT(MES_SY_RYGH model)
        {
            return data_ISY_RYGH.INSERT(model);
        }
        public MES_SY_RYGH_SELECT SELECT(MES_SY_RYGH model)
        {
            return data_ISY_RYGH.SELECT(model);
        }
        public MES_RETURN UPDATE(MES_SY_RYGH model)
        {
            return data_ISY_RYGH.UPDATE(model);
        }
    }
}
