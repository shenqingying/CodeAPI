using Sonluk.DataAccess.OA.Seeyon.MessageAPI;
using Sonluk.IDataAccess.OA;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.OA
{
    public class Message : IMessage
    {
        private messageServicePortTypeClient _Client = new messageServicePortTypeClient("messageServiceHttpSoap12Endpoint", AppConfig.Settings("OA") + "seeyon/services/messageService.messageServiceHttpSoap12Endpoint/");

        public bool Send(string tokenID, IList<string> names, string content, IList<string> url)
        {
            bool success = false;

            ServiceResponse response = _Client.sendMessageByLoginName(tokenID, names.ToArray(), content, url.ToArray());
            if (response.result == 1)
                success = true;

            return success;
        }
    }
}
