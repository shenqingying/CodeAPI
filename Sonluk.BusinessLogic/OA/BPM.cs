using Sonluk.DAFactory;
using Sonluk.Entities.System;
using Sonluk.IDataAccess.OA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.OA
{
    public class BPM
    {
        private static readonly IBPM _DetaAccess = OADataAccess.CreateBPM();

        public string[] Template(string templateCode)
        {
            Authority auth = new Authority();
            return _DetaAccess.Template(auth.Authenticate().ToString(), templateCode);
        }

        public MessageInfo Launch(string senderLoginName, string templateCode, string subject, string data, long[] attachments, string param, string relateDoc)
        {
            Authority auth = new Authority();
            return _DetaAccess.Launch(auth.Authenticate().ToString(), senderLoginName, templateCode, subject, data, attachments, param, relateDoc);
        }
    }
}
