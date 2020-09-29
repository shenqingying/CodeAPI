using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Sonluk.Entities.API
{
    public static class Msg
    {
        public enum Code
        {
            /// <summary>
            /// 空成功消息
            /// </summary>
            [Desc("00000", "S", "")]
            EmptySuccess = 0,
            /// <summary>
            /// 空失败消息
            /// </summary>
            [Desc("00001", "E", "")]
            EmptyError = 1,
            /// <summary>
            /// 拒绝访问
            /// </summary>
            [Desc("00002", "E", "Access Denied")]
            AccessDenied = 2,
            /// <summary>
            /// 未知错误（追踪ID，消息内容）
            /// </summary>
            [Trace]
            [Desc("00003", "E", "Unknow Error, TraceId:{0}, Message:{1}")]
            UnknowError = 3,
            /// <summary>
            /// 网络错误（追踪ID）
            /// </summary>
            [Trace]
            [Desc("00004", "E", "Network Error, TraceId:{0}")]
            NetworkError = 4,
            /// <summary>
            /// 数据库访问错误（追踪ID）
            /// </summary>
            [Trace]
            [Desc("00005", "E", "Data Access Error, TraceId:{0}")]
            DataAccessError = 5,
            /// <summary>
            /// 文件访问错误（追踪ID）
            /// </summary>
            [Trace]
            [Desc("00006", "E", "File Access Error, TraceId:{0}")]
            FileAccessError = 6,
            /// <summary>
            /// 消息号解析失败
            /// </summary>
            [Desc("00007", "E", "Code Read Error, When Searching Code {0}")]
            CodeReadError = 7,
            /// <summary>
            /// 存储过程逻辑错误
            /// </summary>
            [Desc("00008", "E", "Procedure Logical Error")]
            ProcedureLogicalError = 8,
            /// <summary>
            /// OA的API访问错误（追踪ID）
            /// </summary>
            [Trace]
            [Desc("00009", "E", "OA Read Error, TraceId:{0}")]
            OAReadError = 9,
            /// <summary>
            /// 兼容MES_RETURN（MESSAGE，TID）
            /// </summary>
            [Desc("00010", "X", "Use Old Message(MES_RETURN), Message:{0}, TID:{1}")]
            UseOldMessage = 10
        }

        public static string ToCode(Code myEnum)
        {
            Type type = typeof(Code);
            FieldInfo info = type.GetField(myEnum.ToString());
            DescAttribute[] descAttributes = (DescAttribute[])info.GetCustomAttributes(typeof(DescAttribute), true);
            if (descAttributes != null && descAttributes.Length > 0) return descAttributes[0].Code;
            else return "";
        }

        public static string ToType(Code myEnum)
        {
            Type type = typeof(Code);
            FieldInfo info = type.GetField(myEnum.ToString());
            DescAttribute[] descAttributes = (DescAttribute[])info.GetCustomAttributes(typeof(DescAttribute), true);
            if (descAttributes != null && descAttributes.Length > 0) return descAttributes[0].Type;
            else return "";
        }

        public static string ToMsg(Code myEnum)
        {
            Type type = typeof(Code);
            FieldInfo info = type.GetField(myEnum.ToString());
            DescAttribute[] descAttributes = (DescAttribute[])info.GetCustomAttributes(typeof(DescAttribute), true);
            if (descAttributes != null && descAttributes.Length > 0) return descAttributes[0].Msg;
            else return "";
        }

        public static bool ToTrace(Code myEnum)
        {
            Type type = typeof(Code);
            FieldInfo info = type.GetField(myEnum.ToString());
            TraceAttribute[] traceAttributes = (TraceAttribute[])info.GetCustomAttributes(typeof(TraceAttribute), true);
            if (traceAttributes != null && traceAttributes.Length > 0) return traceAttributes[0].Trace;
            else return false;
        }

        [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
        public sealed class DescAttribute : Attribute
        {
            public string Code { get; }
            public string Type { get; }
            public string Msg { get; }
            public DescAttribute(string code, string type, string msg)
                : base()
            {
                this.Code = code;
                this.Type = type;
                this.Msg = msg;
            }
        }

        [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
        public sealed class TraceAttribute : Attribute
        {
            public bool Trace { get; }
            public TraceAttribute() : base() { this.Trace = true; }
        }
    }
}
