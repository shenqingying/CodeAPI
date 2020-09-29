using Sonluk.Entities.RMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.RMS
{
    public interface IProduct
    {
        DataTable getPMINFO(string PM, string CPGG, string LB);
        DataTable getYCLINFO(string SCXName, string CPID, string Date, string TLSJ);
        DataTable getYCLINFO_new_td(string SCXName, string CPID, string Date, string TLSJ);
        DataTable getYCLINFO_new_MFQ(string SCXName, string CPID, string Date, string TLSJ);
        DataTable getYCLINFO_new_GK(string SCXName, string CPID, string Date, string TLSJ);
        DataTable getSDZH(string SCX, string SCRQ, string SCSJ);
        DataTable getYCLINFO_new_ZJ(string SCXName, string CPID, string Date, string TLSJ);
        DataTable getYCLINFO_new_FJ(string SCXName, string CPID, string Date, string TLSJ);
        DataTable getYCLINFO_new_BB(string SCX, string SCRQ, string SCSJ);
        DataTable getBBDATE(string SDLINE, string SDDATE, string SDZH);

        IList<BatteryInfo> Type();
    }
}
