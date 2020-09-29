using Sonluk.Entities.QM;
using Sonluk.Entities.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.QM
{
    public interface IQualityNotification
    {
        MessageInfo Create(QNInfo node);

        MessageInfo CreateQ1(QNInfo node);

        MessageInfo Update(QNInfo node);

        MessageInfo UpdateZ2(QNInfo node);

        MessageInfo UpdateZ3(QNInfo node);

        MessageInfo Update(string serialNumber, string creator);

        IList<QNInfo> Read();

        IList<QNInfo> Read(string type);

        IList<QNInfo> ReadZ2();

        IList<QNInfo> ReadZ3();
 
    }
}
