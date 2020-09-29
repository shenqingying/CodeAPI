using Sonluk.Entities.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.OA
{
    public interface IBPM
    {
        string[] Template(string tokenID, string templateCode);
        //string Exportflow(string ptoken, long id);
        MessageInfo Launch(string tokenID, string senderLoginName, string templateCode, string subject, string data, long[] attachments, string param, string relateDoc);
    }
}
