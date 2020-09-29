using Sonluk.DataAccess.RMS.AffairService;
using Sonluk.DataAccess.RMS.AuthorityService;
using Sonluk.DataAccess.RMS.BPMService;
using Sonluk.DataAccess.RMS.DocumentService;
using Sonluk.Entities.System;
using Sonluk.IDataAccess.CRM;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class CRM_OA : ICRM_OA
    {
        private authorityServicePortTypeClient _authorityClient = new authorityServicePortTypeClient("authorityServiceHttpSoap11Endpoint", "http://192.168.0.168:80/seeyon/services/authorityService.authorityServiceHttpSoap11Endpoint/");
        private BPMServicePortTypeClient _BPMClient = new BPMServicePortTypeClient("BPMServiceHttpSoap11Endpoint", "http://192.168.0.168:80/seeyon/services/BPMService.BPMServiceHttpSoap11Endpoint/");
        private affairServicePortTypeClient _affairClient = new affairServicePortTypeClient("affairServiceHttpSoap11Endpoint", "http://192.168.0.168:80/seeyon/services/affairService.affairServiceHttpSoap11Endpoint/");
        readonly documentServicePortTypeClient _documentClient = new documentServicePortTypeClient("documentServiceHttpSoap11Endpoint", "http://192.168.0.168:80/seeyon/services/documentService.documentServiceHttpSoap11Endpoint/");

        #region authorityService服务
        public string GetAuthority(string username, string pwd)
        {
            //AuthorityService.authorityServicePortTypeClient authorityService = new AuthorityService.authorityServicePortTypeClient("authorityServiceHttpSoap12Endpoint");
            AuthorityService.UserToken userToken = _authorityClient.authenticate(username, pwd);

            return userToken.id;

        }

        #endregion

        #region BPMService服务
        public MessageInfo Launch(string tokenID, string senderLoginName, string templateCode, string subject, string data, long[] attachments, string param, string relateDoc)
        {
            ServiceResponse res = _BPMClient.launchFormCollaboration(tokenID, senderLoginName, templateCode, subject, data, attachments, param, relateDoc);
            MessageInfo message = new MessageInfo();
            message.Value = res.errorMessage;
            message.Key = res.result.ToString();
            return message;
            //return res.result.ToString();

        }

        public int GetFlowState(string tokenID, string ID)
        {

            return Convert.ToInt32(_BPMClient.getFlowState(tokenID, long.Parse(ID)));
        }

        public string[] ReadTemplateDefinition(string token, string templateCode)
        {
            return _BPMClient.getTemplateDefinition(token, templateCode);
        }
        #endregion



        #region affairService服务
        public string Pending(string tokenID, string ticketId, int firstNum, int pageSize)
        {

            return _affairClient.exportPendingList(tokenID, ticketId, firstNum, pageSize);
        }
        public string Track(string tokenID, string ticketId, int firstNum, int pageSize)
        {
            return _affairClient.exportTrackList(tokenID, ticketId, firstNum, pageSize);
        }

        #endregion

        #region documentService服务

        public string ReadFlow(string token, long flowId)
        {
            return _documentClient.exportFlow2(token, flowId);
        }

        #endregion






    }
}
