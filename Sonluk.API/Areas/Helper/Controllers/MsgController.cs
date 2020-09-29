using Sonluk.BusinessLogic.Helper;
using Sonluk.Entities.API;
using System.Collections.Generic;
using System.Web.Http;

namespace Sonluk.API.Areas.Helper.Controllers
{
    [ApiReturn]
    [ApiAuthorize]
    public class MsgController : ApiController
    {
        [HttpGet]
        public ApiReturn ReadMsgs()
        {
            return new ApiReturn<List<ApiMessage>>(MessageSelector.ReadAll(), true);
        }

        [HttpGet]
        public ApiReturn ReadMsg(string code = "", int lang = 0)
        {
            MessageSelector.ReadMessage(code, lang);
            return new ApiReturn<List<ApiMessage>>(MessageSelector.ReadAll(), true);
        }

        [HttpPost]
        public ApiReturn CreateMsg(int typeId, string msgName)
        {
            return MessageSelector.CreateMessage(typeId, msgName);
        }

        [HttpPost]
        public ApiReturn UpdateMsg(int id, int typeId, string msgName)
        {
            return MessageSelector.UpdateMessage(id, typeId, msgName);
        }

        [HttpGet]
        public ApiReturn ReadMsgDetails(int msgId)
        {
            return MessageSelector.ReadMessageDetails(msgId);
        }

        [HttpGet]
        public ApiReturn ReadMsgDetail(int id)
        {
            return MessageSelector.ReadMessageDetail(id);
        }

        [HttpPost]
        public ApiReturn CreateMsgDetail(int msgId, int lang, string message)
        {
            return MessageSelector.CreateMessageDetail(msgId, lang, message);
        }

        [HttpPost]
        public ApiReturn UpdateMsgDetail(int id, int lang, string message)
        {
            return MessageSelector.UpdateMessageDetail(id, lang, message);
        }
    }
}
