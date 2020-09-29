using Sonluk.DataAccess.OA.Seeyon.BMPAPI;
using Sonluk.Entities.System;
using Sonluk.IDataAccess.OA;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.OA
{
    public class BPM : IBPM
    {
        private BPMServicePortTypeClient _Client = new BPMServicePortTypeClient("BPMServiceHttpSoap11Endpoint", AppConfig.Settings("OA") + "seeyon/services/BPMService.BPMServiceHttpSoap12Endpoint/");
        //private documentServicePortTypeClient _Client1 = new documentServicePortTypeClient("documentServiceHttpSoap12Endpoint", AppConfig.Settings("OA") + "seeyon/services/documentService.documentServiceHttpSoap11Endpoint/");
        //private Seeyou.DocumentAPI.documentServicePortTypeClient _Client1 = new Seeyou.DocumentAPI.documentServicePortTypeClient("documentServicePortType");
        
        public string[] Template(string tokenID, string templateCode)
        {
            return _Client.getTemplateDefinition(tokenID, templateCode);
        }
        //public string Exportflow(string ptoken, long id)
        //{
        //    return _Client1.exportFlow2(ptoken, id);
        //}

        public MessageInfo Launch(string tokenID, string senderLoginName, string templateCode, string subject, string data, long[] attachments, string param, string relateDoc)
        {
            ServiceResponse response = _Client.launchFormCollaboration(tokenID, senderLoginName, templateCode, subject, data, attachments, param, relateDoc);
            MessageInfo message = new MessageInfo();
            message.Value = response.errorMessage;
            message.Key = response.result.ToString();
            return message;
        }
    }
}
