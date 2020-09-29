using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IBC_CHTT_FAKE
    {
        int TTCreate(CRM_BC_CHTT model);
        int MXCreate(CRM_BC_CHMX model);
        int TTMXDelete();


    }
}
