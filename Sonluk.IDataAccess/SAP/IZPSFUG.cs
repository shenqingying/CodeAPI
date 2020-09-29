using Sonluk.Entities.PS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.SAP
{
    public interface IZPSFUG
    {
        ZPSFUG_Q_XMXXOA_SELECT ZPSFUG_Q_XMXXOA(string POSID, string PSPID);
    }
}
