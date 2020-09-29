using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface IComplaint
    {
        int Create(ComplaintInfo node);

        IList<ComplaintInfo> Read(ComplaintInfo keywords);

        ComplaintInfo Read(int ID);

        int Update(ComplaintInfo node);

        int Delete(int ID);

        IList<ComplaintInfo> Report(ComplaintInfo keywords);
    }
}
