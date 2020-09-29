using Sonluk.Entities.MES;
using System.Collections.Generic;
using System.Linq;

namespace Sonluk.Entities.API
{
    /// <summary>
    /// 含数据返回消息
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public class ApiReturn<T> : ApiReturn
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// 空实例化
        /// </summary>
        public ApiReturn() { }
        /// <summary>
        /// 快速实例化
        /// </summary>
        /// <param name="success">返回情况布尔值</param>
        public ApiReturn(T data, bool success)
            : base(success)
        {
            this.data = data;
        }
        /// <summary>
        /// 标准实例化（使用消息代码字符串）
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="success">返回情况布尔值</param>
        /// <param name="code">消息代码</param>
        /// <param name="args">消息文本替换</param>
        public ApiReturn(T data, bool success, string code, params object[] args)
            : base(success, code, args)
        {
            this.data = data;
        }
        /// <summary>
        /// 标准实例化（使用消息代码枚举）
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="success">返回情况布尔值</param>
        /// <param name="code">消息代码</param>
        /// <param name="args">消息文本替换</param>
        public ApiReturn(T data, bool success, Msg.Code code, params object[] args)
            : base(success, code, args)
        {
            this.data = data;
        }
        /// <summary>
        /// 通过ApiReturn实例化
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="apiReturn">ApiReturn</param>
        public ApiReturn(T data, ApiReturn apiReturn)
            : base(apiReturn)
        {
            this.data = data;
        }
        /// <summary>
        /// 通过旧的MES_RETURN实例化
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="mesReturn">旧的MES_RETURN</param>
        public ApiReturn(T data, MES_RETURN mesReturn)
            : base(mesReturn)
        {
            this.data = data;
        }
    }

    /// <summary>
    /// 无数据返回消息
    /// </summary>
    public class ApiReturn
    {
        /// <summary>
        /// 成功与否
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 消息组类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 消息组
        /// </summary>
        public List<ApiMessage> messages { get; set; }

        /// <summary>
        /// 空实例化
        /// </summary>
        public ApiReturn() { }
        /// <summary>
        /// 快速实例化
        /// </summary>
        /// <param name="success">返回情况布尔值</param>
        public ApiReturn(bool success)
        {
            this.success = success;
            this.messages = new List<ApiMessage>();
            if (success == false) this.messages.Add(new ApiMessage("00001"));
        }
        /// <summary>
        /// 标准实例化（使用消息代码字符串）
        /// </summary>
        /// <param name="success">返回情况布尔值</param>
        /// <param name="code">消息代码</param>
        /// <param name="args">消息文本替换</param>
        public ApiReturn(bool success, string code, params object[] args)
        {
            this.success = success;
            this.messages = new List<ApiMessage>();
            this.messages.Add(new ApiMessage(code, args));
        }
        /// <summary>
        /// 标准实例化（使用消息代码枚举）
        /// </summary>
        /// <param name="success">返回情况布尔值</param>
        /// <param name="code">消息代码</param>
        /// <param name="args">消息文本替换</param>
        public ApiReturn(bool success, Msg.Code code, params object[] args)
        {
            this.success = success;
            this.messages = new List<ApiMessage>();
            this.messages.Add(new ApiMessage(Msg.ToCode(code), args));
        }
        /// <summary>
        /// 通过ApiReturn实例化
        /// </summary>
        /// <param name="apiReturn">ApiReturn</param>
        public ApiReturn(ApiReturn apiReturn)
        {
            this.success = apiReturn.success;
            this.type = apiReturn.type;
            this.messages = apiReturn.messages;
        }
        /// <summary>
        /// 通过旧的MES_RETURN实例化
        /// </summary>
        /// <param name="mesReturn">旧的MES_RETURN</param>
        public ApiReturn(MES_RETURN mesReturn)
        {
            this.success = TypeValid(mesReturn.TYPE);
            this.messages = new List<ApiMessage>
            {
                new ApiMessage("00010", mesReturn.MESSAGE, mesReturn.TID)
            };
            this.type = mesReturn.TYPE;
        }

        /// <summary>
        /// 合并消息组
        /// </summary>
        /// <param name="messages">要添加的消息组</param>
        /// <param name="success">成功与否（选填，不填则不改变）</param>
        public void AddMessages(List<ApiMessage> messages,bool? success = null)
        {
            if(success != null) this.success = (bool)success;
            if (this.messages == null) this.messages = new List<ApiMessage>();
            this.messages = this.messages.Union(messages).ToList();
        }
        /// <summary>
        /// 添加消息代码并修改成功与否
        /// </summary>
        /// <param name="success">成功与否</param>
        /// <param name="code">消息代码</param>
        /// <param name="args">消息文本替换</param>
        public void AddCode(bool success, string code, params object[] args)
        {
            this.success = success;
            if (this.messages == null) this.messages = new List<ApiMessage>();
            this.messages.Add(new ApiMessage(code, args));
        }
        /// <summary>
        /// 添加消息代码（使用枚举）并修改成功与否
        /// </summary>
        /// <param name="success">成功与否</param>
        /// <param name="code">消息代码的枚举（Sonluk.Entities.API.Msg.Code）</param>
        /// <param name="args">消息文本替换</param>
        public void AddCode(bool success, Msg.Code code, params object[] args)
        {
            this.success = success;
            if (this.messages == null) this.messages = new List<ApiMessage>();
            this.messages.Add(new ApiMessage(Msg.ToCode(code), args));
        }
        /// <summary>
        /// 添加消息代码
        /// </summary>
        /// <param name="code">消息代码</param>
        /// <param name="args">消息文本替换</param>
        public void AddCode(string code, params object[] args)
        {
            if (this.messages == null) this.messages = new List<ApiMessage>();
            this.messages.Add(new ApiMessage(code, args));
        }
        /// <summary>
        /// 添加消息代码（使用枚举）
        /// </summary>
        /// <param name="code">消息代码的枚举（Sonluk.Entities.API.Msg.Code）</param>
        /// <param name="args">消息文本替换</param>
        public void AddCode(Msg.Code code, params object[] args)
        {
            if (this.messages == null) this.messages = new List<ApiMessage>();
            this.messages.Add(new ApiMessage(Msg.ToCode(code), args));
        }
        /// <summary>
        /// 比较消息类型严重程度（如果消息类型不符，则返回原类型）
        /// </summary>
        /// <param name="typeO">原类型</param>
        /// <param name="typeT">比较类型</param>
        /// <returns></returns>
        public static string TopType(string typeO, string typeT)
        {
            string[] list = { "E", "W", "I", "S" };
            foreach (var item in list)
            {
                if (typeO == item) return typeO;
                else if (typeT == item) return typeT;
            }
            return typeO;
        }
        /// <summary>
        /// 消息类型转布尔值
        /// </summary>
        /// <param name="type">消息类型</param>
        /// <returns></returns>
        public static bool TypeValid(string type)
        {
            if (
                type == "S" ||
                type == "W" ||
                type == "I"
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
