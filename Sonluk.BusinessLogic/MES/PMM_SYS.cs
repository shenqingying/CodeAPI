using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class PMM_SYS
    {
        private static readonly IPMM_SYS mesdataAccess = MESDataAccess.CreatePMM_SYS();

        public MES_PMM_SYS SELECT(MES_PMM_SYS model)
        {
            return mesdataAccess.SELECT(model);
        }
        public MES_RETURN UPDATE(MES_PMM_SYS model)
        {
            return mesdataAccess.UPDATE(model);
        }
    }
}
