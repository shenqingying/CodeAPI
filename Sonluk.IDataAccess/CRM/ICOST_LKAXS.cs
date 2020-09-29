using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAXS
    {

        int CreateTT(CRM_COST_LKAXSTT model);
        int UpdateTT(CRM_COST_LKAXSTT model);
        IList<CRM_COST_LKAXSTT> ReadTTByParam(CRM_COST_LKAXSTT model, int STAFFID);
        int DeleteTT(int LKAXSTTID);
        IList<CRM_COST_LKAXSTT> ReadKHbasic(CRM_COST_LKAXSTT model);



        int CreateMX(CRM_COST_LKAXSMX model);
        int UpdateMX(CRM_COST_LKAXSMX model);
        IList<CRM_COST_LKAXSMX> ReadMXByTTID(CRM_COST_LKAXSMX model);
        int DeleteMX(int LKAXSMXID);








    }
}
