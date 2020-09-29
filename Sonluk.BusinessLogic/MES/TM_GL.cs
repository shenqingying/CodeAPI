using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class TM_GL
    {
        private static readonly ITM_GL mesdetaAccess = MESDataAccess.CreateTM_GL();
        public MES_RETURN INSERT(List<MES_TM_GL> model, int SCTMID)
        {
            return mesdetaAccess.INSERT(model);
        }
        public MES_RETURN DELETE_BY_SCTM(string SCTM)
        {
            return mesdetaAccess.DELETE_BY_SCTM(SCTM);
        }
        public MES_TM_GL_SELECT SELECT(MES_TM_GL model)
        {
            return mesdetaAccess.SELECT(model);
        }
    }
}
