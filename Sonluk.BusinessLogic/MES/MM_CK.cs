using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class MM_CK
    {
        private static readonly IMM_CK mesdetaAccess = MESDataAccess.CreateMM_CK();

        public MES_RETURN INSERT(MES_MM_CK model)
        {
            return mesdetaAccess.INSERT(model);
        }

        public int SELECT_COUNT(MES_MM_CK model)
        {
            return mesdetaAccess.SELECT_COUNT(model);
        }

        public MES_RETURN UPDATE_SYNC(MES_MM_CK model)
        {
            return mesdetaAccess.UPDATE_SYNC(model);
        }

        public MES_MM_CK_SELECT SELECT(MES_MM_CK model)
        {
            return mesdetaAccess.SELECT(model);
        }
        public MES_MM_CK_SELECT SELECT_BY_STAFFID(MES_MM_CK model)
        {
            return mesdetaAccess.SELECT_BY_STAFFID(model);
        }
        public MES_MM_CK_SELECT SELECT_BY_ROLE_ASSEMBLE(MES_MM_CK model)
        {
            return mesdetaAccess.SELECT_BY_ROLE_ASSEMBLE(model);
        }
    }
}
