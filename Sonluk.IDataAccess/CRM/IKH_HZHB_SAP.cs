using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_HZHB_SAP
    {
        SAP_HZHBList SyncSapRead(IList<SAP_KH> t_KH,int khlx);
    }
}
