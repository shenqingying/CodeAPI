using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.OA
{
    public interface IMessage
    {
        bool Send(string tokenID, IList<string> names, string content, IList<string> url);
    }
}
