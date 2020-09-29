using Sonluk.Entities.OA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.OA
{
    public interface IAffair
    {
        string Pending(string tokenId, string ticketId, int firstNum, int pageSize);
    }
}
