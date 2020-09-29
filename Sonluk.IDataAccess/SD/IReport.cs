using Sonluk.Entities.SD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.SD
{
    public interface IReport
    {
        IList<ReportInfo> AC(string dateStart, string dateEnd, string customer);


        IList<ReportInfo> SO(string customerPOStart, string customerPOEnd, string dateStart, string dateEnd, string materialStart, string materialEnd);


        IList<ReportInfo> SH(string customerPOStart, string customerPOEnd, string dateStart, string dateEnd, string materialStart, string materialEnd);

        IList<ReportInfo> SHFH(string customer, string dateStart, string dateEnd);

        IList<ReportInfo> ZKMX(string customer, string dateStart, string dateEnd);

    }
}
