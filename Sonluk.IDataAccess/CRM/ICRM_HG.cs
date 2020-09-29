using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICRM_HG
    {
        DataTable SelectHG_DICTwithTYPEID(int typeID, int fid);
    }
}
