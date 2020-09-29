using Sonluk.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface ISender
    {
        IList<CompanyInfo> Read(bool available);

        CompanyInfo Read(string serialNumber);

    }
}
