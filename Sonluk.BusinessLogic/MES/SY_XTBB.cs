using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_XTBB
    {
        private static readonly ISY_XTBB ISY_XTBBdata = MESDataAccess.CreateSY_XTBB();
        public MES_RETURN INSERT(MES_SY_XTBB model)
        {
            return ISY_XTBBdata.INSERT(model);
        }
        public MES_RETURN DELETE(int ID)
        {
            return ISY_XTBBdata.DELETE(ID);
        }
        public MES_SY_XTBB_SELECT SELECT(MES_SY_XTBB model)
        {
            return ISY_XTBBdata.SELECT(model);
        }
        public MES_RETURN UPDATE(MES_SY_XTBB model)
        {
            return ISY_XTBBdata.UPDATE(model);
        }
    }
}
