using Sonluk.Entities.QM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.QM
{
    public interface IZSL_QMFG_RFC
    {
        ZSL_QMFM_012_SELECT ZSL_QMFM_012(ZSL_QMFM_012_SELECT model);
    }
}
