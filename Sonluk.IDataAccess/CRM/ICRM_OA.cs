using Sonluk.Entities.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICRM_OA
    {
        string GetAuthority(string username,string pwd);
        MessageInfo Launch(string tokenID, string senderLoginName, string templateCode, string subject, string data, long[] attachments, string param, string relateDoc);
        int GetFlowState(string tokenID, string ID);
        string Pending(string tokenID, string ticketId, int firstNum, int pageSize);
        string Track(string tokenID, string ticketId, int firstNum, int pageSize);
        string ReadFlow(string token, long flowId);
        string[] ReadTemplateDefinition(string token, string templateCode);


    }
}
