using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_TPM_SYNC
    {
        private static readonly ISY_TPM_SYNC data_ISY_TPM_SYNC = MESDataAccess.CreateISY_TPM_SYNC();
        public MES_SY_TPM_SYNC_SELECT SELECT(MES_SY_TPM_SYNC model)
        {
            return data_ISY_TPM_SYNC.SELECT(model);
        }
    }
}
