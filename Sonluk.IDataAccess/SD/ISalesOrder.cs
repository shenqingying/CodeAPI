using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.SD;
using Sonluk.Entities.MM;

namespace Sonluk.IDataAccess.SD
{
    public interface ISalesOrder
    {
        string Create(SOInfo node);

        IList<SOItemInfo> Read(SOKeywordInfo keyword);

        string  ProcessingRecords(SOItemInfo node);

        IList<CustomTextInfo> CustomText(string serialNumber, int item, string matlGroup);

      
    }
}
