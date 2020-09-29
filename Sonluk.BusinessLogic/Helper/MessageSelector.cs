using Sonluk.BusinessLogic.MES;
using Sonluk.Entities.API;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sonluk.BusinessLogic.Helper
{
    public class MessageSelector
    {
        /// <summary>
        /// 自定义系统消息（标准）
        /// </summary>
        /// <returns></returns>
        private static List<ApiMessage> LocalMessage()
        {
            List<ApiMessage> rst = new List<ApiMessage>();
            foreach (Msg.Code item in Enum.GetValues(typeof(Msg.Code)))
            {
                rst.Add(new ApiMessage()
                {
                    code = Msg.ToCode(item),
                    type = Msg.ToType(item),
                    message = Msg.ToMsg(item)
                });
            }
            return rst;
        }
        /// <summary>
        /// 自定义系统消息（追踪）
        /// </summary>
        /// <returns></returns>
        public static List<ApiMessage> TraceMessage()
        {
            List<ApiMessage> rst = new List<ApiMessage>();
            foreach (Msg.Code item in Enum.GetValues(typeof(Msg.Code)))
            {
                if (Msg.ToTrace(item))
                {
                    rst.Add(new ApiMessage()
                    {
                        code = Msg.ToCode(item),
                        type = Msg.ToType(item),
                        message = Msg.ToMsg(item)
                    });
                }
            }
            return rst;
        }

        /// <summary>
        /// 根据消息代码获取消息
        /// </summary>
        /// <param name="code">消息代码</param>
        /// <param name="lang">语言ID</param>
        /// <returns></returns>
        public static ApiMessage ReadMessage(string code, int lang = 0)
        {
            ApiMessage rst = new ApiMessage
            {
                code = code
            };
            if (Convert.ToInt32(code) < 10000)
            {
                rst = LocalMessage().Find((ApiMessage msg) => msg.code == code);
            }
            else
            {
                ApiReturn<MES_SY_LANGUAGE_RETURN_SELECT> readRst = new ApiReturn<MES_SY_LANGUAGE_RETURN_SELECT>(new SY_LANGUAGE_RETURN().SELECT(new MES_SY_LANGUAGE_RETURN() { LB = 1, MSGNO = code }), true);
                ApiReturn<MES_SY_LANGUAGE_RETURNMX_SELECT> readMX = new ApiReturn<MES_SY_LANGUAGE_RETURNMX_SELECT>(new SY_LANGUAGE_RETURN().RETURNMX_SELECT(new MES_SY_LANGUAGE_RETURNMX() { LB = 1, MSGNO = code, SYLANGUAGEID = lang }), true);
                if (readRst.data.MES_RETURN.TYPE == "S" && readMX.data.MES_RETURN.TYPE == "S" && readRst.data.MES_SY_LANGUAGE_RETURN.Count > 0 && readMX.data.MES_SY_LANGUAGE_RETURNMX.Count > 0)
                {
                    rst.message = readMX.data.MES_SY_LANGUAGE_RETURNMX[0].MSGMXTEXT;
                    rst.type = readRst.data.MES_SY_LANGUAGE_RETURN[0].MSGTYPENAME;
                }
                else
                {
                    rst = LocalMessage().Find((ApiMessage msg) => msg.code == Msg.ToCode(Msg.Code.CodeReadError));
                    rst.message = string.Format(rst.message, code);
                }
            }
            return rst;
        }

        /// <summary>
        /// 获取所有消息
        /// </summary>
        /// <returns></returns>
        public static List<ApiMessage> ReadAll()
        {
            //获取所有本地消息
            List<ApiMessage> rst = LocalMessage();
            //获取所有数据库消息
            ApiReturn<MES_SY_LANGUAGE_RETURN_SELECT> msgRst = new ApiReturn<MES_SY_LANGUAGE_RETURN_SELECT>(new SY_LANGUAGE_RETURN().SELECT(new MES_SY_LANGUAGE_RETURN() { LB = 1 }), true);
            if (msgRst.data.MES_RETURN.TYPE == "S" && msgRst.data.MES_SY_LANGUAGE_RETURN.Count > 0)
            {
                foreach (var item in msgRst.data.MES_SY_LANGUAGE_RETURN)
                {
                    ApiMessage child = new ApiMessage()
                    {
                        code = item.MSGNO,
                        type = item.MSGTYPENAME,
                        message = item.MSGNAME,
                        supply = new object[2]
                    };
                    child.supply[0] = item.MSGID;
                    child.supply[1] = item.MSGTYPE;
                    rst.Add(child);
                }
            }
            return rst;
        }

        /// <summary>
        /// 消息比较器
        /// </summary>
        public class MessageComparer : IEqualityComparer<ApiMessage>
        {
            public bool Equals(ApiMessage x, ApiMessage y)
            {
                return x.code.Equals(y.code);
            }

            public int GetHashCode(ApiMessage obj)
            {
                return GetHashCode();
            }
        }

        public static ApiReturn CreateMessage(int typeId, string msgName)
        {
            return new ApiReturn(new SY_LANGUAGE_RETURN().INSERT(new MES_SY_LANGUAGE_RETURN()
            {
                MSGTYPE = typeId,
                MSGNAME = msgName
            }));
        }

        public static ApiReturn UpdateMessage(int id, int typeId, string msgName)
        {
            return new ApiReturn(new SY_LANGUAGE_RETURN().UPDATE(new MES_SY_LANGUAGE_RETURN()
            {
                LB = 2,
                MSGID = id,
                MSGTYPE = typeId,
                MSGNAME = msgName
            }));
        }

        public static ApiReturn DeleteMessage(int id)
        {
            return new ApiReturn(new SY_LANGUAGE_RETURN().UPDATE(new MES_SY_LANGUAGE_RETURN()
            {
                LB = 1,
                MSGID = id
            }));
        }

        public static ApiReturn ReadMessageDetails(int msgId)
        {
            MES_SY_LANGUAGE_RETURNMX_SELECT rst = new SY_LANGUAGE_RETURN().RETURNMX_SELECT(new MES_SY_LANGUAGE_RETURNMX()
            {
                LB = 1,
                MSGID = msgId
            });
            return new ApiReturn<List<MES_SY_LANGUAGE_RETURNMX>>(rst.MES_SY_LANGUAGE_RETURNMX, rst.MES_RETURN);
        }

        public static ApiReturn ReadMessageDetail(int id)
        {
            MES_SY_LANGUAGE_RETURNMX_SELECT rst = new SY_LANGUAGE_RETURN().RETURNMX_SELECT(new MES_SY_LANGUAGE_RETURNMX()
            {
                LB = 1,
                MSGMXID = id
            });
            return new ApiReturn<List<MES_SY_LANGUAGE_RETURNMX>>(rst.MES_SY_LANGUAGE_RETURNMX, rst.MES_RETURN);
        }

        public static ApiReturn CreateMessageDetail(int msgId, int lang, string message)
        {
            return new ApiReturn(new SY_LANGUAGE_RETURN().RETURNMX_INSERT(new MES_SY_LANGUAGE_RETURNMX()
            {
                MSGID = msgId,
                SYLANGUAGEID = lang,
                MSGMXTEXT = message
            }));
        }

        public static ApiReturn UpdateMessageDetail(int id, int lang, string message)
        {
            return new ApiReturn(new SY_LANGUAGE_RETURN().RETURNMX_UPDATE(new MES_SY_LANGUAGE_RETURNMX()
            {
                LB = 2,
                MSGMXID = id,
                SYLANGUAGEID = lang,
                MSGMXTEXT = message
            }));
        }

        public static ApiReturn DeleteMessageDetail(int id, int lang, string message)
        {
            return new ApiReturn(new SY_LANGUAGE_RETURN().RETURNMX_UPDATE(new MES_SY_LANGUAGE_RETURNMX()
            {
                LB = 1,
                MSGMXID = id
            }));
        }
    }
}
