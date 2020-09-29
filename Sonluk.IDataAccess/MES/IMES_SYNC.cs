using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IMES_SYNC
    {
        void HR_KQ_KQINFO_AUTO_SYNC();
        void HR_KQ_GSKQ_AUTO_INSERT();
        void HR_KQ_DEPTKQ_AUTO_INSERT();
    }
}
