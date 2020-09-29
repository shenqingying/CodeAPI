using Sonluk.DataAccess.OA.Seeyon.AffairAPI;
using Sonluk.Entities.OA;
using Sonluk.IDataAccess.OA;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.OA
{
    public class Affair : IAffair
    {
        private affairServicePortTypeClient _Client = new affairServicePortTypeClient("affairServiceHttpSoap12Endpoint", AppConfig.Settings("OA") + "seeyon/services/affairService.affairServiceHttpSoap12Endpoint/");

        public string Pending(string tokenID, string ticketId, int firstNum, int pageSize)
        {

            return _Client.exportPendingList(tokenID, ticketId, firstNum, pageSize);
        }
    }
}
