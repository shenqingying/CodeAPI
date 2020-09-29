using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class PD_GD_BOM
    {
        private static readonly IPD_GD_BOM mesdetaAccess = MESDataAccess.CreatePD_GD_BOM();
        public MES_RETURN INSERT(MES_PD_GD_BOM model)
        {
            return mesdetaAccess.INSERT(model);
        }
        public MES_RETURN DELETE(MES_PD_GD_BOM model, int DELETELB)
        {
            return mesdetaAccess.DELETE(model, DELETELB);
        }
        public MES_PD_GD_BOM_SELECT SELECT(MES_PD_GD_BOM model)
        {
            return mesdetaAccess.SELECT(model);
        }
    }
}
