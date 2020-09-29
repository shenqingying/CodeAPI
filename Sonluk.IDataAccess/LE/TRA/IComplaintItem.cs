using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface IComplaintItem
    {
        List<ComplaintItemInfo> Read(int headerID);

        int Create(ComplaintItemInfo node);

        int Delete(int headerID);
    }
}
